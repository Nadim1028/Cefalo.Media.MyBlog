using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(author=>author.AuthorId);
            builder.Property(author => author.AuthorId).IsRequired();
            builder.Property(author => author.Name).IsRequired();
            builder.Property(author=>author.Email).IsRequired();
            builder.Property(author => author.Password).IsRequired().HasMaxLength(10);
            builder.Property(author => author.Addresss).IsRequired();


            builder.HasMany(author => author.Stories)
                 .WithOne(story => story.Author)
                 .HasForeignKey(s => s.AuthorId);
        }
    }
}
