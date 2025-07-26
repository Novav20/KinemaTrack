#!/bin/bash

# Start sqlserver container if not running
if [ "$(docker ps -q -f name=oracle-db)" = "" ]; then
  echo "Starting oracle-db container..."
  docker start oracle-db
else
  echo "oracle-db container is already running."
fi

# Prompt for migration name
read -p "Enter migration name: " MIGRATION_NAME

# Run dotnet ef migrations add
if [ -z "$MIGRATION_NAME" ]; then
  echo "Migration name cannot be empty. Exiting."
  exit 1
fi

dotnet ef migrations add "$MIGRATION_NAME" -p KinemaTrack.Infrastructure -s KinemaTrack.Web

# Run dotnet ef database update
dotnet ef database update -p KinemaTrack.Infrastructure -s KinemaTrack.Web
