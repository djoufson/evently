# Evently - Smart Event Manager

A simple Event Management application built with .NET Blazor SSR, progressively enhanced with AI capabilities using Azure AI services and Semantic Kernel.

## Tech Stack

- **Blazor SSR** - Fullstack .NET web framework
- **Tailwind CSS v4** - Utility-first CSS
- **Entity Framework Core** - Data access with SQLite
- **Semantic Kernel** - AI orchestration
- **Azure AI Services** - Text and image generation

## Features

- CRUD operations for events (create, list, view, edit, delete)
- Cover image upload or AI generation
- Event tagging
- AI-powered description generation
- Smart event recommendations sorted by "fun factor"
- AI-generated cover images

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (for Tailwind CSS)

### Run the app

```bash
dotnet run
```

### Configuration

To enable AI features, configure your Azure AI services credentials in `appsettings.json` or user secrets:

```json
{
  "AzureOpenAI": {
    "Endpoint": "<your-endpoint>",
    "ApiKey": "<your-api-key>",
    "DeploymentName": "<your-deployment>"
  }
}
```

## Project Structure

```
evently/
├── docs/
│   └── specs.md          # Full project specification
├── CLAUDE.md              # Claude Code instructions
├── CONTRIBUTING.md        # Contribution guidelines
├── LICENSE                # MIT License
└── README.md
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.
