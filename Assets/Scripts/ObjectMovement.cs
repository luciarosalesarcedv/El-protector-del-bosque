using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
    public Animator anim;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }

        anim.SetFloat("Direction", Input.GetAxisRaw("Vertical"));

        transform.position += transform.forward * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        transform.Rotate(Vector3.up * 360 * Input.GetAxisRaw("Horizontal") * rotSpeed * Time.deltaTime);

    }

}
