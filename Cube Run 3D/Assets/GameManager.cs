using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public static bool gameHasEnded = false;
	public float restartDelay = 2f;
	public GameObject GameOverUI;
	public GameObject ScoreUI;
	public GameObject PauseButton;
	public GameObject CoinsUI;
	public GameObject ExtraLifeUI;
	public static bool extraLife = false;
	public Transform player;

	private void Start()
	{
		gameHasEnded = false;
	}

	private void Update()
	{
		if (PlayerPrefs.GetInt("Coins", 0) > 99999)
		{
			PlayerPrefs.SetInt("Coins", 99999);
		}
	}

	public void EndGame()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			ScoreUI.SetActive(false);
			PauseButton.SetActive(false);
			CoinsUI.SetActive(false);
			GameOverUI.SetActive(true);
			extraLife = true;
		}
	}

	public void CheckRevive()
	{
		if (extraLife == false && PlayerPrefs.GetInt("Coins") >= 50)
		{
			if (Random.value <= 0.5 || Mathf.RoundToInt(player.position.z) >= PlayerPrefs.GetInt("Highscore", 0))
			{
				ScoreUI.SetActive(false);
				PauseButton.SetActive(false);
				ExtraLifeUI.SetActive(true);
				gameHasEnded = true;
			}
			else
			{
				EndGame();
			}
		}
		else
		{
			EndGame();
		}
	}

	public void Restart()
	{
		extraLife = false;
		FindObjectOfType<AudioManager>().Play("UI");
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu()
	{
		FindObjectOfType<AudioManager>().Play("UI");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
