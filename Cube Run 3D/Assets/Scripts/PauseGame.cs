using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public GameObject PauseMenuUI;
    public GameObject PauseButton;
    public GameObject ScoreUI;

    public void Pause()
	{
        FindObjectOfType<AudioManager>().Play("UI");
        Time.timeScale = 0f;
        PauseButton.SetActive(false);
        ScoreUI.SetActive(false);
        PauseMenuUI.SetActive(true);
	}

    public void Resume()
	{
        FindObjectOfType<AudioManager>().Play("UI");
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        PauseButton.SetActive(true);
        ScoreUI.SetActive(true);
    }

    public void Menu()
	{
        FindObjectOfType<AudioManager>().Play("UI");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
