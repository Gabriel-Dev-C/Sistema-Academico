using SQLite;

namespace SistemaAcademico.Models
{
    public class Curso
    {
        [PrimaryKey, AutoIncrement]
        public int Codigo { get; set; }

        [NotNull]
        public string Nome { get; set; }

        [NotNull]
        public string Sigla { get; set; }

        public string Obs { get; set; }
    }
}
