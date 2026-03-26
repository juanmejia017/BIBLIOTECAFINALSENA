using System.Collections.Generic;
using System.Linq;
using ProyectoBibliotecaSENA.Models;

namespace ProyectoBibliotecaSENA
{
    public class UsuarioService
    { 
        private List<Usuario> usuarios = new List<Usuario>();
        public void AgregarUsuario(Usuario usuario) =>usuarios.Add(usuario);
        public List<Usuario> ObtenerTodos()=>usuarios;
        public Usuario ? BuscarDocumento(string doc)=> usuarios.Find(u =>u.Documento==doc);
        public void OrdenarPorNombre()=>usuarios=usuarios.OrderBy(u=>u.Nombre).ToList();

        //KPIS
        public int TotalUsuarios()=>usuarios.Count;
        public int UsuariosActivos ()=>usuarios.Count(u => u.Activo);
        

    }
}