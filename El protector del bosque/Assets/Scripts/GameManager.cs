using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AmericanoTrigger americanoTrigger;

    public int score;
    public TMP_Text scoreText;

    public TMP_Text questionText;
    public TMP_Text[] answersTexts;
    int currentCorrectAnswer;
    public GameObject questionUI;

    public Camera mainCamera;

    public Canvas canvas;
    public GameObject initialDialog;
    public GameObject wrongAnswerDialog;
    public GameObject correctAnswerDialog;
    public Button triviaButton;
    public Button retryButton;
    public Button continueButton;

    

    void Start()
    {

        triviaButton.onClick.AddListener(ShowTrivia);
        retryButton.onClick.AddListener(RetryTrivia);
        continueButton.onClick.AddListener(americanoTrigger.ContinueGame);
        HideAllDialogs();

    }

    void Update()
    {
        scoreText.text = score.ToString();
    }
    public void ShowTrivia()
    {
        HideAllDialogs();
        questionUI.SetActive(true);
    }
    public void HandleCorrectAnswer()
    {

        questionUI.SetActive(false);
        correctAnswerDialog.SetActive(true);

    }
    public void HandleWrongAnswer()
    {
        questionUI.SetActive(false);
        wrongAnswerDialog.SetActive(true);
    }
    public void RetryTrivia()
    {

        wrongAnswerDialog.SetActive(false);
        questionUI.SetActive(true);

    }
    public void ContinuarGame()
    {

        correctAnswerDialog.SetActive(false);
        HideAllDialogs();

    }
    public void ShowInitialDialog(GameObject dialog)
    {
        dialog.SetActive(true);
    }
    void HideAllDialogs()
    {

        initialDialog.SetActive(false);
        questionUI.SetActive(false);
        wrongAnswerDialog.SetActive(false);
        correctAnswerDialog.SetActive(false);

    }
   
    public void LoadQuestion(Question question)
    {
        questionText.text = question.question;

        for (int i = 0; i < answersTexts.Length; i++)
        {
            answersTexts[i].text = question.possibleAnswers[i];
        }

        currentCorrectAnswer = question.correctAnswer;

    }
    public void AnswerQuestion(int answerIndex)
    {
        if(currentCorrectAnswer == answerIndex)
        {
            //animación del osito festejando
            //confeti con partículas como una exploción
            correctAnswerDialog.SetActive(true);
            score += 1;
            scoreText.text = "x " + score;
            Debug.Log(scoreText);
        }
        else
        {
            //animación triste del osito
            wrongAnswerDialog.SetActive(true);
        }
    }
}
