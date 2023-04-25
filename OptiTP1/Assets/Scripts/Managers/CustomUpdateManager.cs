using UnityEngine;

public class CustomUpdateManager : MonoBehaviour
{
    private ManagedUpdateBehaviour[] _list;

    // No se si utilizar variables constantes cuenta como Hashing ya que no es una tabla
    private const float FRAME_TIME_60 = 0.01666f;
    private const int FRAME_TARGET = 60;
    private float _tempTime;

    private void Awake()
    {
        // Precomputation porque busca todos los objetos al comienzo de la escena
        // Esto se podria hacer cada vez que trata de hacer un update pero no seria optimo
        _list = FindObjectsOfType<ManagedUpdateBehaviour>();
    }

    private void Update()
    {
        UpdateVersion1();
    }

    private void UpdateVersion1()
    {
        _tempTime += Time.deltaTime;
        // Lazy computation porque retrasa toda la parte que sigue hasta que es necesaria porque se cumple la condicion¿?¿?
        // No me parece correcto porque sino todos los IF son lazy computation
        if (!(_tempTime >= FRAME_TIME_60)) return;
        // Caching para luego utilizar este valor en el for 
        // Este valor se podria poner directo en el for, pero cada iteracion lo tendria que volver a calcular
        var count = _list.Length;
        for (var i = 0; i < count; i++) _list[i].UpdateMe();

        _tempTime = 0;
    }

    // Se puede optimizar la version 1 usando el metodo a continuacion, si esto funcionara :(
    // la optimizacion seria que en ningun momento tiene que guardar una variable extra (_tempTime) ahorrando espacio en memoria
    private void UpdateVersion2()
    {
        if (Time.frameCount % FRAME_TARGET != 0) return;
        var count = _list.Length;
        for (var i = 0; i < count; i++) _list[i].UpdateMe();
    }
}