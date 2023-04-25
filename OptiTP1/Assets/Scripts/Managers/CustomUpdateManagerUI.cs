using UnityEngine;

// Las justificaciones o aplicaciones de patrones estan comentadas en el script CustomUpdateManager
// Este script es una copia con algunas variables diferentes
public class CustomUpdateManagerUI : MonoBehaviour
{
    private ManagedUpdateBehaviourUI[] _list;
    private const float FRAME_TIME_30 = 0.03333f;
    private const float FRAME_TARGET = 30f;
    private float _tempTime;

    private void Awake()
    {
        _list = FindObjectsOfType<ManagedUpdateBehaviourUI>();
    }

    private void Update()
    {
        UpdateVersion1();
    }

    private void UpdateVersion1()
    {
        _tempTime += Time.deltaTime;
        if (!(_tempTime >= FRAME_TIME_30)) return;
        var count = _list.Length;
        for (var i = 0; i < count; i++) _list[i].UpdateMe();

        _tempTime = 0;
    }

    private void UpdateVersion2()
    {
        if (Time.frameCount % FRAME_TARGET != 0) return;
        var count = _list.Length;
        for (var i = 0; i < count; i++) _list[i].UpdateMe();
    }
}