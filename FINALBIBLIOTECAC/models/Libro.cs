using System;

namespace ProyectoBibliotecaSENA.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public int Anio { get; set; }
        public bool Disponible { get; set; } = true;

        public Libro() { }

        public Libro(int id, string titulo, string autor, int anio)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Anio = anio;
            Disponible = true;
        }

        public string ResumenCorto() => $"{Titulo} - {Autor} (ID: {Id})";

        public string DetalleCompleto() => $"ID: {Id} | Título: {Titulo} | Autor: {Autor} | Año: {Anio} | Disponible: {(Disponible ? "Sí" : "No")}";

        public override string ToString() => DetalleCompleto();
    }
}