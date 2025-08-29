using KinemaTrack.Application.Features.RobotArms;
using KinemaTrack.Application.Features.RobotArms.Commands;
using Microsoft.AspNetCore.Mvc;

namespace KinemaTrack.Web.Controllers;

public class RobotArmsController(IRobotArmService robotArmService) : Controller
{
    private readonly IRobotArmService _robotArmService = robotArmService;
    public async Task<IActionResult> Index()
    {
        var robotArmsDtos = await _robotArmService.GetAllArmsForDisplayAsync();
        return View(robotArmsDtos);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateRobotArmCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _robotArmService.CreateNewArmAsync(command);

        return RedirectToAction(nameof(Index));

    }

    [HttpGet]
    public IActionResult AddJoint(Guid robotArmId)
    {
        return View(new AddJointCommand { RobotArmId = robotArmId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddJoint(AddJointCommand command)
    {
        try
        {
            await _robotArmService.AddJointAsync(command);
            return RedirectToAction(nameof(Details), new { id = command.RobotArmId });
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError("RobotArmId", ex.Message);
            return View(command);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Details(Guid id)
    {
        try
        {
            var robotArm = await _robotArmService.GetRobotArmDetailsAsync(id);
            return View(robotArm);
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError("RobotArmId", ex.Message);
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateJointAngle([FromBody] UpdateJointAngleCommand command)
    {
        try
        {
            await _robotArmService.UpdateJointAngleAsync(command);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
