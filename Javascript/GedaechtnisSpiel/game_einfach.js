const cardsList = [];
const container = document.querySelector("#GedaechtnisSpiel");          // Wo auf der Website angezeigt wird
const folder ="../../Images/spiele/GedaechtnisSpiel/mem_cards/";        // Bilder der Karten
cover = folder + "cover.jpg";                                           // Deckblatt der Karten
let locked = false;
let tries = 0;                                                          // Versuche auf 0 setzen
const difficulties = document.querySelectorAll("input[name='difficulty']");

let revealedCards = {
    first: null,
    second: null
}

                                                                        // Schwierigkeitsgrad, wenn man es in JavaScript einstellt
function checkDifficulty(){
	[].forEach.call(difficulties, function(input){
		input.nextElementSibling.classList.remove('checked');
		console.log(input.nextElementSibling)
		if (input.value === 'easy' && input.checked === true) {
			difficulty = 4;
			difficultyClass = 'easy';
			input.nextElementSibling.classList.add('checked');
		} else if (input.value === 'normal' && input.checked === true) {
			difficulty = 16;
			difficultyClass = 'normal';
			input.nextElementSibling.classList.add('checked');
		} else if (input.value === 'hard' && input.checked === true) {
			difficulty = 36;
			difficultyClass = 'hard';
			input.nextElementSibling.classList.add('checked');
		}
	});
}

function drawCards( count ){                                        // Wieviel Karten "gezogen" werden, siehe am Ende des Codes

    if(count>6)
        count=6;

    for (let i = 1; i <= count; i++){

        cardsList.push ( new Card( "CardType" + i, folder + "memo" + i + ".jpg" , container, cover ) ) ;
        cardsList.push ( new Card( "CardType" + i, folder + "memo" + i + ".jpg" , container, cover ) ) ;

    }

    mixCards(cardsList);

    cardsList.forEach(card => {
        card.create();
    });
}

function mixCards(cards){                                           // Auf Zufall stellen

    for ( let i = cards.length -1; i > 0; i-- ) {
        const j = Math.floor(Math.random() * (i + 1));
        [cards[i], cards[j]] = [cards[j], cards[i]];
    }

}

function won(){

    console.log("Won");                                            

    const window = document.createElement ("div");
    const retry = document.createElement ("button");              //Button erstellen, wird erst mit appendChild eingebracht

    window.className = "window";                                    // Fenster wird eingeblendet (nachdem alle Pärchen gefunden wurden)
    window.innerText = "Super! du hast " + tries + " Versuche gebraucht.";  //Anzahl der Versuche wird angezeigt
    retry.innerText = "Nochmal";                                    // Nochmal spielen

    window.appendChild(retry);

    document.body.appendChild(window);

    retry.addEventListener("click", ()=>{
        location.reload();
    });

}


drawCards(6);       // Anzahl der Karten, die gezogen werden. 