using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoBibliotecaSENA.Models;

namespace ProyectoBibliotecaSENA.Services
{
    public class LibroService
    {
        private List<Libro> _libros;

        public LibroService()
        {
            _libros = new List<Libro>();
        }

        // 1. Agregar Libro
        public void AgregarLibro(Libro libro)
        {
            _libros.Add(libro);
        }

        // 2. Buscar Libro (Corregido para evitar Null Reference)
        public Libro? BuscarLibro(string criterio)
        {
            if (string.IsNullOrEmpty(criterio)) return null;

            return _libros.FirstOrDefault(l => 
                l.Id.ToString() == criterio || 
                (l.Titulo?.Contains(criterio, StringComparison.OrdinalIgnoreCase) ?? false)
            );
        }

        // 3. Obtener todos los libros
        public List<Libro> ObtenerTodos()
        {
            return _libros.OrderBy(l => l.Titulo).ToList();
        }

        // 4. Eliminar Libro
        public bool EliminarLibro(int id)
        {
            var libro = _libros.FirstOrDefault(l => l.Id == id);
            if (libro != null && libro.Disponible)
            {
                _libros.Remove(libro);
                return true;
            }
            return false;
        }

        // 5. Estadísticas rápidas
        public int TotalLibros() => _libros.Count;
        
        public int LibrosDisponibles() => _libros.Count(l => l.Disponible);
    }
}