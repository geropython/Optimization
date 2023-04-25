using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSkip : ManagedUpdateBehaviourUI
{
    public string _nextScene;

    void Start()
    {
        // Hides the cursor...

        Cursor.visible = false;
    }
    //public override void UpdateMe()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        print("IF");
    //        SceneManager.LoadScene("MainMenu");
    //    }
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(_nextScene);
        }
    }

}
