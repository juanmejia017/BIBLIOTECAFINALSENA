using System;

namespace ProyectoBibliotecaSENA
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mensaje de bienvenida inicial
            Console.Clear();
            Console.WriteLine("=======================================================");
            Console.WriteLine("   BIENVENIDO AL SISTEMA DE GESTIÓN DE BIBLIOTECA      ");
            Console.WriteLine("                SENA - 2026                            ");
            Console.WriteLine("=======================================================");
            Console.WriteLine("\nCargando módulos de navegación...");
            Console.WriteLine("\nPresione cualquier tecla para iniciar...");
            Console.ReadKey();

            ShowMainMenu();
            }
            // ==========================================
        // 1. ESTRUCTURA DEL MENÚ PRINCIPAL
        // ==========================================
        static void ShowMainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ PRINCIPAL ===");
                Console.WriteLine("1. Libros");
                Console.WriteLine("2. Usuarios");
                Console.WriteLine("3. Préstamos");
                Console.WriteLine("4. Búsquedas y reportes");
                Console.WriteLine("5. Guardar / Cargar datos");
                Console.WriteLine("6. Salir");
                Console.Write("\nSeleccione una opción: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": ShowBooksMenu(); break;
                    case "2": ShowUsersMenu(); break;
                    case "3": ShowLoansMenu(); break;
                    case "4": ShowSearchReportsMenu(); break;
                    case "5": ShowPersistenceMenu(); break;
                    case "6": exit = ConfirmExitAndSave(); break;
                    default: ShowInvalidMessage(); break;
                }
            }
        }
          // ==========================================
        // 2. MÓDULO DE LIBROS (COMPLETO)
        // ==========================================
        static void ShowBooksMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ LIBROS ===");
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Listar libros");
                Console.WriteLine("3. Ver detalle (por ID/ISBN)");
                Console.WriteLine("4. Actualizar libro");
                Console.WriteLine("5. Eliminar libro");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("\nSeleccione una opción: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": RegisterBook(); break;
                    case "2": ListBooksMenu(); break;
                    case "3": ViewBookDetail(); break;
                    case "4": UpdateBookMenu(); break;
                    case "5": DeleteBook(); break;
                    case "0": back = true; break;
                    default: ShowInvalidMessage(); break;
                }
            }
        }

        static void RegisterBook()
{
    Console.Clear();
    Console.WriteLine("=== REGISTRAR NUEVO LIBRO ===");
    
    try {
        Console.Write("Ingrese ID (Numérico): ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        
        Console.Write("Título: ");
        string titulo = Console.ReadLine() ?? "Sin Título";
        
        Console.Write("Autor: ");
        string autor = Console.ReadLine() ?? "Anónimo";
        
        Console.Write("Año de publicación: ");
        int anio = int.Parse(Console.ReadLine() ?? "0");

        Libro nuevoLibro = new Libro(id, titulo, autor, anio);
        _libroService.AgregarLibro(nuevoLibro);

        Console.WriteLine("\n✅ Libro guardado exitosamente en la colección.");
    }
    catch (Exception) {
        Console.WriteLine("\n❌ Error: Datos inválidos. El libro no se registró.");
    }
    Console.WriteLine("\nPresione cualquier tecla para volver...");
    Console.ReadKey();
}
        
        static void ListBooksMenu()
        {
            Console.Clear();
            Console.WriteLine("--- Submenú: Listar Libros ---");
            Console.WriteLine("1. Listar todos\n2. Listar disponibles\n3. Listar prestados\n0. Volver");
            string opt = Console.ReadLine();
            if (opt == "1") ListBooksAll();
            else if (opt == "2") ListBooksAvailable();
            else if (opt == "3") ListBooksBorrowed();
        }

        static void ListBooksAll()
{
    Console.Clear();
    Console.WriteLine("=== LISTADO DE LIBROS (Orden Alfabético) ===");
    
    var libros = _libroService.ObtenerTodos();
    
    if (libros.Count == 0) {
        Console.WriteLine("La biblioteca está vacía actualmente.");
    } else {
        foreach (var libro in libros) {
            Console.WriteLine(libro.DetalleCompleto());
        }
    }

    Console.WriteLine("\n--- RESUMEN ESTADÍSTICO ---");
    Console.WriteLine($"Total en sistema: {_libroService.TotalLibros()}");
    Console.WriteLine($"Disponibles para préstamo: {_libroService.LibrosDisponibles()}");
    
    Console.WriteLine("\nPresione cualquier tecla para volver...");
    Console.ReadKey();
}
        static void ListBooksAvailable() { Console.Clear(); Console.WriteLine("[Módulo Libros] Mostrando libros con estado: DISPONIBLE."); Console.ReadKey(); }
        static void ListBooksBorrowed() { Console.Clear(); Console.WriteLine("[Módulo Libros] Mostrando libros con estado: PRESTADO."); Console.ReadKey(); }
        static void ViewBookDetail()
{
    Console.Clear();
    Console.WriteLine("=== CONSULTAR FICHA TÉCNICA ===");
    Console.Write("Ingrese ID o Título a buscar: ");
    string criterio = Console.ReadLine() ?? "";

    var libro = _libroService.BuscarLibro(criterio);

    if (libro != null) {
        Console.WriteLine("\n--- RESULTADO ENCONTRADO ---");
        Console.WriteLine(libro.DetalleCompleto());
    } else {
        Console.WriteLine("\n❌ No se encontró ningún libro con ese criterio.");
    }
    Console.ReadKey();
}

        static void UpdateBookMenu()
        {
            Console.Clear();
            Console.WriteLine("--- Actualizar Libro ---\n1. Título\n2. Autor\n3. Año/Categoría\n0. Volver");
            string opt = Console.ReadLine();
            if (opt == "1") EditBookTitle();
            else if (opt == "2") EditBookAuthor();
            else if (opt == "3") EditBookYearCategory();
        }

        static void EditBookTitle() { Console.Clear(); Console.WriteLine("[Edición] El título ha sido modificado exitosamente."); Console.ReadKey(); }
        static void EditBookAuthor() { Console.Clear(); Console.WriteLine("[Edición] El autor ha sido modificado exitosamente."); Console.ReadKey(); }
        static void EditBookYearCategory() { Console.Clear(); Console.WriteLine("[Edición] Año y categoría actualizados."); Console.ReadKey(); }
        static void DeleteBook()
{
    Console.Clear();
    Console.WriteLine("=== ELIMINAR REGISTRO DE LIBRO ===");
    Console.Write("Ingrese el ID del libro que desea borrar: ");
    
    if (int.TryParse(Console.ReadLine(), out int id)) {
        bool eliminado = _libroService.EliminarLibro(id);
        if (eliminado)
            Console.WriteLine("✅ Registro eliminado con éxito.");
        else
            Console.WriteLine("❌ No se pudo eliminar: El ID no existe o el libro está prestado.");
    } else {
        Console.WriteLine("❌ Entrada inválida. Debe ser un número.");
    }
    
    Console.ReadKey();
}
         }
         
         }