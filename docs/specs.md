# Smart Event Manager - Demo Project Specification

## Overview

This project is a simple Event Management application built with .NET and Blazor SSR.
It is designed as a baseline application that will be progressively enhanced with AI capabilities during a live demo.

The goal is to demonstrate how an existing, traditional application can evolve into an intelligent, AI-powered system using Azure AI services, Semantic Kernel, and modern .NET tools.

---

## Objectives

- Build a clean, functional application with a clear separation of concerns
- Keep the architecture simple but production-oriented
- Prepare the foundation for incremental AI integration
- Showcase a clear evolution path from static to intelligent app

---

## Technology Stack

### Fullstack

- Blazor SSR (Server-Side Rendering) - fullstack with .NET
- Tailwind CSS v4 for styling

### Data Layer

- Entity Framework Core
- SQLite (or PostgreSQL optional)

### AI (introduced progressively)

- Azure AI Services (Azure OpenAI for text, Azure AI Image generation)
- Semantic Kernel for AI orchestration

---

## Core Features (Non-AI Version)

### Event Management

- Create, Read, Update, Delete events

### Event Listing

- List all events with summary

### Event Details

- Full event information
- Placeholder for AI features

---

## Data Model

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

## Roadmap: AI Integration

### Phase 0 - Baseline

- CRUD app working with Blazor SSR and Tailwind CSS v4

### Phase 1 - AI Text Generation

- Generate event descriptions using Azure OpenAI via Semantic Kernel

### Phase 2 - AI Smart Recommendations

- Sort and rank events by "fun factor" using Azure OpenAI via Semantic Kernel
- The AI analyzes event titles, descriptions, and details to score how fun each event is
- Events are displayed sorted by recommendation score on the listing page

### Phase 3 - AI Image Generation

- Generate cover images using Azure AI image generation services

---

## Final Vision

A simple CRUD app evolves into an intelligent AI-powered system, leveraging Semantic Kernel and Azure AI services for text generation, image generation, and smart event recommendations.
