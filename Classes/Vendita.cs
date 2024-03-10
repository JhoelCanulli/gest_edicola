using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gest_edicola.Classes
{
    internal class Vendita
    {
        public string? CodicePubblicazione { get; set; }
        public int Quantita { get; set; }
        public double PrezzoTotale { get; set; }
        public DateTime DataVendita { get; set; }
        public string? Categoria { get; set; }
        public string? Titolo {  get; set; }

        public Vendita(string? codicePubblicazione, int quantita, double prezzoTotale, string? categoria, string? titolo)
        {
            CodicePubblicazione = codicePubblicazione;
            Quantita = quantita;
            PrezzoTotale = prezzoTotale;
            DataVendita = DateTime.Now; // Data corrente
            Categoria = categoria;
            Titolo = titolo;
        }
    }
}
