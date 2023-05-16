namespace Domain
{
    public class TipoTransporte
    {
        public int TipoTransporteId { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Transporte> Transporte { get; set; }
    }
}
