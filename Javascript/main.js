const volumeSlider = document.querySelector("#volume");
volumeSlider.addEventListener("input", SetVolume);  	                            // input ändert sachen in echtzeit

const bgMusic = new Audio ("http://csstrainer.de/media/froggySong.wav");            //normalerweise Sound Ordner

const musicButton = document.querySelector("#playMusic");                           // set die variable auf den Music Button im HTML Dokument
musicButton.addEventListener ("click", toggleMusic);                                // spielt Musik mit klick

let count = 0;

const player = new Player ( 100, 200, 10 );     // Klasseninstanzen werden mit dem Schlüsselwort new erzeugt; 




/**
 * Sets the Volume
 * @param {*} event
 * 
**/

 function SetVolume( event )      // sound wird unten wieder benutzt
 {
    //if(bgMusic == null);                  // check ob es sound gibt
    //   return;                         // wenn kein sound, abbrechen

    let volume = event.target.value;
        bgMusic.volume = volume;          // Sound von oben wird hier geregelt, verbindung 


}


/**Hausaufgabe: Bauen Sie die Funktion um zu toggleMusic und ändern sie jeweils die
 * Schrift des Buttons z.B. bei Mute Background Music (anzeige von play zu mute switchen)
*/

 // Hausaufgaben funktion ohne wechsel vom Button
    function toggleMusic()
    {
        if(count == 0)
        {
               bgMusic.play();
                count ++;
            } 
            
           else
          {
              bgMusic.pause()
                    count--;
     }
    }



/**
 * starts the background music
 *  @param {*} event
 */
/*
 function toggleMusic(event)
 {
 
     bgMusic.play();
 
        if(count == 0)
        {
            bgMusic.play();
                count ++;
        } 
        
        else(count );
        {
            bgMusic.pause()
                count--;
        }

}
*/
//label, button verknüpfen usw

/**
 * Versuch den Button play zum laufen zu bringen im Unterricht
 *
 *
 * function toggleBGMusic (event){
 *
 *    musicIsPlaying =!musicIsPlaying;
 *    if(musicIsPlaying){
 *        musicButton.innerText ="Mute Music";
 *        bgMusic.play();
 *        }
 *    else{
 *        bgMusic.pause();
 *        musicButton.innerText ="Play Music";
 *    }
 *
 *
 */


