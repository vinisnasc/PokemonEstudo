using Microsoft.EntityFrameworkCore;
using PocketMonster.Data.ContextDB;
using PocketMonster.Model.Interfaces;
using PocketMonster.Model.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Data.Repository
{
    public class BaseRepository<T> where T : class, IEntity
    {
        protected readonly Context contexto;

        public BaseRepository(Context _contexto)
        {
            contexto = _contexto;
        }

        public virtual async Task<bool> Incluir(T entity)
        {
            try
            {
                contexto.Set<T>().Add(entity);
                await contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public virtual async Task<bool> Alterar(T entity)
        {
            contexto.Set<T>().Update(entity);
            await contexto.SaveChangesAsync();
            return true;
        }

        public virtual async Task<List<T>> SelecionarTudo()
        {
            return await contexto.Set<T>().ToListAsync();
        }

        public virtual async Task Deletar(T entity)
        {
            contexto.Set<T>().Remove(entity);
            await contexto.SaveChangesAsync();
        }

        public virtual async Task<T> SelecionarPorId(Guid id)
        {
            return await contexto.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
