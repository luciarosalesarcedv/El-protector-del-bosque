using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomFPController : MonoBehaviour
{
    [Header("Camera Controls")]

    public float sensitivity;

    float xRotation;
    float yRotation;

    public float xLimit;

    public GameObject camObj;
    public Transform camPos;

    public bool lockCam;

    [Header("Character")]

    public float speed;
    public Animator anim;
    bool fidgetting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -xLimit, xLimit);

        camObj.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        camObj.transform.position = camPos.position;
        transform.rotation = Quaternion.Euler(0, yRotation, 0);

        AxisMovement();
        AnimationControls();
    }

    void AxisMovement()
    {  
        Vector3 forwardComponent = transform.forward * Input.GetAxisRaw("Vertical");
        Vector3 rightComponent = transform.right * Input.GetAxisRaw("Horizontal");

        transform.position += (forwardComponent + rightComponent).normalized * speed * Time.deltaTime;
    }

    void AnimationControls()
    {

        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)) fidgetting = !fidgetting;

        anim.SetBool("Fidgetting", fidgetting);
        anim.SetFloat("Direction", Input.GetAxisRaw("Vertical"));
    }
}
