using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCameraController : MonoBehaviour
{
    public float sensitivity;

    float xRotation;
    float yRotation;

    public float xLimit;

    public Transform target;

    public bool lockCam;
    public float verticalOffset;
    float characterDistance;

    public float minCharacterDistance;
    public float maxCharacterDistance;
    public float zoomSpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterDistance = maxCharacterDistance;

    }

    // Update is called once per frame
    void Update()
    {
        if (!lockCam)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

            yRotation += mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -xLimit, xLimit);

            Quaternion normalRot = Quaternion.Euler(xRotation, yRotation, 0);
            transform.rotation = normalRot;

        }else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
       
        Vector3 normalPos = target.position + Vector3.up * verticalOffset - transform.forward * characterDistance;
        transform.position = normalPos;
    }
}
