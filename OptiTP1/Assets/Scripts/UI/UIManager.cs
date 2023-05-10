using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemiesKilledText;
    [SerializeField] private TextMeshProUGUI enemiesRemainText;
    [SerializeField] private TextMeshProUGUI ammoUsedText;
    [SerializeField] private GameObject winPanel;

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

    public void UpdateEnemiesRemainText(int amount)
    {
        enemiesRemainText.text = amount.ToString();
    }

    public void Win()
    {
        Time.timeScale = 0f; // detiene el tiempo
        winPanel.SetActive(true); // activa el panel de victoria
        Logging.Log("Win Game");
    }
}