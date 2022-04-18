using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzSozluk.Api.Domain.Models;
using OzSozluk.Infrastructure.Persistence.Context;

namespace OzSozluk.Infrastructure.Persistence.EntityConfigurations.Entry;

public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<EntryCommentVote>
{
    public override void Configure(EntityTypeBuilder<EntryCommentVote> builder)
    {
        base.Configure(builder); //generate id and createdDate

        builder.ToTable("entrycommentvote", OzSozlukContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.EntryComment)
                .WithMany(i => i.EntryCommentVotes)
                .HasForeignKey(i => i.EntryCommentId);

    }
}
