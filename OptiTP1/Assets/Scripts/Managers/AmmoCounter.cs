using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoCounter : MonoBehaviour
{
     private int bulletsShot = 0;
     public TextMeshProUGUI ammoText;

    void Start()
    {
        ammoText = GetComponent<TextMeshProUGUI>();

        UpdateAmmoText();
    }

    public void IncrementBulletsShot()
    {
        bulletsShot+=1;
        UpdateAmmoText();
    }

    private void UpdateAmmoText()
    {
        ammoText.text = "" + bulletsShot;
    }


}
