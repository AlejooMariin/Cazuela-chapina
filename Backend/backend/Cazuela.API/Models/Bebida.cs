namespace CazuelaChapina.Models
{
    public enum TamanoBebida { Vaso12oz, Jarro1L }
    public enum TipoBebida { AtolElote, AtoleShuco, Pinol, CacaoBatido }
    public enum Endulzante { Panela, Miel, SinAzucar }
    public enum Topping { Ninguno, Malvaviscos, Canela, RalladuraCacao }

    public class Bebida
    {
        public int Id { get; set; }
        public TamanoBebida Tamano { get; set; }
        public TipoBebida Tipo { get; set; }
        public Endulzante EndulzadoCon { get; set; }
        public Topping ToppingAdicional { get; set; }
        public decimal Precio { get; set; }
    }
}
