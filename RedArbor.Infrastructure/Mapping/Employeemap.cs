﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedArbor.Domain.Entities;

namespace RedArbor.Infrastructure.Mapping
{
    public class Employeemap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.HasOne(d => d.Company)
            // .WithMany(p => p.)
            // .HasPrincipalKey(p => p.Id)
            // .HasForeignKey(d => d.CompanyId);
        }
    }
}
