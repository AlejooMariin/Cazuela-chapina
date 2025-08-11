using System;
using System.Collections.Generic;

namespace CazuelaChapina.Models
{
    public class VentaItem
    {
        public int Id { get; set; }
        public int? TamalId { get; set; }
        public Tamal? Tamal { get; set; }
        public int? BebidaId { get; set; }
        public Bebida? Bebida { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public List<VentaItem> Items { get; set; }
        public decimal Total { get; set; }
        public int SucursalId { get; set; }
        public Sucursal? Sucursal { get; set; }
    }
}
