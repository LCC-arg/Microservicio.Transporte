namespace Domain
{
    public class Transporte
    {
        public int TransporteId { get; set; }
        public TipoTransporte TipoTransporte { get; set; }
        public int TipoTransporteId { get; set; }
        public CompaniaTransporte CompaniaTransporte { get; set; }
        public int CompaniaTransporteId { get; set; }
        public ICollection<CaracteristicaTransporte> CaracteristicaTransporte { get; set; }
    }
}
