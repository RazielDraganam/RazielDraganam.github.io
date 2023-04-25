class Card{

    revealed = false;
    found = false;

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

    show(){
        if(revealedCards.first == null || revealedCards.second == null){
            this.elem.src = this.file;

            if(revealedCards.first == null && !this.revealed){
                revealedCards.first = this;
                this.revealed = true;
            }
            else if (revealedCards.second == null && !this.revealed){
                revealedCards.second = this;
                this.revealed=true;
                this.compare();
            }
        }

    }

    hide(){
        this.elem.src = this.coverFile;
    }

    compare(){

        if(locked)return;
        tries++;

        if(revealedCards.first.name == revealedCards.second.name){
            //Karten sind gleich
                revealedCards.first.found = true;
                revealedCards.second.found = true;
                revealedCards.first = null;
                revealedCards.second = null;

                if(this.isComplete())
                    won ();
        }
        else{
            //Karten sind nicht gleich
            locked = true;
            setTimeout(()=>{
            revealedCards.first.hide();
            revealedCards.second.hide();
            revealedCards.first.revealed = false;
            revealedCards.second.revealed = false;            
            revealedCards.first = null;
            revealedCards.second = null;            
            locked = false;
            }, 800
            );
        }


    }



isComplete() {
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
