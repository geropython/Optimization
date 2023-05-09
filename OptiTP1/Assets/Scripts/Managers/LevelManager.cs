using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        // ESTO ME TIRA ERROR EN EL BUILDEO.
        // if (Application.isEditor)
        //     EditorApplication.isPlaying = false;
        // else
        //     Application.Quit();
        
        //ESTO NO.
        Application.Quit();
        print("Exit Game");
    }
    
}