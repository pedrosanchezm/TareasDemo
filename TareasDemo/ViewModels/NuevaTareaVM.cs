using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using TareasDemo.Models;

namespace TareasDemo.ViewModels
{
    public class NuevaTareaVM
    {
        Tareas tareas;
        public NuevaTareaVM(Tareas tareas) : this()
        {
            this.tareas = tareas;
            if (tareas != null)
            {
                Name = tareas.Nombre;
                Notes = tareas.Notes;
                Completed = tareas.Finalizada;
            }
        }
        public NuevaTareaVM()
        {
            SaveCommand = new Command(GuardarTarea);

            DeleteCommand = new Command(EliminarTarea);

            UpdateCommand = new Command(ActualizarTarea);

            CancelCommand = new Command(CancelarTarea);
        }

        async void CancelarTarea()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        async void ActualizarTarea()
        {
            if (tareas != null)
            {
                tareas.Nombre = Name;
                tareas.Notes = Notes;
                tareas.Finalizada = Completed;
                var Repository = new Repositorio();
                var Result = await Repository.ActualizarTareaAsync(tareas);
                if (Result == 1)
                {
                    await Application.Current.MainPage.DisplayAlert
                         ("Mensaje", "Registro Modificado!", "Ok");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
        }

        async void EliminarTarea()
        {
            var Repository = new Repositorio();
            var Result = await Repository.EliminarTareaAsync(tareas);
            if (Result == 1)
            {
                await Application.Current.MainPage.DisplayAlert
                     ("Mensaje", "Registro Eliminado!", "Ok");
                await Application.Current.MainPage.Navigation.PopAsync();

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert
                    ("Mensaje", "No se pudo Eliminar!", "Ok");
            }
        }

        async void GuardarTarea()
        {
            var Repository = new Repositorio();
            var NuevaTarea = new Tareas();
            NuevaTarea.Nombre = Name;
            NuevaTarea.Notes = Notes;
            NuevaTarea.Finalizada = Completed;

            var Result = await Repository.GuardarTareaAsync(NuevaTarea);
            if (Result == 1)
            {
                await Application.Current.MainPage.DisplayAlert
                     ("Mensaje", "Registro guardado!", "Ok");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        #region Propiedades
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Completed { get; set; }
        #endregion

        #region Commands
        public Command SaveCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public Command CancelCommand { get; set; }
        #endregion

    }
}
