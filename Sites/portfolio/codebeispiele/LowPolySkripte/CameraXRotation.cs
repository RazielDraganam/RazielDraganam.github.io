using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraXRotation : MonoBehaviour
{
    [SerializeField]
    float rotationXSpeed;


    [SerializeField]
    float LerpRotationXSpeed;
   

    // Update is called once per frame
    void Update()
    {
        float mouseVertical = Input.GetAxis("Mouse Y");

        #region Lerped Rotation
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation * Quaternion.Euler(-mouseVertical, 0, 0);

        transform.rotation = Quaternion.Lerp(from, to, LerpRotationXSpeed * Time.deltaTime);
        #endregion
        #region Strict Rotation
        //Vector3 rotation = new Vector3(-mouseVertical,0,0) * rotationXSpeed * Time.deltaTime;

        //transform.Rotate(rotation);
        #endregion

    }
}
