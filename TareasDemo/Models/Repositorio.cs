using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TareasDemo.Models
{
    public class Repositorio
    {
        static SQLiteAsyncConnection DataBase;

        public Repositorio()
        {
            string DbFilePath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), "TareasDB.db");

            DataBase = new SQLiteAsyncConnection(DbFilePath);
            DataBase.CreateTableAsync<Tareas>().Wait();
        }

        //CRUD
        public Task<int> GuardarTareaAsync(Tareas tareas)
        {
            return DataBase.InsertAsync(tareas);
        }

        public Task<Tareas> ObtenerTareaPorIDAsync(int id)
        {
            return DataBase.Table<Tareas>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> ActualizarTareaAsync(Tareas tareas)
        {
            return DataBase.UpdateAsync(tareas);
        }

        public Task<int> EliminarTareaAsync(Tareas tareas)
        {
            return DataBase.DeleteAsync(tareas);
        }

        public Task<List<Tareas>> ObtenerTareasAsync()
        {
            return DataBase.Table<Tareas>().ToListAsync();
        }

        public Task<List<Tareas>> ObtenerTareasFiltrarPorID(int id)
        {
            return DataBase.QueryAsync<Tareas>($"SELECT * FROM [Tareas] WHERE [ID] = {id}");
        }
    }
}
