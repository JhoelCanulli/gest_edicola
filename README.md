# Sistema di Gestione Edicola

## Funzionalità : 
_Attualmente il sistema é così strutturato_:
1.  **Gestione dell'Inventario**:
-   Aggiunta nuove pubblicazioni. 
-   Rimozione pubblicazioni.
-   Aggiornamento quantità in stock.
-   Visualizzazione elenco pubblicazioni disponibili e quantità di stock.

2. **Gestione delle Vendite**:
-   Vendere una o più copie di pubblicazioni disponibili, e quantità di stock.
-   Visualizzazione dello storico di vendite per data, pubblicazione o categoria.

3. **Ricerca e filtraggio**:
-   Cercare le pubblicazioni per titolo, data di
pubblicazione, o categoria.
-   Filtrare l'elenco delle pubblicazioni per disponibilità
di stock.
-   Ricerca generica di una pubblicazione

4. **Gestione delle Sottoscrizioni**:
-   Gestire le sottoscrizioni dei clienti per le riviste (abbonamenti).

***
## Gestione del codice :
-   In __Program__ è presente un menu testuale in cui accedere a tutte le funzionalità.
Tali funzionalità sono implementate per lo più nella classe __Edicola__.  

_Attualmente il sistema presenta_ :
-   ### all'interno della directory _classes_ le classi: ### 
    -   __Edicola__ : _gestisce la totalità dei metodi che vengono chiamati nel menu iniziale. Aggrega le classi_:
        -    __Vendita__   
        -  __Pubblicazione__
        - __Sottoscrizione__
        -   __Cliente__
    -   __Pubblicazione__ : _classe abstract da cui ereditano_:
        -   __Giornale__  
        -   __Rivista__
    -   __Giornale__
    -   __Rivista__
    -   __Vendita__
    -   __Sottoscrizione__ 
    -   __Cliente__
-   ### all'interno della directory _interfaces_ un interfaccia: ###
    -   __IEdicola__ : _qui sono presenti tutti i metodi implementati nella Classe __Edicola___

 
