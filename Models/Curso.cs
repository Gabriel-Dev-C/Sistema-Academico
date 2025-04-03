using SQLite;

namespace SistemaAcademico.Models
{
    public class Curso
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public string Obs { get; set; }
    }
}
