﻿using Dotz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.Balance).IsRequired();
            builder.HasMany(x => x.Addresses);
            builder.HasMany(x => x.UserHistories);
        }
    }
}
