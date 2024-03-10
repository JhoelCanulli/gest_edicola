using gest_edicola.Classes;

namespace gest_edicola
{
    using System;
    using System.Data;
    using System.Reflection.Metadata.Ecma335;

    internal class Program
    {
        static void Main(string[] args)
        {
            Edicola edicola = new Edicola("Edicola Centrale", "Via Roma 123");
            string? opzione = null;
            string? tipoPubblicazione = null;
            string? codice = null;
            string? redazione = null;
            string? scelta_locale = null;
            string? titolo = null;
            string? categoria = null;
            string? codiceRimuovere = null;
            string? codiceDaAggiornare = null;
            string? codiceVendita = null;
            string? dataInput = null;
            string? filtrareDataInput = null;
            string? filtrareTitoloInput = null;
            string? titoloFiltro = null;
            string? filtrareCategoriaInput = null;
            string? categoriaFiltro = null;
            string? stringaRicerca = null;
            string? codiceRivista = null;
            string? nomeCliente = null;
            string? emailCliente = null;
            DateTime? dataFiltro = null;
            DateTime dataInizio; 
            DateTime dataFine; 
            int nCount;
            int numStock;
            int inputQuantita;
            int inputQuantitaVendita;
            bool hasInserto;
            bool isLetteraCorretta;
            bool isVendi;
            bool isDataCorretta;
            bool isCodiceValido;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Benvenuto nell'Edicola: " + edicola.Nome);
                Console.WriteLine("1. Aggiungi pubblicazione");
                Console.WriteLine("2. Rimuovi pubblicazione");
                Console.WriteLine("3. Aggiorna stock pubblicazione");
                Console.WriteLine("4. Visualizza pubblicazioni");
                Console.WriteLine("5. Effettua vendita");
                Console.WriteLine("6. Visualizza storico vendite");
                Console.WriteLine("7. Ricerca Pubblicazioni");
                Console.WriteLine("8. Aggiungi sottoscrizione");
                Console.WriteLine("q. Esci");
                Console.Write("Seleziona un'opzione:\n>");

                opzione = Console.ReadLine();

                switch (opzione)
                {
                    case "1":
                        //Aggiunta pubblicazione
                        Console.WriteLine("Aggiungere [1] Giornale o [2] Rivista:\n>");
                        tipoPubblicazione = Console.ReadLine();
                        if((tipoPubblicazione == "1") || (tipoPubblicazione == "2")) 
                        {
                            Console.Write("Inserire il codice di pubblicazione:\n>");
                            codice = Console.ReadLine();
                            Console.Write("Inserire il prezzo di pubblicazione:\n>");
                            double prezzo = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Inserire la quantita in stock pubblicazione:\n>");
                            numStock = Convert.ToInt32(Console.ReadLine());

                            if (tipoPubblicazione == "1") // Giornale
                            {
                                Console.Write("Inserire la redazione del giornale:\n>");
                                redazione = Console.ReadLine();
                                Console.Write(("Inserire il titolo del giornale:\n>"));
                                titolo = Console.ReadLine();

                                isLetteraCorretta = false;
                                while (!isLetteraCorretta)
                                {
                                    Console.Write("Ha un inserto? (s/n):\n>");
                                    scelta_locale = Console.ReadLine();
                                    if ((scelta_locale != "s") || (scelta_locale != "n"))
                                    {   isLetteraCorretta = true;
                                        if (scelta_locale == "s")
                                        {
                                            hasInserto = true;
                                            edicola.aggiungiP(new Giornale(redazione, hasInserto, prezzo, codice, numStock, titolo), numStock);
                                        }
                                        else if(scelta_locale == "n")
                                        {
                                            hasInserto = false;
                                            edicola.aggiungiP(new Giornale(redazione, hasInserto, prezzo, codice, numStock, titolo), numStock);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Scelta non valida");
                                    }
                                }
                                Console.WriteLine("Giornale aggiunto con successo.");
                            }
                            else if (tipoPubblicazione == "2") // Rivista
                            {
                                Console.Write("Inserire il titolo della rivista:\n>");
                                titolo = Console.ReadLine();
                                Console.Write("Inserire la categoria della rivista:\n>");
                                categoria = Console.ReadLine();
                                edicola.aggiungiP(new Rivista(titolo, categoria, prezzo, codice, numStock), numStock);
                                Console.WriteLine("Rivista aggiunta con successo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Scelta non valida.");
                        }
                        break;
                    case "2":
                        //Rimozione pubblicazione
                        Console.Write("Inserire il codice della pubblicazione da rimuovere:\n>");
                        edicola.visualizzaP();
                        codiceRimuovere = Console.ReadLine();

                        if (edicola.rimuoviP(codiceRimuovere))
                        {
                            Console.WriteLine("Pubblicazione rimossa con successo.");
                        }
                        else
                        {
                            Console.WriteLine("Pubblicazione non trovata.");
                        }
                        break;

                    case "3":
                        //Aggiornamento stock
                        Console.Write("Inserire il codice della pubblicazione da aggiornare:\n>");
                        edicola.visualizzaP();
                        codiceDaAggiornare = Console.ReadLine();

                        Console.Write("Inserire la nuova quantità in stock:\n>");
                        inputQuantita = Convert.ToInt32(Console.ReadLine());

                        if (edicola.aggiornaStock(codiceDaAggiornare, inputQuantita))
                        {
                            Console.WriteLine("Stock aggiornato con successo.");
                        }
                        else
                        {
                            Console.WriteLine("Pubblicazione non trovata.");
                        }
                        break;
                    case "4":
                        //Visualizza pubblicazioni
                        edicola.visualizzaP();
                        Console.WriteLine("Premere un tasto per continuare...");
                        Console.ReadKey();
                        break;
                    case "5":
                        //Effettua vendita
                        isVendi = true;
                        while (isVendi)
                        {
                            edicola.visualizzaP();
                            Console.Write("Inserire il tipo della pubblicazione da vendere [1] Giornale o una [2] Rivista:\n>");
                            tipoPubblicazione = Console.ReadLine();
                            if ((tipoPubblicazione == "1") || (tipoPubblicazione == "2"))
                            {
                                Console.Write("Inserisci il codice della pubblicazione da vendere:\n> ");
                                codiceVendita = Console.ReadLine();

                                Console.Write("Inserisci il titolo della pubblicazione da vendere:\n>");
                                titolo = Console.ReadLine();

                                Console.Write("Inserisci la quantità da vendere:\n>");
                                inputQuantitaVendita = Convert.ToInt32(Console.ReadLine());

                                edicola.effettuaVendita(codiceVendita, inputQuantitaVendita, tipoPubblicazione, titolo);
                                isLetteraCorretta = false;
                                while (!isLetteraCorretta)
                                {
                                    Console.Write("Vendere altro? (s/n):\n>");
                                    scelta_locale = Console.ReadLine();
                                    if ((scelta_locale == "s") || (scelta_locale == "n"))
                                    {
                                        if (scelta_locale == "n")
                                        {
                                            isVendi = false;
                                        }
                                        isLetteraCorretta = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Scelta non valida");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Scelta non valida.");
                            }

                        }            
                        break;
                    case "6":
                        //Mostra storico vendite
                        Console.WriteLine("Visualizza storico vendite");
                        nCount = 0;
                        Console.Write("Filtrare per data? (s/n):\n>");
                        filtrareDataInput = Console.ReadLine();
                        dataFiltro = null;
                        if (filtrareDataInput != null && filtrareDataInput.ToLower() == "s")
                        {
                            isDataCorretta = false;
                            while (!isDataCorretta)
                            {
                                Console.Write("Inserire la data (formato AAAA-MM-GG):\n>");
                                dataInput = Console.ReadLine();
                                try
                                {
                                    dataFiltro = DateTime.Parse(dataInput); //tentativo di conversione input utente in una data
                                    isDataCorretta = true; //conversione andata a buon fine
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato data non valido. Riprova.");
                                }
                            }
                        }
                        else
                        {
                            nCount++;
                        }

                        Console.Write("Filtrare per titolo? (s/n):\n>");
                        filtrareTitoloInput = Console.ReadLine();
                        titoloFiltro = null;
                        if (filtrareTitoloInput != null && filtrareTitoloInput.ToLower() == "s")
                        {
                            Console.Write("Inserire il titolo:\n>");
                            titoloFiltro = Console.ReadLine();
                        }
                        else
                        {
                            nCount++;
                        }

                        Console.Write("Filtrare per categoria? (s/n):\n>");
                        filtrareCategoriaInput = Console.ReadLine();
                        categoriaFiltro = null;
                        if (filtrareCategoriaInput != null && filtrareCategoriaInput.ToLower() == "s")
                        {
                            Console.Write("Inserire la categoria:\n>");
                            categoriaFiltro = Console.ReadLine();
                        }
                        else
                        {
                            {
                                nCount++;
                            }
                        }

                        if (nCount < 3)
                        {
                            //Invocazione metodo con i filtri applicati
                            edicola.visualizzaStoricoVendite(dataFiltro, titoloFiltro, categoriaFiltro);
                        }
                        else if (nCount == 3)
                        {
                            Console.WriteLine("Inserire almeno un filtro per la ricerca.");
                        }                 

                        Console.Write("Premere un tasto per continuare\n>");
                        Console.ReadKey();
                        break;
                    case "7":
                        //Ricerca pubblicazioni
                        Console.WriteLine("Ricerca pubblicazioni");

                        isLetteraCorretta = false;
                        while (!isLetteraCorretta)
                        {
                            Console.WriteLine("Digitare il filtro di ricerca: ");
                            Console.WriteLine("1. [ titolo ] o [ data ] o [ categoria ]");
                            Console.WriteLine("2. [ disponibilità di stock ]");
                            Console.WriteLine("3. [ ricerca libera ]");
                            Console.WriteLine("e. esci dal filtro di ricerca");
                            scelta_locale = Console.ReadLine();
                            switch (scelta_locale)
                            {
                                case "1":
                                    //ricerca per titolo or data or categoria
                                    nCount = 0;
                                    Console.Write("Filtrare per titolo? (s/n):\n>");
                                    filtrareTitoloInput = Console.ReadLine();
                                    titoloFiltro = null;

                                    if (filtrareTitoloInput != null && filtrareTitoloInput.ToLower() == "s")
                                    {
                                        Console.Write("Inserire il titolo:\n>");
                                        titoloFiltro = Console.ReadLine();
                                    }
                                    else
                                    {
                                        nCount++;
                                    }

                                    Console.Write("Filtrare per data? (s/n):\n>");
                                    filtrareDataInput = Console.ReadLine();
                                    dataFiltro = null;
                                    if (filtrareDataInput != null && filtrareDataInput.ToLower() == "s")
                                    {
                                        isDataCorretta = false;
                                        while (!isDataCorretta)
                                        {
                                            Console.Write("Inserire la data (formato AAAA-MM-GG):\n>");
                                            dataInput = Console.ReadLine();
                                            try
                                            {
                                                dataFiltro = DateTime.Parse(dataInput); //tentativo di conversione input utente in una data
                                                isDataCorretta = true; //conversione andata a buon fine
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Formato data non valido. Riprova.");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        nCount++;
                                    }

                                    Console.Write("Filtrare per categoria? (s/n):\n>");
                                    filtrareCategoriaInput = Console.ReadLine();
                                    categoriaFiltro = null;

                                    if (filtrareCategoriaInput != null && filtrareCategoriaInput.ToLower() == "s")
                                    {
                                        isLetteraCorretta = false;
                                        while (!isLetteraCorretta)
                                        {
                                            Console.Write("Digitare [1] Giornale o [2] Rivista:\n>");
                                            tipoPubblicazione = Console.ReadLine();
                                            if (tipoPubblicazione != "1" && tipoPubblicazione != "2")
                                            {
                                                Console.WriteLine("Scelta non valida.");
                                            }
                                            else
                                            {
                                                isLetteraCorretta = true;
                                            }
                                        }
                                        if (tipoPubblicazione == "1") categoriaFiltro = tipoPubblicazione;   //Giornale
                                        if (tipoPubblicazione == "2")   //Rivista
                                        {
                                            Console.Write("Inserire la categoria della rivista:\n>");
                                            categoriaFiltro = Console.ReadLine();
                                        }
                                    }
                                    else
                                    {
                                        nCount++;
                                    }
                                    if (nCount < 3)
                                    {
                                        edicola.cercaPubblicazioniTDC(titoloFiltro, dataFiltro, tipoPubblicazione, categoriaFiltro);
                                    }
                                    else if (nCount == 3)
                                    {
                                        Console.WriteLine("Inserire almeno un filtro per la ricerca.");
                                    }
                                    break;
                                case "2":
                                    //ricerca per disponibilità di stock
                                    Console.Write("Inserire il codice dello stock:\n>");
                                    codice = Console.ReadLine();

                                    edicola.cercaPubblicazionInStock();

                                    Console.Write("Premere un tasto per continuare\n>");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    //ricerca libera
                                    Console.Write("Inserire una stringa di ricerca:\n>");
                                    stringaRicerca = Console.ReadLine();
                                    edicola.cercaPubblicazioniGenericamente(stringaRicerca);

                                    Console.WriteLine("Premere un tasto per continuare");
                                    Console.ReadKey();
                                    break;
                                case "q":
                                    return;
                                case "Q":
                                    return;
                                default:
                                    Console.WriteLine("Opzione non valida. Riprova.\n>");
                                    break;
                            }
                        }

                        Console.Write("Premere un tasto per continuare\n>");
                        Console.ReadKey();
                        break;
                    case "8": 
                        //TODO: aggiungi sottoscrizione
                        Console.WriteLine("Nuova sottoscrizione");

                        Console.Write("Inserire nome del cliente:\n>");
                        nomeCliente = Console.ReadLine();
                        
                        Console.Write("Inserire email del cliente:\n>");
                        emailCliente = Console.ReadLine();
                        
                        Cliente cliente = new Cliente(nomeCliente,emailCliente);

                        isCodiceValido = false;
                        while ((!isCodiceValido) || (codiceRivista != "q"))
                        {
                            Console.Write("Inserire il Codice della Rivista, o [q] uscire dall'opzione:\n>");
                            codiceRivista = Console.ReadLine();

                            if((codiceRivista == null) || (codiceRivista.ToLower() == "q"))
                            {
                                isCodiceValido = true;
                            }
                            else if (!edicola.cercaRivista(codiceRivista))
                            {
                                Console.WriteLine("Rivista non trovata.");
                            }
                            else
                            {
                                isCodiceValido= true;
                            }

                        }
                        if((codiceRivista == null) || (codiceRivista.ToLower() == "q"))
                        {
                            break;
                        }
                        
                        Console.Write("Inserire la data di inizio sottoscrizione (formato AAAA-MM-GG):\n>");
                        dataInizio = DateTime.Parse(Console.ReadLine());

                        Console.Write("Inserire la data di fine sottoscrizione (formato AAAA-MM-GG):\n>");
                        dataFine = DateTime.Parse(Console.ReadLine());

                        Sottoscrizione nuovaSottoscrizione = new Sottoscrizione(cliente, codiceRivista, dataInizio, dataFine);

                        edicola.aggiungiSottoscrizione(nuovaSottoscrizione);
                        
                        Console.WriteLine("Sottoscrizione aggiunta con successo.");
                        break;
                    case "q":
                        return;
                    case "Q":
                        return;
                    default:
                        Console.WriteLine("Opzione non valida. Riprova.\n>");
                        break;
                }
                Console.WriteLine("Premi un tasto per tornare al menu");
                Console.ReadKey();
            }
        }
    }

}
