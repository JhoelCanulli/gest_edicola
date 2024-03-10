using gest_edicola.Classes;

namespace gest_edicola.Interfaces
{
    internal interface IEdicola
    {
        public void aggiungiP(Pubblicazione nuovaPub, int numStock);
        public bool rimuoviP(string codice);
        public bool aggiornaStock(string? codice, int nuovaQuantità);
        public void visualizzaP();
        public void effettuaVendita(string? codice, int quantitaVendite, string? categoria, string? titolo);
        public void visualizzaStoricoVendite(DateTime? data = null, string? titolo = null, string? categoria = null);
        public void cercaPubblicazioniTDC(string? titolo = null, DateTime? dataPubblicazione = null, string? tipoPubblicazione = null, string? categoria = null);
        public void cercaPubblicazionInStock();
        public bool cercaRivista(string? codice);
        public void cercaPubblicazioniGenericamente(string? stringaRicerca);
        public void aggiungiSottoscrizione(Sottoscrizione sottoscrizione);
        public bool cancellaSottoscrizione(Cliente cliente, Rivista rivista);
        public void visualizzaSottoscrizioni();
    }
}