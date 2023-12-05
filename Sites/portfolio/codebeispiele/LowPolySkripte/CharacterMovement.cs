using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController controller;

    //CapsuleCollider collider;

    
    float baseSpeed = 0.04f;
    private float speed;
    private float speedBackup;
    private float jumpPowerCurr;

    [SerializeField] //Ist im Inspector sichtbar
    [Range(0, 360)] //Schieberegler
    private float speedRotation;

    public Vector2 turn;        // für Rotation

    // Gravity
    private Vector3 gravity = new Vector3(0, -9.81f, 0);


    // Start is called before the first frame update
    void Start()
    {
        speed = baseSpeed;
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation mit Maus
        //  turn.x += Input.GetAxis("Mouse X");
        //  turn.y += Input.GetAxis("Mouse Y");
        //  transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        // Bewegung
        // transform.Translate(Input.GetAxisRaw("Horizontal") * speed, 0, Input.GetAxisRaw("Vertical") * speed);

        // Sprint
        /* if (Input.GetKey(KeyCode.LeftShift))
             {
                 speed = baseSpeed * 2;
             }
             else
             {
                 speed = baseSpeed;
             }
        */
        //Gravity 




        // Benutzen/Aktion mit E

        // Movement

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedBackup * 1.7f;
        }
        else
        {
            speed = speedBackup;
        }

        Vector3 motion;

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");


        motion = new Vector3(horizontal, 0, vertical) * speed;

        var gravityVelocity = gravity;
        var jumpVelocity = Vector3.up * jumpPowerCurr;

        controller.Move(transform.rotation * (motion + jumpVelocity + gravity) * Time.deltaTime); //ChartacterController Component nutze die Move Funktion
                                                                                                  //Da sich Move immer nur entlang der Globalen Koordinaten bewegt, muss davor die Aktuelle Rotation * Bewegung genommen werden, um den Character in die korrekte Richtung bewegen zu können


        // Rotation

        //Rotation
        float mouseHorizontal = Input.GetAxis("Mouse X");

        Vector3 rotate = new Vector3(0, mouseHorizontal, 0) * speedRotation * Time.deltaTime;


        this.transform.Rotate(rotate);



    }



}
