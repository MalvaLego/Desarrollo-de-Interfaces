using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tema4Exercici1BIEN.Models
{
    public class TodoItem : INotifyPropertyChanged
    {
        private string _tarea;
        public string Tarea
        {
            get => _tarea;
            set
            {
                _tarea = value;
                OnPropertyChanged();
            }
        }
        private bool _completada;
        public bool Completada
        {
            get => _completada;
            set
            {
                _completada = value;
                OnPropertyChanged();
            }
        }

        public TodoItem(String tarea,bool completada)
        {
            Tarea = tarea;
            Completada = completada;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
