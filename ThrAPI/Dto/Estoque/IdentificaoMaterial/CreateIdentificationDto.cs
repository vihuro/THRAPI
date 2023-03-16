namespace ThrAPI.Dto.Estoque.IdentificaoMaterial
{
    public class CreateIdentificationDto
    {
        public string Codigo { get; set; }
        public string Lote { get; set; }
        public decimal PesoPalete { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal Quantidade { get; set; }
        public string IF { get; set; }
        public decimal Densidade { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
