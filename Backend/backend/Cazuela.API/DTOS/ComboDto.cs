using CazuelaChapina.Models;
namespace CazuelaChapina.Dtos
{
    public class ComboDto
    {
        public int Id { get; set; }
        public ComboTipo Tipo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<int> TamalesIds { get; set; } = new();
        public List<int> BebidasIds { get; set; } = new();
        public decimal Precio { get; set; }
        public bool Editable { get; set; }
    }
}
