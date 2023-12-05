class Card{

    revealed = false;                                               // Karten standardmäßig verdeckt
    found = false;                                                  // Standardmäßig kein Pärchen gefunden

    elem;

     // Konstruktor dient dazu, bei Erstellen der Klasse initiale Dinge zu erledigen.
     constructor( name, file, container, coverFile ){
        this.file = file;
        this.name = name;
        this.container = container;
        this.coverFile = coverFile;
    }

    create(){

        this.elem = document.createElement('img');                   //Const erstellen
        this.elem.src = this.coverFile;                              //Quelle
        this.elem.className = "card";                                //Klassenname für CSS
        this.container.appendChild(this.elem);                       //Anzeigen lassen
        this.elem.addEventListener("click", () => {
            this.show();
        })
    }

    show(){                                                         // Anzeigen der Karten bei anklicken
        if(revealedCards.first == null || revealedCards.second == null){
            this.elem.src = this.file;

            if(revealedCards.first == null && !this.revealed){      // Erste Karte aufdecken
                revealedCards.first = this;
                this.revealed = true;
            }
            else if (revealedCards.second == null && !this.revealed){   // Zweite Karte aufdecken
                revealedCards.second = this;    
                this.revealed=true;
                this.compare();                                     // Karte 1 und Karte 2 vergleichen
            }
        }

    }

    hide(){                                                         // Karten wieder verdecken
        this.elem.src = this.coverFile;
    }

    compare(){                                                      // Karten vergleichen

        if(locked)return;
        tries++;                                                    // Versuche hochzählen

        if(revealedCards.first.name == revealedCards.second.name){  //bei gleichen Karten
                revealedCards.first.found = true;
                revealedCards.second.found = true;
                revealedCards.first = null;
                revealedCards.second = null;

                if(this.isComplete())                               //Wenn alle Pärchen gefunden wurden, hat man gewonnen
                    won ();
        }
        else{
                                                                    //Karten sind nicht gleich
            locked = true;
            setTimeout(()=>{
            revealedCards.first.hide();                             // Karte 1 verdecken
            revealedCards.second.hide();                            // Karte 2 verdecken
            revealedCards.first.revealed = false;
            revealedCards.second.revealed = false;            
            revealedCards.first = null;
            revealedCards.second = null;            
            locked = false;
            }, 1000                     
            );
        }


    }



isComplete() {                                                      // Wenn alle Pärchen gefunden wurden
    let complete = true;

    cardsList.forEach ( card => {
        if(card.found == false)
        {
            complete = false;
        }
    });

    return complete;
}



}
