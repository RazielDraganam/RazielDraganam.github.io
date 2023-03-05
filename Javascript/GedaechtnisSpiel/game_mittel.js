/*Dokumentation beim übertragen einbauen*/
const cardsList = [];
const container = document.querySelector("#GedaechtnisSpiel");
const folder ="../../Images/spiele/GedaechtnisSpiel/mem_cards/";
cover = folder + "cover.jpg";
let locked = false;
let tries = 0;
const difficulties = document.querySelectorAll("input[name='difficulty']");

let revealedCards = {
    first: null,
    second: null
}


// go over the radio buttons and check the difficulty selection
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


function drawCards( count ){

    if(count>10)
        count=10;

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


drawCards(10);
