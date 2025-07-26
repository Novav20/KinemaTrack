using KinemaTrack.Application.Features.RobotArms.Commands;
using KinemaTrack.Application.Features.RobotArms.Queries;
using KinemaTrack.Domain.Entities;
using KinemaTrack.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KinemaTrack.Web.Controllers;

public class RobotArmsController(ApplicationDbContext context) : Controller
{
    // TODO: Move to a UofW, service/repository layer
    private readonly ApplicationDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var robotArms = await _context.RobotArms.ToListAsync();
        var robotArmsDtos = robotArms.Select(x => new RobotArmDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt
        }).ToList();

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

        var newRobotArm = new RobotArm
        {
            Name = command.Name,
            Description = command.Description,
        };

        await _context.RobotArms.AddAsync(newRobotArm);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));

    }
}
