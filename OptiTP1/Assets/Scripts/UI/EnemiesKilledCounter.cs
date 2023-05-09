using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemiesKilledCounter : MonoBehaviour
{
    private int _enemiesKilled = 0;
    private TextMeshProUGUI _killedText;
    
    
    
    private void Start()
    {
        // OPTIMIZAME PORFA ALGUN DIA
        var textMesh = FindObjectsOfType<TextMeshProUGUI>();
        foreach (var mesh in textMesh)
            if (mesh.name == "EnemiesKilledText")
                _killedText = mesh;

        UpdateEnemiesKilledText();
    }
    
    
    public void IncrementEnemiesKilled()
    {
        _enemiesKilled++;
        UpdateEnemiesKilledText();
        if (_enemiesKilled >= 100)
        {
            
        }
    }
    
    
    private void UpdateEnemiesKilledText()
    {
        _killedText.text = "" + _killedText;
    }
    
    
}
