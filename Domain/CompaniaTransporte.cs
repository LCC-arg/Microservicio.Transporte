namespace Domain
{
    public class CompaniaTransporte
    {
        public int CompaniaTransporteId { get; set; }
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string ImagenLogo { get; set; }
        public ICollection<Transporte> Transporte { get; set; }
    }
}
