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

        static void RegisterBook() { Console.Clear(); Console.WriteLine("[Módulo Libros] Iniciando registro de nuevo ejemplar. Validando ISBN..."); Console.ReadKey(); }
        
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

        static void ListBooksAll() { Console.Clear(); Console.WriteLine("[Módulo Libros] Mostrando catálogo completo de la biblioteca."); Console.ReadKey(); }
        static void ListBooksAvailable() { Console.Clear(); Console.WriteLine("[Módulo Libros] Mostrando libros con estado: DISPONIBLE."); Console.ReadKey(); }
        static void ListBooksBorrowed() { Console.Clear(); Console.WriteLine("[Módulo Libros] Mostrando libros con estado: PRESTADO."); Console.ReadKey(); }
        static void ViewBookDetail() { Console.Clear(); Console.WriteLine("[Módulo Libros] Consultando ficha técnica del ejemplar seleccionado."); Console.ReadKey(); }

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
        static void DeleteBook() { Console.Clear(); Console.WriteLine("[Validación] Validar no permitir eliminación si el libro está prestado."); Console.ReadKey(); }
        
         
        // ==========================================
        // 3. MÓDULO DE USUARIOS (COMPLETO)
        // ==========================================
        static void ShowUsersMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("=== MENÚ USUARIOS ===");
                Console.WriteLine("1. Registrar usuario\n2. Listar usuarios\n3. Ver detalle\n4. Actualizar usuario\n5. Eliminar usuario\n0. Volver");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": RegisterUser(); break;
                    case "2": ListUsers(); break;
                    case "3": ViewUserDetail(); break;
                    case "4": UpdateUserMenu(); break;
                    case "5": DeleteUser(); break;
                    case "0": back = true; break;
                    default: ShowInvalidMessage(); break;
                }
            }
        }

        static void RegisterUser() { Console.Clear(); Console.WriteLine("[Módulo Usuarios] Registrando nuevo usuario en el sistema."); Console.ReadKey(); }
        static void ListUsers() { Console.Clear(); Console.WriteLine("[Módulo Usuarios] Mostrando listado de socios activos e inactivos."); Console.ReadKey(); }
        static void ViewUserDetail() { Console.Clear(); Console.WriteLine("[Módulo Usuarios] Consultando datos de contacto y préstamos del usuario."); Console.ReadKey(); }

        static void UpdateUserMenu()
        {
            Console.Clear();
            Console.WriteLine("--- Actualizar Usuario ---\n1. Nombre\n2. Contacto\n3. Activar/Desactivar\n0. Volver");
            string opt = Console.ReadLine();
            if (opt == "1") EditUserName();
            else if (opt == "2") EditUserContact();
            else if (opt == "3") ToggleUserActiveStatus();
        }

        static void EditUserName() { Console.Clear(); Console.WriteLine("[Edición] Nombre de usuario actualizado."); Console.ReadKey(); }
        static void EditUserContact() { Console.Clear(); Console.WriteLine("[Edición] Datos de contacto actualizados."); Console.ReadKey(); }
        static void ToggleUserActiveStatus() { Console.Clear(); Console.WriteLine("[Estado] El estado de actividad del usuario ha sido cambiado."); Console.ReadKey(); }
        static void DeleteUser() { Console.Clear(); Console.WriteLine("[Validación] Validar no permitir si el usuario tiene préstamos activos."); Console.ReadKey(); }
}


}