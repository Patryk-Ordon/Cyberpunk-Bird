using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public GameObject Button;
    public Player Player;
    private int score;
    public spawner spawner;
    public TextMeshPro gameOverText;
    public TextMeshPro scoreInfo;
    public TextMeshPro startInfo;
    public string t1 = "Najlepszy wynik: ";
    public string t2 = "\nWynik: ";
    private int bestScore = 0;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("bestScore");
        scoreInfo.text = t1 + bestScore + t2 + score;
        Time.timeScale = 0;
        gameOverText.gameObject.SetActive(true);
        Button.SetActive(true);
        InvokeRepeating("Timer", 1, 1);
    }

    void Update()
    {
        if (Player.isDead)
        {
            gameOverText.text = "KONIEC GRY";
            gameOverText.gameObject.SetActive(true);
            Button.SetActive(true);
            startInfo.gameObject.SetActive(true);
        }
    }

    public void StartGame()
    {
        score = 0;
        scoreInfo.text = t1 + bestScore + t2 + score;
        var clones = GameObject.FindGameObjectsWithTag("Clone");
        foreach (var clone in clones)
        {
            Destroy(clone);
        }
        gameOverText.gameObject.SetActive(false);
        Button.SetActive(false);
        startInfo.gameObject.SetActive(false);
        spawner.Reset();
        Player.isDead = false;
        Player.Start();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("bestScore", bestScore);
        }
        Time.timeScale = 0;
    }

    public void Timer()
    {
        score++;
        scoreInfo.text = t1 + bestScore + t2 + score;
        if (score % 10 == 0)
        {
            spawner.Increase();
        }
    }
}
