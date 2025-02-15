﻿using System.Collections.ObjectModel;
using System.Data.SQLite;

namespace SQLite03
{
    public partial class MainPage : ContentPage
    {
        private List<Trabajador> _trabajadorList= new List<Trabajador>();
        private ObservableCollection<Trabajador> _ocTrabajadores;
        public ObservableCollection<Trabajador> OcTrabajadores
        {
            get { return _ocTrabajadores;}
            set
            {
                _ocTrabajadores = value;
                OnPropertyChanged();
            }
        }
        private Trabajador _trabajadorSelected;
        public Trabajador TrabajadorSelected
        {
            get { return _trabajadorSelected; }
            set
            {
                _trabajadorSelected = value;
                OnPropertyChanged();
            }
        }
        public MainPage()
        {
            InitializeComponent();
            // Lista de los trabajadores
            OcTrabajadores = new ObservableCollection<Trabajador>();
      
            // Conexión con la base de datos
            string rutaDirectorioApp = System.AppContext.BaseDirectory;
            DirectoryInfo directorioApp = new DirectoryInfo(rutaDirectorioApp);    
            directorioApp = directorioApp.Parent.Parent.Parent.Parent.Parent.Parent;
            string databasePath = Path.Combine(directorioApp.FullName, "empresa.db");
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
               
                CrearTablaTrabajador(connection);
                InsertarDatosEjemplo(connection);
                
                connection.Close();
            }  
            BindingContext = this;
        }

        private void CrearTablaTrabajador(SQLiteConnection connection)
        {
            // Creamos la tabla Trabajador en caso de que no exista
            // Su clave principal es un autonumérico
            string queryCrearTablaTrabajador = "CREATE TABLE IF NOT EXISTS Trabajador (" +
                                     "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                     "nombre TEXT, " +
                                     "apellidos TEXT)";
            EjecutarNonQuery(connection, queryCrearTablaTrabajador);
        }


        private void InsertarDatosEjemplo(SQLiteConnection connection)
        {           
            // EjecutarNonQuery(connection, "insert into Trabajador (nombre, apellidos) values ('Juan', 'Pérez')");
        }

        private void EjecutarNonQuery(SQLiteConnection connection, string query)
        {
            // Este método ejecuta órdenes SQL que no devuelven consultas (Non-query command)

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void Anyadir(object sender, EventArgs e)
        {
            string nombre = etNombre.Text;
            string apellido = etApellido.Text;
         
                Trabajador nuevoTrabajador = new Trabajador
                {
                    Id = 0,
                    Nombre = nombre,
                    Apellidos = apellido
                };
                _trabajadorList.Add(nuevoTrabajador);
        }

        private void Actualizar(object sender, EventArgs e)
        {
            string rutaDirectorioApp = System.AppContext.BaseDirectory;
            DirectoryInfo directorioApp = new DirectoryInfo(rutaDirectorioApp);
            directorioApp = directorioApp.Parent.Parent.Parent.Parent.Parent.Parent;
            string databasePath = Path.Combine(directorioApp.FullName, "empresa.db");
            string connectionString = $"Data Source={databasePath};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                foreach (var trabajador in _trabajadorList)
                {
                    string queryInsert = $"INSERT INTO Trabajador (nombre, apellidos) VALUES ('{trabajador.Nombre}', '{trabajador.Apellidos}')";
                    EjecutarNonQuery(connection, queryInsert);

                    long ultimoId = connection.LastInsertRowId;
                    trabajador.Id = (int)ultimoId;

                    OcTrabajadores.Add(trabajador);
                }
                _trabajadorList.Clear();

                connection.Close();
            }            
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (TrabajadorSelected != null)
            {
                string rutaDirectorioApp = System.AppContext.BaseDirectory;
                DirectoryInfo directorioApp = new DirectoryInfo(rutaDirectorioApp);
                directorioApp = directorioApp.Parent.Parent.Parent.Parent.Parent.Parent;
                string databasePath = Path.Combine(directorioApp.FullName, "empresa.db");
                string connectionString = $"Data Source={databasePath};Version=3;";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
              
                    string queryDelete = "DELETE FROM Trabajador WHERE id = @id";
                    SQLiteCommand command = new SQLiteCommand(queryDelete, connection);
              
                    command.Parameters.AddWithValue("@id", TrabajadorSelected.Id);               

                    command.ExecuteNonQuery();
                }
                OcTrabajadores.Remove(TrabajadorSelected);

                TrabajadorSelected = null;
            }

        }



    }
}