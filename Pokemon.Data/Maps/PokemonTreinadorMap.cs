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
    public class PokemonTreinadorMap : IEntityTypeConfiguration<PokemonTreinador>
    {
        public void Configure(EntityTypeBuilder<PokemonTreinador> builder)
        {
            builder.ToTable("PokemonTreinadores");

            builder.HasKey(x => new { x.IdPokemon, x.IdTreinador });

            builder.HasOne<Pokemon>(p => p.Pokemon)
                   .WithMany(d => d.PokemonTreinador)
                   .HasForeignKey(k => k.IdPokemon);

            builder.HasOne<Treinador>(p => p.Treinador)
                   .WithMany(d => d.PokemonCapturados)
                   .HasForeignKey(k => k.IdTreinador);
        }
    }
}
