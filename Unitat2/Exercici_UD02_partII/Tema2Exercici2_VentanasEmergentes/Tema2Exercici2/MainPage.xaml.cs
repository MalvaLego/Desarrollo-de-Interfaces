﻿using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace Tema2Exercici2
{
    //[QueryProperty(nameof(Contador), "count")]
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        int _count = 0;
        public int Contador
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged(nameof(Contador));
                }
            }
        }
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void btnComprobar(object sender, EventArgs e)
        { 
            Contador = 0;

            if (entry1.Text=="A") { Contador += 1; }
            if (entry2.Text == "A") { Contador += 1; }
            if (entry3.Text == "A") { Contador += 1; }

            bool answer = await DisplayAlert("Avanzados", "¿Quieres ver el número de idiomas a nivel avanzado?", "Yes", "No");

            if (answer)
            {
                tvNumeroIdiomas.Text = "Idiomas a nivel avanzado: " + _count;
            }        
        }

        private async void btnInsertar1(object sender, EventArgs e)
        {
            
            string result = await DisplayPromptAsync("Nivel de Valenciano", "¿Qué nivel tienes?");
            
            entry1.Text = result; 
            await Task.Delay(100);

        }

        private async void btnInsertar2(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("¿Qúé nivel de inglés tienes?", "Cancel", null, "A", "M", "B");       
            if (action == "Cancel")
            {
                entry2.Text = " ";
            }
            else { entry2.Text = action; }
        }

        private async void btnInsertar3(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("¿Qué nivel de francés tienes?", "Cancel", "Delete", "A", "M", "B");
            if (action=="Delete")
            {
                entry3.Text = " ";
            }
            else { entry3.Text = action; }
        }


        private async void btnCreditos(object sender, EventArgs e)
        {
            await DisplayAlert("Créditos", "Aplicación realizada por N.C.R", "OK");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }

}


