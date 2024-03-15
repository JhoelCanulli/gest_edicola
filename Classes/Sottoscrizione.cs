using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gest_edicola.Classes
{
    internal class Sottoscrizione
    {
        public Cliente Cliente { get; set; }
        public string? CodRivista { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }

        public Sottoscrizione(Cliente cliente, string? codRiv, DateTime dataInizio, DateTime dataFine)
        {
            Cliente = cliente;
            CodRivista = codRiv;
            DataInizio = dataInizio;
            DataFine = dataFine;
        }
    }
}
