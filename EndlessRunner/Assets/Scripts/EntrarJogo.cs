using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarJogo : MonoBehaviour{

    private bool jogoIniciado = false;

    public void PlayGame()
    {
        GameManager.inst.ResetGame(); // Certifique-se de que o jogo esteja resetado antes de iniciá-lo
        SceneManager.LoadScene(1);
        GameManager.inst.StartGame(); // Defina o jogo como iniciado após carregar a cena correta
    }

}