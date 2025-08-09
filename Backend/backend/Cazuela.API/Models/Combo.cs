using System.Collections.Generic;

namespace CazuelaChapina.Models
{
    public enum ComboTipo { FamiliarFiestaPatronal, EventosMadrugada24, Estacional }

    public class Combo
    {
        public int Id { get; set; }
        public ComboTipo Tipo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Tamal> Tamales { get; set; }
        public List<Bebida> Bebidas { get; set; }
        public decimal Precio { get; set; }
        public bool Editable { get; set; } // Para combo estacional editable
    }
}
