using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    // CapsuleCollider collider;

    [SerializeField] //Ist im Inspector sichtbar
    [Range(1, 360)] //Schieberegler
    private float speed;
    private float speedBackup;

    private Vector3 gravity = new Vector3(0, -9.81f, 0);

    [SerializeField] //Ist im Inspector sichtbar
    [Range(1, 12)] //Schieberegler
    private float gravityModifier;
    //rotation

    [SerializeField] //Ist im Inspector sichtbar
    [Range(0, 360)] //Schieberegler
    private float speedRotation;


    [SerializeField] //Ist im Inspector sichtbar
    [Range(0.5f, 600)] //Schieberegler
    private float jumpPowerBase;
    private float jumpPowerCurr;



    // Start is called before the first frame update
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        jumpPowerCurr = 0;
        speedBackup = speed;
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        #region Movement

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
                                                                                                  //Da sich Move immer nur entlang der Globalen Koordinaten bewegt, muss davor die Aktuelle Rotation * Bewegung genommen werden, um den Character in die korrekte Richtung bewegen zu k�nnen


        #endregion
        #region Rotation

        //Rotation
        float mouseHorizontal = Input.GetAxis("Mouse X");

        Vector3 rotate = new Vector3(0, mouseHorizontal, 0) * speedRotation * Time.deltaTime;


        this.transform.Rotate(rotate);
        #endregion
        #region Jump Handling (included in Movement)
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpPowerCurr = jumpPowerBase;
            }


        }
        else
        {

            jumpPowerCurr += gravity.y * Time.deltaTime * gravityModifier; //gravity is a negative value

        }

        #endregion

       // GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezeRotationZ;

    }


}
