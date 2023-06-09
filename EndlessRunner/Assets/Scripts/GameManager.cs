using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    int score;
    bool jogoIniciado = false;  // Variável para controlar se o jogo foi iniciado
    public static GameManager inst;

    [SerializeField] Text scoreText;

    [SerializeField] PlayerMovement playerMovement;

    public void IncrementScore()
    {
        if (!jogoIniciado) return;  // Se o jogo não foi iniciado, não incremente a pontuação

        score++;
        scoreText.text = "MOEDAS: " + score;
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    public bool JogoIniciado()
    {
        return jogoIniciado;
    }



    private void Awake ()
    {
        inst = this;
    }

    private void Start () {

        if (SceneManager.GetActiveScene().buildIndex == 0) // Verifica se é a cena do menu (índice 0)
        {
            scoreText.gameObject.SetActive(false);
        }
        else  // Se não for a cena do menu, inicia o jogo
        {
            StartGame();
        }
	}

    public void StartGame()
    {
        jogoIniciado = true;
    }


	private void Update () {
	
	}
}