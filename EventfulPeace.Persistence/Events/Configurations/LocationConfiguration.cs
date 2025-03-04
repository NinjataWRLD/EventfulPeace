using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Events;
using EventfulPeace.Domain.Events.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventfulPeace.Persistence.Events.Configurations;

using static EventConstants.Locations;

public class LocationConfigurations : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder
            .SetPrimaryKey()
            .SetStronglyTypedIds()
            .SetValidations()
            .SetSeeding();
    }
}

static class UserConfigUtils
{
    public static EntityTypeBuilder<Location> SetPrimaryKey(this EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(x => x.Id);
        return builder;
    }

    public static EntityTypeBuilder<Location> SetStronglyTypedIds(this EntityTypeBuilder<Location> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(
                x => x.Value,
                v => LocationId.New(v)
            );

        return builder;
    }

    public static EntityTypeBuilder<Location> SetValidations(this EntityTypeBuilder<Location> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName(nameof(Event.Name));

        return builder;
    }

    public static EntityTypeBuilder<Location> SetSeeding(this EntityTypeBuilder<Location> builder)
    {
        builder.HasData([
            Location.Create(id: Blagoevgrad, name: nameof(Blagoevgrad)),
            Location.Create(id: Burgas, name: nameof(Burgas)),
            Location.Create(id: Shumen, name: nameof(Shumen)),
            Location.Create(id: Dobrich, name: nameof(Dobrich)),
            Location.Create(id: Gabrovo, name: nameof(Gabrovo)),
            Location.Create(id: Kardjali, name: nameof(Kardjali)),
            Location.Create(id: Haskovo, name: nameof(Haskovo)),
            Location.Create(id: Kyustendil, name: nameof(Kyustendil)),
            Location.Create(id: Lovech, name: nameof(Lovech)),
            Location.Create(id: Montana, name: nameof(Montana)),
            Location.Create(id: Pazardjik, name: nameof(Pazardjik)),
            Location.Create(id: Pernik, name: nameof(Pernik)),
            Location.Create(id: Pleven, name: nameof(Pleven)),
            Location.Create(id: Plovdiv, name: nameof(Plovdiv)),
            Location.Create(id: Razgrad, name: nameof(Razgrad)),
            Location.Create(id: Ruse, name: nameof(Ruse)),
            Location.Create(id: Smolyan, name: nameof(Smolyan)),
            Location.Create(id: Sliven, name: nameof(Sliven)),
            Location.Create(id: Sofia, name: nameof(Sofia)),
            Location.Create(id: StaraZagora, name: "Stara Zagora"),
            Location.Create(id: Targovishte, name: nameof(Targovishte)),
            Location.Create(id: Varna, name: nameof(Varna)),
            Location.Create(id: VelikoTarnovo, name: "Veliko Tarnovo"),
            Location.Create(id: Vidin, name: nameof(Vidin)),
            Location.Create(id: Vratsa, name: nameof(Vratsa)),
            Location.Create(id: Yambol, name: nameof(Yambol)),
        ]);

        return builder;
    }
}
