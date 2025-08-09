namespace CazuelaChapina.Models
{
    public enum MasaTipo { MaizAmarillo, MaizBlanco, Arroz }
    public enum RellenoTipo { RecadoRojoCerdo, NegroPollo, ChipilinVegetariano, MezclaChuchito }
    public enum EnvolturaTipo { HojaPlatano, TusaMaiz }
    public enum NivelPicante { SinChile, Suave, Chapin }

    public class Tamal
    {
        public int Id { get; set; }
        public MasaTipo Masa { get; set; }
        public RellenoTipo Relleno { get; set; }
        public EnvolturaTipo Envoltura { get; set; }
        public NivelPicante Picante { get; set; }
        public int Cantidad { get; set; } // 1, 6, 12
        public decimal Precio { get; set; }
    }
}
