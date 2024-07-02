using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class GameSettings : MonoBehaviour
{
    public SettingSO settings;
    public Transform RightSpawn;
    public Transform LeftSpawn;
    public TextMeshProUGUI TextMesh;
    public TextMeshProUGUI HighScoreText;
    public VoidEventSO VoidEvent;
    public UnityEvent GameFailed;
   
    // Start is called before the first frame update

    private float spawnWaitTime = 2.0f;
    private float DifficultyChange = 20.0f;
    private float subtractionValue = 0.2f;

    private float currentTimeValue = 0.0f;
    private float currentDiff = 0.0f;

    void Start()
    {
        VoidEvent.UpdateScore += UpdateScoreValue;
    }

    public void StartGame()
    {
        settings.StartGame = true;
    }

    private void Update()
    {
        if (settings.StartGame)
        {
            if (currentTimeValue > spawnWaitTime)
            {
                Instantiate(settings.RightBox, RightSpawn.position, settings.RightBox.transform.rotation);
                Instantiate(settings.LeftBox, LeftSpawn.position, settings.LeftBox.transform.rotation); 
                currentTimeValue = 0.0f;
            }

            if(currentDiff > DifficultyChange)
            {
                currentDiff = 0;
                spawnWaitTime -= subtractionValue;
                settings.BoxSpeed += 2.0f;
                settings.ScoreFactor += 60;
                DifficultyChange += 20f;
            }

            currentTimeValue += Time.deltaTime;
            currentDiff += Time.deltaTime;
        }

        if(settings.FailCount >= 5)
        {
            settings.StartGame = false;
            GameFailed?.Invoke();
            HighScoreText.text = "High Score\n" + settings.Score;

        }
      
    }

    public void UpdateScoreValue()
    {
        TextMesh.text = "XP" + settings.Score;
    }


    public void RestartLevel()
    {
        settings.FailCount = 0;
        settings.BoxSpeed = 2.0f;
        settings.ScoreFactor = 30;
        settings.Score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetRightHand(bool state)
    {
        settings.RightHand = state;
    }

    public void SetLeftHand(bool state)
    {
        settings.LeftHand = state;
    }
}
