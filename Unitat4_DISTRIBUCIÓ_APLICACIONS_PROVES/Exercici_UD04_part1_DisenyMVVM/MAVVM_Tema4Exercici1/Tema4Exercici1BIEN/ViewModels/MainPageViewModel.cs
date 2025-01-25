using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema4Exercici1BIEN.Models;
using Tema4Exercici1BIEN.Views;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tema4Exercici1BIEN.ViewModels
{
    [QueryProperty(nameof(Tarea), "Tarea")]
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TodoItem> Lista { get; set; }
        private string _tarea;
        public string Tarea
        {
            get => _tarea;
            set
            {
                _tarea = value;
                meterList();         
                OnPropertyChanged();
            }
        }

        public ICommand EliminarCommand { get; set; }
        public ICommand GoToAddCommand { get; set; }

        public void meterList()
        {
            if (Tarea != "")
            {
                string[] split = Tarea.Split("|");
                Debug.WriteLine(Tarea);
                string nombre = split[0];

                TodoItem item = null;
                if (split[1].Equals("True"))
                {
                    item = new TodoItem(nombre, true);
                    Lista.Add(item);
                }
                else if (split[1].Equals("False"))
                {
                    item = new TodoItem(nombre, false);
                    Lista.Add(item);
                }
            }            
                   
        }

        public MainPageViewModel()
        {
            Lista = new ObservableCollection<TodoItem>();
           

            GoToAddCommand = new Command (async () => await GoToAdd());
            EliminarCommand = new Command<TodoItem>(Eliminar);

            TodoItem item = null;

            Lista.Add(new TodoItem("Aprender .NET MAUI", false));
            Lista.Add(new TodoItem("Diseñar una aplicación con .NET MAUI", true));                   
        }

        private void Eliminar(TodoItem tarea)
        {
            if (tarea != null && Lista.Contains(tarea))
            {
                Lista.Remove(tarea);
                OnPropertyChanged(nameof(Lista));
            }
        }

        private async Task GoToAdd()
        {
            await Shell.Current.GoToAsync(nameof(AddItemNewWindow));
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
