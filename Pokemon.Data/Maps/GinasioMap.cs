using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocketMonster.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Data.Maps
{
    public class GinasioMap : IEntityTypeConfiguration<Ginasio>
    {
        public void Configure(EntityTypeBuilder<Ginasio> builder)
        {
            builder.ToTable("Ginasios");

            builder.HasKey(x => x.Id);

            builder.HasOne<Treinador>(t => t.GymLider);
        }
    }
}
