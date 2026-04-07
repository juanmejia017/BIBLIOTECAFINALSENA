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

        // Buscar por ID del préstamo
        public Prestamo BuscarPorId(int id)
        {
            return _prestamos.FirstOrDefault(p => p.Id == id);
        }

        // Registrar devolución
        public bool FinalizarPrestamo(int id)
        {
            var prestamo = BuscarPorId(id);
            if (prestamo != null)
            {
                // Importante: Liberar el libro relacionado
                prestamo.LibroPrestado.Disponible = true;
                _prestamos.Remove(prestamo); // Opcional: podrías marcarlo como 'Cerrado'
                return true;
            }
            return false;
        }
    }
}