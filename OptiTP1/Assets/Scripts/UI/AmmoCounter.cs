using UnityEngine;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
    private int _bulletsShot = 0;
    private TextMeshProUGUI _ammoText;

    private void Start()
    {
        // OPTIMIZAME PORFA ALGUN DIA
        var textMesh = FindObjectsOfType<TextMeshProUGUI>();
        foreach (var mesh in textMesh)
            if (mesh.name == "AmmoCounter")
                _ammoText = mesh;

        UpdateAmmoText();
    }

    public void IncrementBulletsShot()
    {
        _bulletsShot++;
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        _ammoText.text = "" + _bulletsShot;
    }
}