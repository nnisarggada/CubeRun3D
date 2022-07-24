using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExtraLife : MonoBehaviour
{

    public Rigidbody rb;
    public BoxCollider boxCollider;
    public GameObject contUI;
    public GameObject countdownUI;
    public PlayerMovement movement;
    public Text countdownText;
    public MeshRenderer meshRenderer;
    public GameObject ScoreUI;
    public GameObject PauseButton;
    public bool interaction;
    public Text coinsText;

	private void Start()
	{
        StartCoroutine("Timer");
	}

	public void Use()
	{
        interaction = true;
        GameManager.gameHasEnded = false;
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 50);
        coinsText.text = PlayerPrefs.GetInt("Coins", 0).ToString();
        StartCoroutine("Invincible");
	}

    public void DontUse()
	{
        interaction = true;
        GameManager.gameHasEnded = false;
        this.gameObject.SetActive(false);
        FindObjectOfType<GameManager>().EndGame();
	}

    private IEnumerator Invincible()
    {
        rb.gameObject.tag = "NotPlayer";
        Time.timeScale = 1f;
        movement.enabled = true;
        Quaternion newQuaternion = new Quaternion();
        newQuaternion.Set(0, 0, 0, 1);
        newQuaternion = newQuaternion.normalized;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.rotation = newQuaternion;
        rb.MovePosition(new Vector3(0, 1, rb.position.z + 10));
        rb.useGravity = false;
        yield return new WaitForFixedUpdate();
        rb.angularVelocity = Vector3.zero;
        rb.rotation = newQuaternion;
        boxCollider.enabled = false;
        contUI.SetActive(false);
        countdownUI.SetActive(true);
        ScoreUI.SetActive(true);
        PauseButton.SetActive(true);
        meshRenderer.enabled = true;
        countdownText.text = "3";
        rb.detectCollisions = false;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = true;
        countdownText.text = "2";
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = true;
        countdownText.text = "1";
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(0.5f);
        meshRenderer.enabled = true;
        boxCollider.enabled = true;
        rb.detectCollisions = true;
        countdownUI.SetActive(false);
        yield return new WaitForFixedUpdate();
        rb.angularVelocity = Vector3.zero;
        rb.rotation = newQuaternion;
        rb.useGravity = true;
        GameManager.extraLife = true;
        rb.gameObject.tag = "Player";
        yield return null;
        this.gameObject.SetActive(false);
    }

    IEnumerator Timer()
	{
        yield return new WaitForSeconds(3f);
        
        if (!interaction)
		{
            DontUse();
        }
	}
}
