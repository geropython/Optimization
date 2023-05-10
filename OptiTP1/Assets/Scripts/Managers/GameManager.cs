using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int _enemiesDestroyed = 95; // contador de enemigos eliminados
    private int _bulletsShot = 0; // contador de balas disparadas

    [SerializeField] private GameObject tankPrefab; // prefab del tanque
    [SerializeField] private Transform spawnPoint;
   
    public Transform SpawnPoint => spawnPoint; // punto de spawn del tanque
    public static GameManager Instance { get; private set; }
    public ProjectileManager ProjectilePool { get; private set; }
    public CustomUpdateManager CustomGameplayUpdate { get; private set; }
    public CustomUpdateManagerUI CustomUIUpdate { get; private set; }
    public UIManager UIManager { get; private set; }

    
    //SINGLETON-------------------------
    private void Awake()
    {
        // Si ya hay otra instancia, destruye ésta.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        // De lo contrario, propone ésta como instancia.
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        SpawnTank();
        ProjectilePool = GetComponent<ProjectileManager>();
        CustomGameplayUpdate = GetComponent<CustomUpdateManager>();
        CustomUIUpdate = GetComponent<CustomUpdateManagerUI>();
        UIManager = GetComponent<UIManager>();
    }

    private void Start()
    {
        ProjectilePool.ResetPool();
        Cursor.visible = false;
    }

    private void SpawnTank()
    {
        // spawn del tanque en el punto designado desde el inspector
        Instantiate(tankPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void EnemyDestroyed() //Llamar a esto cuando se destruye un enemy en Script de Enemy?¿ ---> CONSULTAR A MAXI
    {
        _enemiesDestroyed++;
        UIManager.UpdateEnemiesKilled(_enemiesDestroyed);
        if (_enemiesDestroyed >= 100) WinGame();
    }

    public void AmmoCounter()
    {
        _bulletsShot++;
        UIManager.UpdateAmmoUsed(_bulletsShot);
    }

    private void WinGame()
    {
       UIManager.Win();
    }

    public void RestartGameLoop()
    {
        
    }
}