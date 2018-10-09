using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace TareasDemo.Models
{
    [Table("T_Tareas")]
    public class Tareas
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        [MaxLength (200)]
        public string Notes { get; set; }
        public bool Finalizada { get; set; }
    }
}
