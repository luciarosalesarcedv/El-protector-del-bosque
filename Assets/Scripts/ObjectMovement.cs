using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed;
    public float sprintSpeedMultiplier = 2.0f; // Multiplicador de velocidad para sprint
    public float rotSpeed;
    public Animator anim;

    private Vector3 movement;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No se encontró AudioSource en " + gameObject.name);
        }
    }

    void Update()
    {
        // Movimiento y rotación
        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed *= sprintSpeedMultiplier;
        
        }

        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        anim.SetFloat("Direction", Input.GetAxisRaw("Vertical"));

        transform.position += transform.forward * Input.GetAxisRaw("Vertical") * currentSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * 360 * Input.GetAxisRaw("Horizontal") * rotSpeed * Time.deltaTime);

        //codigo extra relacionado con el sonido de los pasos.

        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (verticalInput != 0 || horizontalInput != 0)
        {
            if (!audioSource.isPlaying) 
            {
                audioSource.loop = true; 
                audioSource.Play(); 
            }
        }
        else 
        {
            if (audioSource.isPlaying) 
            {
                audioSource.Stop();
            }
        }

    }

}

