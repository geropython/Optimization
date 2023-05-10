using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemiesKilledText;

    private void Start()
    {
        IncrementEnemiesKilled(0);
    }

    public void IncrementEnemiesKilled(int amount)
    {
        enemiesKilledText.text = amount.ToString();
    }
}