using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema4Exercici1BIEN.Models;
using Tema4Exercici1BIEN.Views;

namespace Tema4Exercici1BIEN.ViewModels
{
    public class AddItemNewWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TodoItem> Lista { get; set; }

        private string _nuevaTarea;
        public string NuevaTarea
        {
            get => _nuevaTarea;
            set
            {
                _nuevaTarea = value;
                OnPropertyChanged();
            }
        }
        private bool _completadaNueva;
        public bool CompletadaNueva
        {
            get => _completadaNueva;
            set
            {
                _completadaNueva = value;
                OnPropertyChanged();
            }
        }

        public ICommand AnyadirCommand { get; }
        public ICommand CancelarCommand { get; }

        public AddItemNewWindowViewModel()
        {            
            AnyadirCommand = new Command(Anyadir);
            CancelarCommand = new Command(Cancelar);
        }

        


        private async void Anyadir()
        {
            String nombre = NuevaTarea;
            bool check = CompletadaNueva;

            String tarea = nombre + "|" + check;
   
            await Shell.Current.GoToAsync($"//MainPage?Tarea={tarea}");
        }

        private async void Cancelar()
        {
            String tarea = "";

            await Shell.Current.GoToAsync($"//MainPage?Tarea={tarea}");
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
