using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzSozluk.Api.Domain.Models;
using OzSozluk.Infrastructure.Persistence.Context;

namespace OzSozluk.Infrastructure.Persistence.EntityConfigurations.Entry;

public class EntryVoteEntityConfiguration : BaseEntityConfiguration<EntryVote>
{
    public override void Configure(EntityTypeBuilder<EntryVote> builder)
    {
        base.Configure(builder); //generate id and createdDate

        builder.ToTable("entryvote", OzSozlukContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.Entry)
                .WithMany(i => i.EntryVotes)
                .HasForeignKey(i => i.EntryId);

    }
}
