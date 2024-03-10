using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using gest_edicola.Interfaces;

namespace gest_edicola.Classes
{
    internal class Edicola : IEdicola
    {
        public string? Nome { get; set; }
        public string? Indirizzo { get; set; }
        public List<Vendita> StoricoVendite { get; set; } = new List<Vendita>(); //aggregazione
        public List<Pubblicazione> Magazzino { get; set; } = new List<Pubblicazione>(); //aggregazione
        public List<Sottoscrizione> Sottoscrizioni { get; set; } = new List<Sottoscrizione>(); //aggregazione
        public List<Cliente> Clienti { get; set; } = new List<Cliente>();   //aggregazione

        public Edicola(string? nome, string indirizzo)
        {
            Nome = nome;
            Indirizzo = indirizzo;
        }

        public void aggiungiP(Pubblicazione nuovaPub, int numStock)
        {
            bool esiste = false;

            foreach (Pubblicazione p in Magazzino)
            {
                if (p.Codice == nuovaPub.Codice)
                {
                    p.QuantitaInStock += nuovaPub.QuantitaInStock;
                    esiste = true;
                    break;
                }
            }

            if (!esiste)
            {
                Magazzino.Add(nuovaPub);
            }
            else
            {
                Magazzino.Add(nuovaPub);
            }
        }

        public bool rimuoviP(string codice)
        {
            for (int i = 0; i < Magazzino.Count; i++)
            {
                Pubblicazione p = Magazzino[i];
                if (p.Codice == codice)
                {
                    p.QuantitaInStock--;
                    if (p.QuantitaInStock <= 0)
                    {
                        Magazzino.RemoveAt(i);
                    }
                    return true; 
                }
            }
            return false;
        }

        public bool aggiornaStock(string? codice, int nuovaQuantità)
        {
            foreach (Pubblicazione pub in Magazzino)
            {
                if (pub.Codice == codice) 
                {
                    pub.QuantitaInStock = nuovaQuantità;
                    return true; 
                }
            }
            return false; 
        }

        public void visualizzaP()
        {
            foreach(Pubblicazione pub in Magazzino)
            {
                pub.stampaDettaglio();
            }
        }

        public void effettuaVendita(string? codice, int quantitaVendite, string? categoria, string? titolo)
        {
            Pubblicazione? pubblicazioneDaVendere = null;
            foreach (Pubblicazione pubblicazione in Magazzino)
            {
                if (pubblicazione.Codice == codice)
                {
                    pubblicazioneDaVendere = pubblicazione; //temp aggiornata
                    break;
                }
            }

            if ((pubblicazioneDaVendere != null) && (pubblicazioneDaVendere.QuantitaInStock >= quantitaVendite))
            {
                pubblicazioneDaVendere.QuantitaInStock -= quantitaVendite; //la vendita consiste in un decremento di quantità nello stock della pubblicazione
                Vendita nuovaVendita = new Vendita(codice, quantitaVendite, pubblicazioneDaVendere.Prezzo * quantitaVendite, categoria, titolo);
                StoricoVendite.Add(nuovaVendita);
                Console.WriteLine("Vendita registrata con successo.");
            }
            else
            {
                Console.WriteLine("Quantità in stock insufficiente o pubblicazione non trovata.");
            }
        }

        public void visualizzaStoricoVendite(DateTime? data = null, string? titolo = null, string? categoria = null)
        {
            List<Vendita> venditeFiltrate = new List<Vendita>();
            foreach (Vendita vendita in StoricoVendite)
            {
                bool matchData = false;

                if (data == null)
                {
                    matchData = true; 
                }
                else if (vendita.DataVendita.Date == data.Value.Date)
                {
                    matchData = true;
                }

                bool matchTitolo = false;

                if (titolo == null)
                {
                    matchTitolo = true;
                }
                else if (vendita.Titolo != null && vendita.Titolo.ToLower() == titolo.ToLower())
                {
                    matchTitolo = true;
                }

                bool matchCategoria = false; 

                if (categoria == null)
                {
                    matchCategoria = true; 
                }
                else if (vendita.Categoria != null && vendita.Categoria.ToLower() == categoria.ToLower())
                {
                    matchCategoria = true; 
                }

                if (matchData && matchTitolo && matchCategoria)
                {
                    venditeFiltrate.Add(vendita);
                }
            }

            if (venditeFiltrate.Count > 0)
            {
                //int List<Vendite>.Count restituisce il numero di nodi in lista : verifico se è stato venduto qualcosa
                foreach (Vendita vendita in venditeFiltrate)
                {
                    Console.WriteLine($"Codice: {vendita.CodicePubblicazione}, Titolo: {vendita.Titolo}, Quantità: {vendita.Quantita}, Prezzo Totale: {vendita.PrezzoTotale}, Data: {vendita.DataVendita.ToShortDateString()}, Categoria: {vendita.Categoria}");
                }
            }
            else
            {
                Console.WriteLine("Nessuna vendita corrisponde ai criteri.");
            }
        }

        public void cercaPubblicazioniTDC(string? titolo = null, DateTime? dataPubblicazione = null, string? tipoPubblicazione = null, string? categoria = null)
        {
            List<Pubblicazione> risultatiRicerca = new List<Pubblicazione>();

            foreach (Pubblicazione pubblicazione in Magazzino)
            {
                bool corrispondeTitolo = false; 

                if (titolo == null)
                {
                    corrispondeTitolo = true; 
                }
                else if ((pubblicazione.Titolo != null) && (pubblicazione.Titolo.Equals(titolo, StringComparison.OrdinalIgnoreCase)))
                {
                    //cerca la corrispondenza del titolo ignorando le maiuscole e minuscole
                    corrispondeTitolo = true; 
                }

                bool corrispondeData = false; 

                if (dataPubblicazione == null)
                {
                    corrispondeData = true; 
                }
                else if (pubblicazione.DataPubblicazione.Date == dataPubblicazione.Value.Date)
                {
                    corrispondeData = true; 
                }


                bool corrispondeCategoria = true;

                //per Giornale
                if (tipoPubblicazione == "1" && !(pubblicazione is Rivista))
                {
                    if (categoria == null)
                    {
                        corrispondeCategoria = true;
                    }
                }

                //per Rivista
                if (tipoPubblicazione == "2" && pubblicazione is Rivista rivista)
                {
                        if (categoria == null)
                        {
                            corrispondeCategoria = true;
                        }
                        else if (rivista.Categoria != null && rivista.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                        {
                            corrispondeCategoria = true;
                        }                        
                }
                

                if (corrispondeTitolo && corrispondeData && corrispondeCategoria)
                {
                    risultatiRicerca.Add(pubblicazione);
                }
            }

            if (risultatiRicerca.Count > 0)
            {
                Console.WriteLine("Pubblicazioni trovate:");
                foreach (Pubblicazione pub in risultatiRicerca)
                {
                    pub.stampaDettaglio();
                }
            }
            else
            {
                Console.WriteLine("Nessuna pubblicazione corrisponde ai criteri di ricerca.");
            }
        }

        public void cercaPubblicazionInStock()
        {
            List<Pubblicazione> risultatiRicerca = new List<Pubblicazione>();   

            foreach(Pubblicazione pub in Magazzino)
            {
                bool corrispondeDisponibilitaStock = pub.QuantitaInStock > 0;
                if(corrispondeDisponibilitaStock)
                {
                    risultatiRicerca.Add(pub);
                }
            
            }
            if (risultatiRicerca.Count > 0)
            {
                Console.WriteLine("Pubblicazioni trovate:");
                foreach (Pubblicazione pubblicazione in risultatiRicerca)
                {
                    pubblicazione.stampaDettaglio();
                }
            }
            else
            {
                Console.WriteLine("Nessuna pubblicazione corrisponde ai criteri di ricerca.");
            }
        }

        public void cercaPubblicazioniGenericamente(string? stringaRicerca)
        {
            List<Pubblicazione> risultatiRicerca = new List<Pubblicazione>();
            DateTime dataRicerca;

            bool dataValida = DateTime.TryParse(stringaRicerca, out dataRicerca);

            foreach (Pubblicazione pub in Magazzino)
            {

                bool corrispondeTitoloOCategoria = false;

                if ((pub.Titolo != null) && (pub.Titolo.IndexOf(stringaRicerca, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    corrispondeTitoloOCategoria = true;
                }
                else if (pub is Rivista rivista) 
                {
                    if ((rivista.Categoria != null) && (rivista.Categoria.IndexOf(stringaRicerca, StringComparison.OrdinalIgnoreCase) >= 0))
                    {
                        corrispondeTitoloOCategoria = true;
                    }
                }

                bool corrispondeData = false; 

                if (dataValida) 
                {
                    if (pub.DataPubblicazione.Date == dataRicerca.Date)
                    {
                        corrispondeData = true;
                    }
                }


                if (corrispondeTitoloOCategoria || corrispondeData)
                {
                    risultatiRicerca.Add(pub);
                }
            }

            if (risultatiRicerca.Count > 0)
            {
                Console.WriteLine("Pubblicazioni trovate:");
                foreach (Pubblicazione pub in risultatiRicerca)
                {
                    pub.stampaDettaglio();
                }
            }
            else
            {
                Console.WriteLine("Non sono state trovate publicazioni inerenti alla stringa inserita.");
            }
        }

        public bool cercaRivista(string? codice)
        {
            foreach (Rivista riv in Magazzino)
                {
                    if (riv.Codice == codice)
                    {
                        return true;
                    }
                }
                return false;
            }

        public void aggiungiSottoscrizione(Sottoscrizione sottoscrizione)
        {
            throw new NotImplementedException();
        }

        public bool cancellaSottoscrizione(Cliente cliente, Rivista rivista)
        {
            throw new NotImplementedException();
        }

        public void visualizzaSottoscrizioni()
        {
            throw new NotImplementedException();
        }
    }
}
