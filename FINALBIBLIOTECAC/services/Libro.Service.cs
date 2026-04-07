using System;
using System.Collections.Generic;
using System.Linq; 
using ProyectoBibliotecaSENA.Models;

namespace ProyectoBibliotecaSENA.Services
{
    public class LibroService
    {
        private List<Libro> _libros = new List<Libro>();

        // Agregar un nuevo objeto a la lista
        public void AgregarLibro(Libro libro)
        {
            _libros.Add(libro);
        }

        // Obtener todos ordenados por título (Requisito Guía)
        public List<Libro> ObtenerTodos()
        {
            return _libros.OrderBy(l => l.Titulo).ToList();
        }

        // Buscar por ID o por Título
        public Libro BuscarLibro(string criterio)
        {
            return _libros.FirstOrDefault(l => 
                l.Id.ToString() == criterio || 
                l.Titulo.Contains(criterio, StringComparison.OrdinalIgnoreCase));
        }

        // Eliminar con validación de estado
        public bool EliminarLibro(int id)
        {
            var libro = _libros.FirstOrDefault(l => l.Id == id);
            if (libro != null)
            {
                if (libro.Disponible) 
                {
                    _libros.Remove(libro);
                    return true;
                }
            }
            return false;
        }

        // Métodos para KPIs (Estadísticas)
        public int TotalLibros() => _libros.Count;
        public int LibrosDisponibles() => _libros.Count(l => l.Disponible);
    }
}