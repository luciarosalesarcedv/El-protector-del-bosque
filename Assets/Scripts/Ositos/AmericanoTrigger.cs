using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AmericanoTrigger : MonoBehaviour
{
    public GameObject initialDialog;
    public GameObject wrongAnswerDialog;
    public GameObject correctAnswerDialog;
    public Camera mainCamera;
    public Camera americanoCamera;
    public GameManager gm;
    public Question question;

    private bool playerInTrigger = false;

    public AudioSource src;
    public AudioClip sfx1, sfx2;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            initialDialog.SetActive(true);
            gm.LoadQuestion(question);
            EnterAmericanoTrigger();
        }
    }
    void EnterAmericanoTrigger()
    {
        mainCamera.gameObject.SetActive(false);
        americanoCamera.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gm.ShowInitialDialog(initialDialog);
        playerInTrigger = true;
    }
    public void OnTriviaAnswered(bool isCorrect)
    {
        if (isCorrect)
        {
            gm.HandleCorrectAnswer();
            src.clip = sfx1;
            src.Play();
        }
        else
        {
            gm.HandleWrongAnswer();
            src.clip = sfx2;
            src.Play();
        }
    }
    public void ContinueGame()
    {

        americanoCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gm.ContinuarGame();
        playerInTrigger = false;
        Debug.Log("Continuando el juego en AmericanoTrigger.");

    }
    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.Escape))
        {
            ContinueGame();
        }
    }
    
}
