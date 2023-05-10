using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSkip : ManagedUpdateBehaviourUI
{
    private int _currSceneIndex;

    private void Awake()
    {
        _currSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public override void UpdateMe()
    {
        if (Input.GetKey(KeyCode.Space)) SceneManager.LoadScene(_currSceneIndex + 1);
    }
}