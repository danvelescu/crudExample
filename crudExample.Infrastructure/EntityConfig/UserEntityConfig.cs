using crudExample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudExample.Infrastructure.EntityConfig
{
    public class UserEntityConfig:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.FirstName).HasMaxLength(50).IsRequired();
        }
    }
}
