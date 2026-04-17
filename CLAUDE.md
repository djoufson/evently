# CLAUDE.md

## Project Overview

Evently is a Smart Event Manager built with .NET Blazor SSR and Tailwind CSS v4. It demonstrates progressive AI integration using Semantic Kernel and Azure AI services.

## Tech Stack

- **Blazor SSR** (Server-Side Rendering) - fullstack .NET
- **Tailwind CSS v4** for styling
- **Entity Framework Core** with SQLite
- **Semantic Kernel** for AI orchestration
- **Azure AI Services** for text and image generation

## Key Commands

```bash
# Run the app
dotnet run

# Run tests
dotnet test

# Apply EF migrations
dotnet ef database update

# Build
dotnet build
```

## Architecture

- Blazor SSR fullstack (no separate frontend/backend)
- Cover images can be uploaded (`POST /api/uploads`) or AI-generated; stored on disk and served via `GET /api/uploads/{filename}`
- AI features are introduced progressively (text generation, recommendations, image generation)

## Code Style

- Follow standard C# conventions
- Use nullable reference types
- Prefer minimal, focused changes
