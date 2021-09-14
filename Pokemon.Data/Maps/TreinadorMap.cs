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
    public class TreinadorMap : IEntityTypeConfiguration<Treinador>
    {
        public void Configure(EntityTypeBuilder<Treinador> builder)
        {
            builder.ToTable("Treinadores");

            builder.HasKey(x => x.Id);
        }
    }
}
