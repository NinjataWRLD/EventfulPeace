using EventfulPeace.Domain.Common.TypedIds;
using EventfulPeace.Domain.Invitations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventfulPeace.Persistence.Invitations.Configurations;

public class InvitationConfigurations : IEntityTypeConfiguration<Invitation>
{
    public void Configure(EntityTypeBuilder<Invitation> builder)
    {
        builder
            .SetPrimaryKey()
            .SetStronglyTypedIds()
            .SetValidations();
    }
}

static class ConfigUtils
{
    public static EntityTypeBuilder<Invitation> SetPrimaryKey(this EntityTypeBuilder<Invitation> builder)
    {
        builder.HasKey(x => x.Id);
        return builder;
    }

    public static EntityTypeBuilder<Invitation> SetStronglyTypedIds(this EntityTypeBuilder<Invitation> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(
                x => x.Value,
                v => InvitationId.New(v)
            );
        
        builder.Property(x => x.EventId)
            .ValueGeneratedOnAdd()
            .HasConversion(
                x => x.Value,
                v => EventId.New(v)
            );

        builder.Property(x => x.SenderId)
            .HasConversion(
                x => x.Value,
                x => UserId.New(x)
            );

        builder.Property(x => x.ReceiverId)
            .HasConversion(
                x => x.Value,
                x => UserId.New(x)
            );

        return builder;
    }

    public static EntityTypeBuilder<Invitation> SetValidations(this EntityTypeBuilder<Invitation> builder)
    {
        builder.Property(x => x.EventId)
            .IsRequired()
            .HasColumnName(nameof(Invitation.EventId));
        
        builder.Property(x => x.SentAt)
            .IsRequired()
            .HasColumnName(nameof(Invitation.SentAt));
        
        builder.Property(x => x.SenderId)
            .IsRequired()
            .HasColumnName(nameof(Invitation.SenderId));
        
        builder.Property(x => x.ReceiverId)
            .IsRequired()
            .HasColumnName(nameof(Invitation.ReceiverId));

        return builder;
    }
}
