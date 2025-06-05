using SQLite;
using SistemaAcademico.Models;

namespace SistemaAcademico.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection;

        public SQLiteDatabaseHelper(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Curso>().Wait();
        }

        public Task<int> Insert(Curso p)
        {
            return _connection.InsertAsync(p);
        }

        public Task<List<Curso>> Update(Curso p)
        {
            string sql = "UPDATE Periodo SET Nome = ? WHERE Codigo = ?";
            return _connection.QueryAsync<Curso>(sql, p.Nome, p.Sigla, p.Obs, p.Codigo);
        }

        public Task<int> Delete(int p)
        {
            return _connection.Table<Curso>().DeleteAsync(i => i.Codigo == p);

            /*
            É POSSÍVEL UTILIZAR DOIS MÉTODOS DE ACESSO AOS DADOS NA TABELA, O OUTRO PODE SER ATRAVÉS DA STRING:
            
            string sql = "DELETE FROM Periodo WHERE Codigo = ?";
            return _connection.QueryAsync<Periodo>(sql, p);
            */
        }

        public Task<List<Curso>> GetAll()
        {
            return _connection.Table<Curso>().ToListAsync();
        }

        public Task<List<Curso>> Search(string p)
        {
            string sql = "SELECT * FROM Periodo WHERE Nome LIKE '%" + p + "%'";
            return _connection.QueryAsync<Curso>(sql);
        }
    }
}
