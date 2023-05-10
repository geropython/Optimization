using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
 
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // carga la escena del menú principal
        
    }
    

}
