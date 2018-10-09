using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using TareasDemo.Models;
using TareasDemo.Views;

namespace TareasDemo.ViewModels
{
    public class ListaDeTareasVM
    {
        public ListaDeTareasVM()
        {
            ObtenerTareas();
            AgregarTareaCommand = new Command
                (
               async () =>
               {
                   await Application.Current.MainPage.Navigation.PushAsync
                   (new NuevaTareaPage());
               }
                );
            MostrarDetallesCommand = new Command(MostrarDetalles);
        }

        async void MostrarDetalles()
        {
            await Application.Current.MainPage.Navigation.PushAsync
                     (new NuevaTareaPage()
                     {
                         BindingContext =
                     new NuevaTareaVM(tareaSeleccionada)
                     });
        }

        async void AgregarTarea()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NuevaTareaPage());
        }

        async void ObtenerTareas()
        {
            var Repositorio = new Repositorio();
            var Result = await Repositorio.ObtenerTareasAsync();
            tareas = new ObservableCollection<Tareas>(Result);

        }
        #region Properties
        public ObservableCollection<Tareas> tareas { get; set; }
        public Tareas tareaSeleccionada { get; set; }
        #endregion

        #region Command
        public Command AgregarTareaCommand { get; set; }
        public Command MostrarDetallesCommand { get; set; }
        #endregion

    }
}
