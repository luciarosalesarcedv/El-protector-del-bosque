using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class PolarTrigger : MonoBehaviour
{
    public GameObject initialDialog;
    public GameObject wrongAnswerDialog;
    public GameObject correctAnswerDialog;
    public Camera mainCamera;
    public Camera polarCamera;
    public GameManager gm;
    public Question question;

    private bool playerInTrigger = false;

    public Button continueButton;

    public AudioSource src;
    public AudioClip sfx1, sfx2;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(ContinueGame);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            initialDialog.SetActive(true);
            gm.LoadQuestion(question);
            EnterMalayoTrigger();
        }
    }
    void EnterMalayoTrigger()
    {
        mainCamera.gameObject.SetActive(false);
        polarCamera.gameObject.SetActive(true);
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

        polarCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gm.ContinuarGame();
        playerInTrigger = false;
        Debug.Log("Continuando el juego en PolarTrigger.");

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
