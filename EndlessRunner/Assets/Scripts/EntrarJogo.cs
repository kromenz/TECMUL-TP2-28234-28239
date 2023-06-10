using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarJogo : MonoBehaviour{

    private bool jogoIniciado = false;

    public void PlayGame()
    {
        SceneManager.LoadScene("Jogo");
        GameManager.inst.StartGame(); // Defina o jogo como iniciado após carregar a cena correta
    }

}