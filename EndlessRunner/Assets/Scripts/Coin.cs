using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    public AudioClip coinSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }

        // Reproduz o som da moeda quando há colisão com o jogador
        AudioSource.PlayClipAtPoint(coinSound, transform.position);

        GameManager.inst.IncrementScore();
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
