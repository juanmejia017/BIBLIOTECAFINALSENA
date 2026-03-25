namespace ProyectoBibliotecaSENA.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Documento { get; set; }
        public bool Activo { get; set; } = true;

        public Usuario() { }

        public Usuario(int id, string nombre, string documento)
        {
            Id = id;
            Nombre = nombre;
            Documento = documento;
            Activo = true;
        }

        public string ResumenCorto() => $"{Nombre} | Doc: {Documento}";

        public string DetalleCompleto() => $"ID: {Id} | Nombre: {Nombre} | Documento: {Documento} | Estado: {(Activo ? "Activo" : "Inactivo")}";

        public override string ToString() => DetalleCompleto();
    }
}