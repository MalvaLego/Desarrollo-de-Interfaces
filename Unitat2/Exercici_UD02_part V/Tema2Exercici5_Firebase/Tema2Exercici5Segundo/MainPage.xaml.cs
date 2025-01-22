using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Tema2Exercici5Segundo
{
    public partial class MainPage : ContentPage
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://exercici5tema2-default-rtdb.europe-west1.firebasedatabase.app/");
        public ObservableCollection<Tasca> Tasques { get; set; } = new ObservableCollection<Tasca>();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            SubscriureAFirebase(); 
        }

        private void SubscriureAFirebase()
        {
            var collection = firebaseClient
                .Child("Tasques")
                .AsObservable<Tasca>()
                .Subscribe((item) =>
                {
                    if (item.Object != null)
                    {
                        if (item.EventType == Firebase.Database.Streaming.FirebaseEventType.Delete)
                        {
                            var deletedItem = Tasques.FirstOrDefault(t => t.IdTarea == item.Key);
                            if (deletedItem != null)
                            {
                                Tasques.Remove(deletedItem);
                            }
                        }
                        else
                        {
                            var existingItem = Tasques.FirstOrDefault(t => t.IdTarea == item.Key);
                            if (existingItem == null)
                            {
                                Tasques.Add(new Tasca
                                {
                                    NombreTarea = item.Object.NombreTarea,
                                    IdTarea = item.Key
                                });
                            }
                            else
                            {
                                existingItem.NombreTarea = item.Object.NombreTarea;
                            }
                        }
                    }
                });
        }


        private void btnAnyadir(object sender, EventArgs e)
        {
            if (eNombreTarea.Text != null)
            {
                Tasca tasca = new Tasca
                {
                    IdTarea = string.Empty,
                    NombreTarea = eNombreTarea.Text,
                };

                string key = firebaseClient.Child("Tasques").PostAsync(tasca).Result.Key;
                if (key != null)
                {
                    firebaseClient.Child("Tasques").Child(key).PutAsync(
                    new Tasca
                    {
                        IdTarea = key,
                        NombreTarea = tasca.NombreTarea
                    });
                }
                eNombreTarea.Text = string.Empty;
            }
        }


        private void btnMostrarSeleccion(object sender, EventArgs e)
        {
            Tasca itemSeleccionado = cvTareas.SelectedItem as Tasca;
            if (itemSeleccionado != null)
            {
                // Mostra el nom de la tasca seleccionada al Entry
                eNombreTarea.Text = itemSeleccionado.NombreTarea;
                Debug.WriteLine($"Tasca seleccionada: {itemSeleccionado.NombreTarea}");
            }
        }
        private void btnModificar(object sender, EventArgs e)
        {
            Tasca itemSeleccionado = cvTareas.SelectedItem as Tasca;
            if (itemSeleccionado != null)
            {
                var collection = firebaseClient
                .Child("Tasques").Child(itemSeleccionado.IdTarea).PutAsync(
                    new Tasca
                    {
                        IdTarea = itemSeleccionado.IdTarea,
                        NombreTarea = eNombreTarea.Text
                    });
            }
            eNombreTarea.Text = string.Empty;

        }
        private void btnBorrar(object sender, EventArgs e)
        {
            Tasca itemSeleccionado = cvTareas.SelectedItem as Tasca;
            if (itemSeleccionado != null)
            {
                var collection = firebaseClient
                //Esborra l'item de Firebase amb la clau itemseleccionado.id
                .Child("Tasques").Child(itemSeleccionado.IdTarea).DeleteAsync();
            }
            eNombreTarea.Text = string.Empty;
        }
    }
}
