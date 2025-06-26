using System;
using System.ComponentModel;


namespace AppApuntesCamilySolorzano.Models
{
    public class Recordatorio 
    {
        public string Texto { get; set; }
        public TimeSpan FechaHora { get; set; }
        public bool Activo { get; set; }

    }
}