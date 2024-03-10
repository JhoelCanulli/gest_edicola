using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gest_edicola.Classes
{
    internal abstract class Pubblicazione
    {
        public string? Codice { get; set; }
        public string? Titolo { get; set; }
        public DateTime DataPubblicazione { get; set; }
        public double Prezzo { get; set; } 

        public int QuantitaInStock;


        public abstract void stampaDettaglio();
    }

}
