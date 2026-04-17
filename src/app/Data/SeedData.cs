using app.Models;

namespace app.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext db)
    {
        if (db.Events.Any())
            return;

        var technology = new Tag { Name = "Technology" };
        var conference = new Tag { Name = "Conference" };
        var networking = new Tag { Name = "Networking" };
        var music = new Tag { Name = "Music" };
        var festival = new Tag { Name = "Festival" };
        var outdoor = new Tag { Name = "Outdoor" };
        var ai = new Tag { Name = "AI" };
        var workshop = new Tag { Name = "Workshop" };
        var hackathon = new Tag { Name = "Hackathon" };
        var community = new Tag { Name = "Community" };
        var wellness = new Tag { Name = "Wellness" };
        var retreat = new Tag { Name = "Retreat" };
        var food = new Tag { Name = "Food" };
        var social = new Tag { Name = "Social" };
        var wine = new Tag { Name = "Wine" };

        db.Events.AddRange(
            new Event
            {
                Title = "Tech Conference 2026",
                Description = "Join us for the biggest tech conference of the year! Featuring keynotes from industry leaders, hands-on workshops, and networking opportunities that will shape the future of technology.",
                Date = new DateTime(2026, 6, 15),
                Location = "San Francisco, CA",
                CoverImageUrl = "https://images.unsplash.com/photo-1540575467063-178a50c2df87?w=800&q=80",
                Tags = [technology, conference, networking]
            },
            new Event
            {
                Title = "Summer Music Festival",
                Description = "Three days of incredible live music across five stages. From indie rock to electronic, there's something for every music lover. Food trucks, art installations, and good vibes included.",
                Date = new DateTime(2026, 7, 20),
                Location = "Austin, TX",
                CoverImageUrl = "https://images.unsplash.com/photo-1459749411175-04bf5292ceea?w=800&q=80",
                Tags = [music, festival, outdoor]
            },
            new Event
            {
                Title = "AI & Machine Learning Workshop",
                Description = "A practical, hands-on workshop covering the latest in AI and machine learning. Build real projects with Semantic Kernel, Azure OpenAI, and modern .NET tools.",
                Date = new DateTime(2026, 5, 10),
                Location = "Seattle, WA",
                CoverImageUrl = "https://images.unsplash.com/photo-1485827404703-89b55fcc595e?w=800&q=80",
                Tags = [ai, workshop, technology]
            },
            new Event
            {
                Title = "Community Hackathon",
                Description = "48 hours of building, learning, and collaborating. Teams of up to 4 people compete to build the most innovative project. Prizes, mentors, and free pizza await!",
                Date = new DateTime(2026, 8, 5),
                Location = "New York, NY",
                CoverImageUrl = "https://images.unsplash.com/photo-1504384308090-c894fdcc538d?w=800&q=80",
                Tags = [hackathon, community, technology]
            },
            new Event
            {
                Title = "Outdoor Yoga Retreat",
                Description = "Reconnect with yourself in nature. This weekend retreat features morning yoga sessions, guided meditation, healthy meals, and scenic hikes through beautiful trails.",
                Date = new DateTime(2026, 9, 12),
                Location = "Boulder, CO",
                CoverImageUrl = "https://images.unsplash.com/photo-1506126613408-eca07ce68773?w=800&q=80",
                Tags = [wellness, outdoor, retreat]
            },
            new Event
            {
                Title = "Food & Wine Tasting Evening",
                Description = "An elegant evening of curated wine pairings and gourmet bites from local chefs. Explore flavors from around the world in a relaxed, social setting.",
                Date = new DateTime(2026, 5, 28),
                Location = "Napa Valley, CA",
                CoverImageUrl = "https://images.unsplash.com/photo-1510812431401-41d2bd2722f3?w=800&q=80",
                Tags = [food, social, wine]
            }
        );

        db.SaveChanges();
    }
}
