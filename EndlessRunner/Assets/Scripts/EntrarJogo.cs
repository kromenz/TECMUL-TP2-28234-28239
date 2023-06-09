using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarJogo : MonoBehaviour{

    private bool jogoIniciado = false;

    public void PlayGame()
    {
        GameManager.inst.StartGame();  // Chama o método StartGame() do GameManager
        SceneManager.LoadScene(1);
    }
}