using Ensolvers_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ensolvers_Infrastructure.Configuration
{
    public class ConfigurationNote : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Content).IsRequired(true);
        }
    }
}
