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
    public class StoryConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.HasKey(story=>story.StoryId);
            builder.Property(story=>story.StoryId).IsRequired();
            builder.Property(story => story.StoryTitle).IsRequired();
            builder.Property(story => story.StoryBody).IsRequired();

        }

    }
}
