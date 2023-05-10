using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f; // reanuda el tiempo
       
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
        
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        if (Application.isEditor)
            EditorApplication.isPlaying = false;
        else
            Application.Quit();
#endif
        Application.Quit();
    }
}