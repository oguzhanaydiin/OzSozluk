using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzSozluk.Api.Domain.Models;
using OzSozluk.Infrastructure.Persistence.Context;

namespace OzSozluk.Infrastructure.Persistence.EntityConfigurations;

public class EmailConfirmationEntityConfiguration : BaseEntityConfiguration<EmailConfirmation>
{
    public override void Configure(EntityTypeBuilder<EmailConfirmation> builder)
    {
        base.Configure(builder);

        builder.ToTable("emailconfirmation", OzSozlukContext.DEFAULT_SCHEMA);
    }
}
