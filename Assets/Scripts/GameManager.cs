using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText,
                highScoreText;

    public float scoreMultiplier,
                 bonusTime,
                 bonusScore = 1.5f;

    public int scoreInt,
               highScore,
               randomTime;

    public GameObject exitPanel;

    [SerializeField] private RatSpin getSpeed;
    [SerializeField] private GameObject currentRat;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text = "Total Score: " + highScore;
    }
    void Start()
    {
        scoreMultiplier = 0f;
        scoreText.text = "Score: " + scoreMultiplier;
        randomTime = Random.Range(10, 30);

    }

    void Update()
    {
        GainScore();

        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
    }


    public void GainScore()
    {
        if(Joystick.isSpin == true)
        {
            scoreMultiplier += Time.deltaTime;
            scoreInt = Mathf.RoundToInt(scoreMultiplier);
            scoreText.text = "Score: " + scoreInt;

            bonusTime += Time.deltaTime;

            /*for (int i = 0; i > randomTime; i++)
            {
                scoreMultiplier = scoreMultiplier * bonusScore;
                bonusTime = 0;
                randomTime = Random.Range(10, 30);
            }*/
            if (bonusTime > randomTime)
            {
                scoreMultiplier = scoreMultiplier * bonusScore;
                bonusTime = 0;
                randomTime = Random.Range(10, 30);
            }

        }

    }

    public void DeleteScore()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SaveProgress()
    {
        highScore = scoreInt + highScore;
        PlayerPrefs.SetInt("High Score", highScore);
    }

    public void FindRat()
    {
        currentRat = GameObject.FindGameObjectWithTag("Player");
        getSpeed = currentRat.GetComponent<RatSpin>();
    }

    public void QuitGame()
    {
        Application.Quit();
        SaveProgress();
    }


    
}
