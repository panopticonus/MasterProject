﻿namespace MasterProject.Persistence.EntityConfiguration
{
    using Core.Models;
    using System.Data.Entity.ModelConfiguration;

    public class NursesConfiguration : EntityTypeConfiguration<Nurses>
    {
        public NursesConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Pwz).IsRequired().HasMaxLength(7);
            Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            Property(x => x.Surname).IsRequired().HasMaxLength(100);
            Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
        }
    }
}
