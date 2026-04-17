using app.Models;

namespace app.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext db)
    {
        if (db.Events.Any())
            return;

        db.Events.AddRange(
            new Event
            {
                Title = "Tech Conference 2026",
                Description = "Join us for the biggest tech conference of the year! Featuring keynotes from industry leaders, hands-on workshops, and networking opportunities that will shape the future of technology.",
                Date = new DateTime(2026, 6, 15),
                Location = "San Francisco, CA",
                Tags = ["Technology", "Conference", "Networking"]
            },
            new Event
            {
                Title = "Summer Music Festival",
                Description = "Three days of incredible live music across five stages. From indie rock to electronic, there's something for every music lover. Food trucks, art installations, and good vibes included.",
                Date = new DateTime(2026, 7, 20),
                Location = "Austin, TX",
                Tags = ["Music", "Festival", "Outdoor"]
            },
            new Event
            {
                Title = "AI & Machine Learning Workshop",
                Description = "A practical, hands-on workshop covering the latest in AI and machine learning. Build real projects with Semantic Kernel, Azure OpenAI, and modern .NET tools.",
                Date = new DateTime(2026, 5, 10),
                Location = "Seattle, WA",
                Tags = ["AI", "Workshop", "Technology"]
            },
            new Event
            {
                Title = "Community Hackathon",
                Description = "48 hours of building, learning, and collaborating. Teams of up to 4 people compete to build the most innovative project. Prizes, mentors, and free pizza await!",
                Date = new DateTime(2026, 8, 5),
                Location = "New York, NY",
                Tags = ["Hackathon", "Community", "Technology"]
            },
            new Event
            {
                Title = "Outdoor Yoga Retreat",
                Description = "Reconnect with yourself in nature. This weekend retreat features morning yoga sessions, guided meditation, healthy meals, and scenic hikes through beautiful trails.",
                Date = new DateTime(2026, 9, 12),
                Location = "Boulder, CO",
                Tags = ["Wellness", "Outdoor", "Retreat"]
            },
            new Event
            {
                Title = "Food & Wine Tasting Evening",
                Description = "An elegant evening of curated wine pairings and gourmet bites from local chefs. Explore flavors from around the world in a relaxed, social setting.",
                Date = new DateTime(2026, 5, 28),
                Location = "Napa Valley, CA",
                Tags = ["Food", "Social", "Wine"]
            }
        );

        db.SaveChanges();
    }
}
