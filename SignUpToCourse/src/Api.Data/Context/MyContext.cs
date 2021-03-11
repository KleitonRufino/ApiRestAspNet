using System;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CourseEntity>(new CourseMap().Configure);
            modelBuilder.Entity<SignUpToCourseEntity>(new SignUpToCourseMap().Configure);
            modelBuilder.Entity<CourseStatisticsEntity>(new CourseStatisticsMap().Configure);

        }

    }
}
