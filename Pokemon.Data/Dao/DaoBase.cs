using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Data.Dao
{
    public abstract class DaoBase: IDisposable
    {
        protected readonly SqlConnection con;

        protected DaoBase()
        {
            con = new SqlConnection("Server=DESKTOP-R9JFMSC\\SQLEXPRESS;Database=PocketMonster;Integrated Security=True;Connect Timeout=30");
        }

        protected async Task Insert(string comando)
        {
                con.Open();
                SqlCommand cmd = new(comando, con);
                await cmd.ExecuteNonQueryAsync();
                con.Close();
        }

        protected async Task Select(string comando, Action<SqlDataReader> tratamentoLeitura)
        {
            con.Open();
            SqlCommand cmd = new(comando, con);
            SqlDataReader dr = await cmd.ExecuteReaderAsync();
            tratamentoLeitura(dr);
            con.Close();
        }

        public void Dispose()
        {
            con?.Close();
            con?.Dispose();
        }
    }
}
