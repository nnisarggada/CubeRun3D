using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public Transform player;
    public int score;
    public int coins;
    public Text scoreText;
    public Text highscore;
    public GameObject newHighscore;
    public GameObject button1;
    public GameObject button2;
    public Leaderboard leaderboard;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("NameSet") != "true"){
            button1.SetActive(false);
            button2.SetActive(false);
        }
        else{
            button1.SetActive(true);
            button2.SetActive(true);
        }
        score = Mathf.RoundToInt(player.position.z);
        coins = (score-(score%100))/100;
        if (coins < 5)
		{
            coins = 5;
		}
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) + coins);
        if (score > PlayerPrefs.GetInt("Highscore", 0))
		{
            PlayerPrefs.SetInt("Highscore", score);
            StartCoroutine(HighScoreAudio());
            newHighscore.SetActive(true);
        }
		else
		{
            newHighscore.SetActive(false);
		}
        scoreText.text = "Current Score: " + player.position.z.ToString("0");
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    private IEnumerator HighScoreAudio()
	{   
        yield return FindObjectOfType<Leaderboard>().SubmitScoreRoutine();
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<AudioManager>().Play("Highscore");
        yield return new WaitForSeconds(2f);
        if (PlayerPrefs.GetString("NameSet") != "true"){
            SceneManager.LoadScene("Leaderboard");
        }
    }
}
