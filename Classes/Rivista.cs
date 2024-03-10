using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gest_edicola.Classes
{
    internal class Rivista : Pubblicazione
    {
        public string? Categoria { get; set; }
        public Rivista(string? titolo, string? categoria, double prezzo, string? codice, int quantita) { 
            Titolo = titolo;
            Categoria = categoria;
            Prezzo = prezzo;    
            Codice = codice;
            QuantitaInStock = quantita;
        }

        public override void stampaDettaglio()
        {
            Console.WriteLine($"[RIVISTA]: Titolo: {Titolo}; Categoria: {Categoria}; Prezzo: {Prezzo}; Codice: {Codice}; in Stock: {QuantitaInStock}");

        }
    }
}
