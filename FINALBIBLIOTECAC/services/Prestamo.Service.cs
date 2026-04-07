using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoBibliotecaSENA.Models;

namespace ProyectoBibliotecaSENA.Services
{
    public class PrestamoService
    {
        private List<Prestamo> _prestamos = new List<Prestamo>();

        // Registrar el préstamo en la lista
        public void RegistrarPrestamo(Prestamo prestamo)
        {
            _prestamos.Add(prestamo);
        }

        public List<Prestamo> ObtenerTodos() => _prestamos;

        // 1. Corregido: Agregado '?' para permitir retorno nulo
        public Prestamo? BuscarPorId(int id)
        {
            return _prestamos.FirstOrDefault(p => p.Id == id);
        }

        // Registrar devolución
        public bool FinalizarPrestamo(int id)
        {
            var prestamo = BuscarPorId(id);
            
            // 2. Corregido: Validación de nulo para el objeto préstamo y sus propiedades
            if (prestamo != null && prestamo.LibroPrestado != null)
            {
                // Importante: Liberar el libro relacionado
                prestamo.LibroPrestado.Disponible = true;
                _prestamos.Remove(prestamo); 
                return true;
            }
            return false;
        }
    }
}