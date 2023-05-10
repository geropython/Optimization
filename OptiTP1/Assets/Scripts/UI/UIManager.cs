using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemiesKilledText;
    [SerializeField] private TextMeshProUGUI ammoUsedText;

    private void Start()
    {
        UpdateEnemiesKilled(0);
        UpdateAmmoUsed(0);
    }

    public void UpdateEnemiesKilled(int amount)
    {
        enemiesKilledText.text = amount.ToString();
    }

    public void UpdateAmmoUsed(int amount)
    {
        ammoUsedText.text = amount.ToString();
    }
}