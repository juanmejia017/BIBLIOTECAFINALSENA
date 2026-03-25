using System;

namespace ProyectoBibliotecaSENA.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public Libro? LibroPrestado { get; set; }
        public Usuario? UsuarioSolicitante { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public EstadoPrestamo Estado { get; set; }

        public Prestamo() { }

        public Prestamo(int id, Libro libro, Usuario usuario)
        {
            Id = id;
            LibroPrestado = libro;
            UsuarioSolicitante = usuario;
            FechaSalida = DateTime.Now;
            FechaDevolucion = null;
            Estado = EstadoPrestamo.Activo;
        }

        public bool EstaVencido() => (DateTime.Now - FechaSalida).Days > 8 && Estado == EstadoPrestamo.Activo;

        public int DiasTranscurridos() => (DateTime.Now - FechaSalida).Days;

        public string ResumenCorto() => $"ID: {Id} | Libro: {LibroPrestado?.Titulo} | Usuario: {UsuarioSolicitante?.Nombre}";

        public string DetalleCompleto() => $"Préstamo #{Id}\nLibro: {LibroPrestado?.Titulo}\nUsuario: {UsuarioSolicitante?.Nombre}\nFecha Salida: {FechaSalida.ToShortDateString()}\nEstado: {Estado}\nDías Transcurridos: {DiasTranscurridos()}\nVencido: {(EstaVencido() ? "SÍ" : "NO")}";

        public override string ToString() => ResumenCorto();
    }
}