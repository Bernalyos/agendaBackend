namespace AgendaBackend.DTOs
{
    public class ContactoCreateUpdateDto
    {
        public string TipoDeContacto { get; set; } = string.Empty; // Persona, Organización Pública, Organización Privada
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Comentarios { get; set; } = string.Empty;
        public string CamposAdicionales { get; set; } = string.Empty; // O JSON según prefieras
    }

    public class ContactoResponseDto
    {
        public int Id { get; set; }
        public string TipoDeContacto { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Comentarios { get; set; } = string.Empty;
        public string CamposAdicionales { get; set; } = string.Empty;
    }
}