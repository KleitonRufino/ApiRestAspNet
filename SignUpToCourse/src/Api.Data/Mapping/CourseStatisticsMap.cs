using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CourseStatisticsMap : IEntityTypeConfiguration<CourseStatisticsEntity>
    {
        public void Configure(EntityTypeBuilder<CourseStatisticsEntity> builder)
        {
            builder.ToTable("CourseStatistics");

            builder.HasKey(u => u.Id);
            
        }
    }
}
