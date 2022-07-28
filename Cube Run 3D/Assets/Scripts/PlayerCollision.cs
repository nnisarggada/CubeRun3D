using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	public PlayerMovement movement;
	public Rigidbody rb;

    void OnCollisionEnter (Collision collisonInfo)
	{
		if (collisonInfo.collider.tag == "Obstacle" && this.gameObject.tag == "Player")
		{
			rb.constraints = RigidbodyConstraints.None;
			movement.enabled = false;
			Time.timeScale = 0.5f;
			Handheld.Vibrate();
			FindObjectOfType<AudioManager>().Play("Death");
			FindObjectOfType<GameManager>().CheckRevive();
		}
	}
}
