using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    private void Start(){
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!isPaused){
                PauseGame();
            }
            else{
                ResumeGame();
            }
        }
    }

    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f; // Definir o Time.timeScale como 1 para retomar o jogo
        isPaused = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1.0f; // Certifique-se de redefinir o Time.timeScale para 1 antes de sair
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("Menu"); // Substitua "MenuPrincipal" pelo nome da sua cena do menu principal
    }

}
