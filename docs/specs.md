# Smart Event Manager – Demo Project Specification

## Overview

This project is a simple Event Management application built with .NET and Blazor.
It is intentionally designed as a non-AI baseline application, which will then be progressively enhanced with AI capabilities during a live demo.

The goal is to demonstrate how an existing, traditional application can evolve into an intelligent, AI-powered system using Azure and modern .NET tools.

---

# 🎯 Objectives

- Build a clean, functional non-AI application
- Keep the architecture simple but production-oriented
- Prepare the foundation for incremental AI integration
- Showcase a clear evolution path from static → intelligent app

---

# 🧰 Technology Stack

## Frontend
- Blazor (Server or SSR preferred for simplicity)

## Backend
- ASP.NET Core (Minimal API or Controllers)

## Data Layer
- Entity Framework Core
- SQLite (or PostgreSQL optional)

## AI (introduced later)
- Azure OpenAI
- Semantic Kernel

---

# 📦 Core Features (Non-AI Version)

## Event Management
- Create, Read, Update, Delete events

## Event Listing
- List all events with summary

## Event Details
- Full event information
- Placeholder for AI features

---

# 🧱 Data Model

```csharp
public class Event
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string? GeneratedCoverImageUrl { get; set; }
}
```

---

# 🔌 API Endpoints

- GET /events
- GET /events/{id}
- POST /events
- PUT /events/{id}
- DELETE /events/{id}

---

# 🧭 Roadmap: AI Integration

## Phase 0 — Baseline
- CRUD app working

## Phase 1 — AI Text
- Generate descriptions

## Phase 2 — AI Chat
- Ask questions about events

## Phase 3 — AI Images
- Generate cover images

## Phase 4 — Context AI
- AI uses app data

---

# 🚀 Final Vision

A simple CRUD app evolves into an intelligent AI-powered system.
