using System.Collections.Generic;
using System.Linq;
using ProyectoBibliotecaSENA.Models;

namespace ProyectoBibliotecaSENA.Services
{
    public class PrestamoService
    {
        private List<Prestamo>prestamos = new List<Prestamo>();
        public void RegistrarPrestamo(Prestamo p)=>prestamos.Add(p);
        //Busqueda ID
        public Prestamo? BuscarPorId(int id) => prestamos.FirstOrDefault(p => p.Id == id);

        //KPI
        public int TotalPrestamos() => prestamos.Count;
        public int PrestamosActivos() => prestamos.Count(p=>p.Estado == EstadoPrestamo.Activo);
        public int PrestamosVencidos() =>  prestamos.Count(p=>p.EstaVencido());
        public double PromedioDiasPrestamo()=> prestamos.Any()?prestamos.Average(p=>p.DiasTranscurridos()):0;

    }

}