using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoBibliotecaSENA.Models;

namespace ProyectoBibliotecaSENA.Services
{
    public class UsuarioService
    {
        private List<Usuario> _usuarios = new List<Usuario>();

        // Agregar usuario
        public void RegistrarUsuario(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        // Obtener todos los usuarios
        public List<Usuario> ObtenerTodos()
        {
            return _usuarios.OrderBy(u => u.Nombre).ToList();
        }

        // 1. Corregido: '?' para permitir retorno nulo y protección en la búsqueda
        public Usuario? BuscarUsuario(string criterio)
        {
            if (string.IsNullOrEmpty(criterio)) return null;

            return _usuarios.FirstOrDefault(u => 
                u.Id.ToString() == criterio || 
                (u.Nombre?.Contains(criterio, StringComparison.OrdinalIgnoreCase) ?? false));
        }

        // Eliminar usuario
        public bool EliminarUsuario(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _usuarios.Remove(usuario);
                return true;
            }
            return false;
        }

        public int TotalUsuarios() => _usuarios.Count;
    }
}