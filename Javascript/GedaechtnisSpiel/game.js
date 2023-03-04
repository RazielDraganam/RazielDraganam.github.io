/*Dokumentation beim übertragen einbauen*/
const cardsList = [];
const container = document.querySelector("#GedaechtnisSpiel");
const folder ="../../Images/spiele/GedaechtnisSpiel/mem_cards/";
cover = folder + "cover.jpg";
let locked = false;
let tries = 0;

let revealedCards = {
    first: null,
    second: null
}


function drawCards( count ){

    if(count>19)
        count=19;

    for (let i = 1; i <= count; i++){

        cardsList.push ( new Card( "CardType" + i, folder + "memo" + i + ".jpg" , container, cover ) ) ;
        cardsList.push ( new Card( "CardType" + i, folder + "memo" + i + ".jpg" , container, cover ) ) ;

    }

    mixCards(cardsList);

    cardsList.forEach(card => {
        card.create();
    });
}

function mixCards(cards){

    for ( let i = cards.length -1; i > 0; i-- ) {
        const j = Math.floor(Math.random() * (i + 1));
        [cards[i], cards[j]] = [cards[j], cards[i]];
    }

}

//**Die Funktionen beschreiben
//
// *//

function won(){
    // toDo: Fenster mit Anzahl der Züge und Gewinnnachricht anzeigen
    console.log("Won");

    const window = document.createElement ("div");
    const retry = document.createElement ("button");                                                //Button erstellen, wird erst mit appendChild eingebracht

    window.className = "window";
    window.innerText = "Super! du hast " + tries + " Versuche gebraucht.";
    retry.innerText = "Nochmal";

    window.appendChild(retry);

    document.body.appendChild(window);

    retry.addEventListener("click", ()=>{
        location.reload();
    });

}

drawCards(16);