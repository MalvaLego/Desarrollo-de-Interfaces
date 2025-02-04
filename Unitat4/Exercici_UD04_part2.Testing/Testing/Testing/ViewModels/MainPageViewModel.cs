using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Testing.Models;

namespace Testing.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private int _primerNumero;
        public int PrimerNumero
        {
            get => _primerNumero;
            set
            {
                _primerNumero = value;
                OnPropertyChanged();
            }
        }
        private int _segundoNumero;
        public int SegundoNumero
        {
            get => _segundoNumero;
            set
            {
                _segundoNumero = value;
                OnPropertyChanged();
            }
        }
        private String _resultado;
        public String Resultado
        {
            get => _resultado;
            set
            {
                _resultado = value;
                OnPropertyChanged();
            }
        }
        public ICommand SumarCommand { get; set; }
        public ICommand RestarCommand { get; set; }
        public ICommand MultiplicarCommand { get; set; }
        public ICommand DividirCommand { get; set; }

        public MainPageViewModel()
        {
            SumarCommand = new Command(Sumar);
            RestarCommand = new Command(Restar);
            MultiplicarCommand = new Command(Multiplicar);
            DividirCommand = new Command(Dividir);
        }

        private void Sumar()
        {
            int resultado=Operacions.Sumar(PrimerNumero,SegundoNumero);
            Resultado=resultado.ToString();
        }
        private void Restar()
        {
            int resultado = Operacions.Restar(PrimerNumero, SegundoNumero);
            Resultado = resultado.ToString();
        }
        private void Multiplicar()
        {
            int resultado = Operacions.Multiplicar(PrimerNumero, SegundoNumero);
            Resultado = resultado.ToString();
        }
        private async void Dividir()
        {          
            try
            {
                String resultado = Operacions.Dividir(PrimerNumero, SegundoNumero);
                Resultado = resultado;
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
