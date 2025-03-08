using EventfulPeace.Domain.Common.TypedIds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventfulPeace.Persistence.ShadowEntities;

public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder
            .SetPrimaryKey()
            .SetStronglyTypedIds();
    }
}

static class ParticipantConfigUtils
{
    public static EntityTypeBuilder<Participant> SetPrimaryKey(this EntityTypeBuilder<Participant> builder)
    {
        builder.HasKey(x => new { x.ParticipantId, x.EventId });

        return builder;
    }

    public static EntityTypeBuilder<Participant> SetStronglyTypedIds(this EntityTypeBuilder<Participant> builder)
    {
        builder.Property(pt => pt.ParticipantId)
            .HasConversion(
                id => id.Value,
                val => UserId.New(val)
            );

        builder.Property(pt => pt.EventId)
            .HasConversion(
                id => id.Value,
                val => EventId.New(val)
            );

        return builder;
    }
}