using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void Play()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		FindObjectOfType<AudioManager>().Play("UI");
	}

	public void Leaderboard(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
		FindObjectOfType<AudioManager>().Play("UI");
	}

	public void Exit()
	{
		Debug.Log("exited");
		FindObjectOfType<AudioManager>().Play("UI");
		Application.Quit();
	}
}
