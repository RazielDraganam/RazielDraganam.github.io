class Player
{

    // Der Konstruktor wird ausgeführt, wenn die Klasse erstellt wird, man sagt instanziiert wird.
    constructor( posX, posY, speed, lives = 3, health = 100, damage = 20){

        this.posX = posX;                    // Erste PosX is für class Player, zweite posX für in der constructor Klammer
        this.posY = posY;
        this.speed = speed;
        this.lives = lives;
        this.health = health;
        this.damage = damage;
    }

    update( deltaTime )                     // Von hier aus können wir zeitgesteuerte Aktionen steuern
    {

    }

    // Diese Methode gehört zur Player-Klasse von aussen player.translate (10,10)
    // Aus der Klasse heraus this.translate (10,10)
    translate(x,y)     
    {
        console.log("Translate x: " +x + "Translate y: "+y)

    }
}