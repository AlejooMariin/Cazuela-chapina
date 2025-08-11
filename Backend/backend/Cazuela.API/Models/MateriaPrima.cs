
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;
namespace CazuelaChapina.Models
{
    public enum MateriaPrimaTipo { Masa, Hoja, Proteina, Grano, Endulzante, Especia }
    public enum EmpaqueTipo { Caja, Bolsa, Termo }

    public class MateriaPrima
    {
        public int Id { get; set; }
        public MateriaPrimaTipo Tipo { get; set; }
        public string Nombre { get; set; }
        public decimal CantidadDisponible { get; set; }
        public string UnidadMedida { get; set; } // ej. Kg, Litros
        public decimal CostoPromedio { get; set; }
    }

    public class InventarioMovimiento
    {
        public int Id { get; set; }
        public int MateriaPrimaId { get; set; }

        [JsonIgnore]
        public MateriaPrima? MateriaPrima { get; set; }

        public decimal Cantidad { get; set; }
        public string TipoMovimiento { get; set; } // Entrada, Salida, Merma
        public DateTime Fecha { get; set; }
        public decimal CostoUnitario { get; set; }
    }
}
