using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    int score;
    bool jogoIniciado = false;  // Variável para controlar se o jogo foi iniciado
    public static GameManager inst;
    private bool gameIsOver = false;
    [SerializeField] Text scoreText;
    [SerializeField] PlayerMovement playerMovement;
    public GameObject gameOverUI;

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

    public void GameOver()
    {
        if (!gameIsOver && jogoIniciado)
        {
            gameIsOver = true;
            gameOverUI.SetActive(true);
        }
    }

    private void Awake ()
    {
        inst = this;
    }

    private void Start () {

        gameOverUI.SetActive(false);

        if (SceneManager.GetActiveScene().buildIndex == 0) // Verifica se é a cena do menu (índice 0)
        {
            scoreText.gameObject.SetActive(false);
            gameOverUI.SetActive(false); // Desativa o objeto gameOverUI no início do jogo
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

    public void ResetGame()
    {
        jogoIniciado = false;
    }

	private void Update () {
        
	}

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        jogoIniciado = true; // Adicione essa linha para reiniciar o jogo
    }
}