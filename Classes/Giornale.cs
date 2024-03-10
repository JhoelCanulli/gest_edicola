using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gest_edicola.Classes
{
    internal class Giornale : Pubblicazione
    {
        public string? Redazione { get; set; }
        public bool HasInserto { get; set; }
        public Giornale(string? redazione, bool hasInserto, double prezzo, string? codice, int quantita, string? titolo)
        {
            Redazione = redazione;
            HasInserto = hasInserto;
            Prezzo = prezzo;
            Codice = codice;
            QuantitaInStock = quantita;
            Titolo = titolo;
        }

        public override void stampaDettaglio()
        {
            Console.WriteLine($"[GIORNALE] Redazione: {Redazione}; Inserto: {HasInserto}; Prezzo: {Prezzo}; Codice: {Codice}; in Stock: {QuantitaInStock}");
        }

    }
}
