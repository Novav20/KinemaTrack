#!/bin/bash

# Relative paths to project folders
INFRA_PROJECT="./src/KinemaTrack.Infrastructure"
WEB_PROJECT="./src/KinemaTrack.Web"

# Check if the .csproj files exist
if [ ! -f "$INFRA_PROJECT/KinemaTrack.Infrastructure.csproj" ]; then
  echo "❌ Error: KinemaTrack.Infrastructure.csproj not found in $INFRA_PROJECT"
  exit 1
fi

if [ ! -f "$WEB_PROJECT/KinemaTrack.Web.csproj" ]; then
  echo "❌ Error: KinemaTrack.Web.csproj not found in $WEB_PROJECT"
  exit 1
fi

# Check if the container is running
if [ "$(docker ps -q -f name=oracle-db)" = "" ]; then
  echo "🟡 Starting oracle-db container..."
  docker start oracle-db
else
  echo "✅ oracle-db container is already running."
fi

# Prompt for migration name
read -p "Enter migration name: " MIGRATION_NAME

if [ -z "$MIGRATION_NAME" ]; then
  echo "❌ Migration name cannot be empty. Aborting."
  exit 1
fi

# Run dotnet ef migrations add
echo "🛠️ Running: dotnet ef migrations add \"$MIGRATION_NAME\""
dotnet ef migrations add "$MIGRATION_NAME" -p "$INFRA_PROJECT" -s "$WEB_PROJECT"
if [ $? -ne 0 ]; then
  echo "❌ Failed to create the migration. Aborting."
  exit 1
fi

# Run dotnet ef database update
echo "📦 Applying migration to the database..."
dotnet ef database update -p "$INFRA_PROJECT" -s "$WEB_PROJECT"
if [ $? -ne 0 ]; then
  echo "❌ Failed to apply the migration to the database."
  exit 1
fi

echo "✅ Migration completed successfully."
