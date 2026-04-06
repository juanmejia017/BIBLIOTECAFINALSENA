using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoBibliotecaSENA.Models;

namespace ProyectoBibliotecaSENA.Services
{
    public class LibroService
    {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(Libro libro) => libros.Add(libro);
        
        public List<Libro> ObtenerTodos() => libros;

        public Libro? BuscarPorTitulo(string titulo) => 
            libros.FirstOrDefault(l => l.Titulo!.Contains(titulo, StringComparison.OrdinalIgnoreCase));

        public void OrdenarPorTitulo() => libros = libros.OrderBy(l => l.Titulo).ToList();

        // KPIs
        public int TotalLibros() => libros.Count;
        public int LibrosDisponibles() => libros.Count(l => l.Disponible);
        public int LibrosPrestados() => libros.Count(l => !l.Disponible);
    }
}