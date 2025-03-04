using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventfulPeace.Persistence.Events.Configurations;

using static EventConstants;

public class EventConfigurations : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder
            .SetPrimaryKey()
            .SetForeignKeys()
            .SetStronglyTypedIds()
            .SetValidations()
            .SetSeeding();
    }
}

static class ConfigUtils
{
    public static EntityTypeBuilder<Event> SetPrimaryKey(this EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(x => x.Id);
        return builder;
    }

    public static EntityTypeBuilder<Event> SetForeignKeys(this EntityTypeBuilder<Event> builder)
    {
        builder
            .HasOne(x => x.Location)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.LocationId)
            .OnDelete(DeleteBehavior.Cascade);

        return builder;
    }

    public static EntityTypeBuilder<Event> SetStronglyTypedIds(this EntityTypeBuilder<Event> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(
                x => x.Value,
                v => EventId.New(v)
            );

        builder.Property(x => x.CreatorId)
            .HasConversion(
                x => x.Value,
                x => UserId.New(x)
            );

        builder.Property(x => x.LocationId)
            .HasConversion(
                x => x.Value,
                x => LocationId.New(x)
            );

        return builder;
    }

    public static EntityTypeBuilder<Event> SetValidations(this EntityTypeBuilder<Event> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(NameMaxLength)
            .HasColumnName(nameof(Event.Name));

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(DescriptionMaxLength)
            .HasColumnName(nameof(Event.Description));

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName(nameof(Event.CreatedAt));

        builder.Property(x => x.OccursAt)
            .IsRequired()
            .HasColumnName(nameof(Event.OccursAt));

        builder.Property(x => x.CreatorId)
            .IsRequired()
            .HasColumnName(nameof(Event.CreatorId));

        builder.Property(x => x.LocationId)
            .IsRequired()
            .HasColumnName(nameof(Event.LocationId));

        return builder;
    }

    public static EntityTypeBuilder<Event> SetSeeding(this EntityTypeBuilder<Event> builder)
    {
        builder.HasData([
            Event.Create(
                id: EventId.New(Guid.Parse("762ddec2-25c9-4183-9891-72a19d84a839")),
                name: "Martenitsa Workshop",
                description: "Welcome to our not-like-the-others Martenitsa Workshop!",
                occursAt: new DateTime(2025, 3, 03, 15, 30, 0, DateTimeKind.Utc),
                creatorId: UserConstants.Ids.Organization1,
                locationId: Locations.Burgas,
                createdAt: new DateTime(2025, 3, 04, 14, 00, 0, DateTimeKind.Utc)
            ),
            Event.Create(
                id: EventId.New(Guid.Parse("e1101e2c-32cc-456f-9c82-4f1d1a65d141")),
                name: "Street Food Festeival",
                description: "Endulge in various cuisines, carefully prepared by the best of street food cooks",
                occursAt: new DateTime(2025, 3, 21, 19, 30, 0, DateTimeKind.Utc),
                creatorId: UserConstants.Ids.Individual1,
                locationId: Locations.Sofia,
                createdAt: new DateTime(2025, 3, 04, 14, 00, 0, DateTimeKind.Utc)
            ),
            Event.Create(
                id: EventId.New(Guid.Parse("f3ad41d3-ee90-4988-9195-8b2a8f4f2733")),
                name: "Astronomical View",
                description: "Gaze at the stars through the lenses of professional telescopes and witness the beauty of the night sky",
                occursAt: new DateTime(2025, 4, 5, 10, 0, 0, DateTimeKind.Utc),
                creatorId: UserConstants.Ids.Individual2,
                locationId: Locations.Plovdiv,
                createdAt: new DateTime(2025, 3, 04, 14, 00, 0, DateTimeKind.Utc)
            ),
            Event.Create(
                id: EventId.New(Guid.Parse("fad1b19d-5333-4633-bd84-d67c64649f65")),
                name: "The Greenery Challenge",
                description: "A sport event for all nature lovers, with a route through picturesque greenery",
                occursAt: new DateTime(2025, 5, 5, 8, 0, 0, DateTimeKind.Utc),
                creatorId: UserConstants.Ids.Individual2,
                locationId: Locations.VelikoTarnovo,
                createdAt: new DateTime(2025, 3, 04, 14, 00, 0, DateTimeKind.Utc)
            ),
        ]);

        return builder;
    }
}
