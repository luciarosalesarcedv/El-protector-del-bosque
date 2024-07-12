using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Final : MonoBehaviour
{
    public GameManager gm;
    public GameObject final;


    // Start is called before the first frame update
    void Start()
    {
        final.SetActive(false);
        //gm.score = scoreFinal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (gm.score == 3)
        {
            final.SetActive(true);
            Debug.Log("tengo 3 pedazos de miel");
        }
        else
        {
            Debug.Log(gm.score);
            Debug.Log("tengo menos de 3 pedazos de miel");
        }
    }


}
