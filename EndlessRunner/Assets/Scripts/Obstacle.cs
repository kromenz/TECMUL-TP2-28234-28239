using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour {

    PlayerMovement playerMovement;
    public AudioClip colisaoSound;

	private void Start () {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
	}

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.name == "Player") {
            // Kill the player
            
            AudioSource.PlayClipAtPoint(colisaoSound, transform.position);
            playerMovement.Die();
        }
    }

    private void Update () {
	
	}
}