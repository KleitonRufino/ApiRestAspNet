using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class SignUpToCourseMap : IEntityTypeConfiguration<SignUpToCourseEntity>
    {
        public void Configure(EntityTypeBuilder<SignUpToCourseEntity> builder)
        {
            builder.ToTable("SignUpToCourse");

            builder.HasKey(u => u.Id);
            
        }
    }
}
