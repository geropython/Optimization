using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSkip : ManagedUpdateBehaviourUI
{
    public override void UpdateMe()
    {
        var scene = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(scene + 1);
    }
}