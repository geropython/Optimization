using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject tankPrefab; // prefab del tanque
    [SerializeField] private Transform spawnPoint; // punto de spawn del tanque
    
    private int _enemiesDestroyed = 0; // contador de enemigos eliminados
    public static GameManager Instance { get; private set; }
    public ProjectileManager ProjectilePool { get; private set; }

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
    
    public void EnemyDestroyed()  //Llamar a esto cuando se destruye un enemy en Script de Enemy?¿ ---> CONSULTAR A MAXI
    {
        _enemiesDestroyed++;
        if (_enemiesDestroyed >= 100)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        //PlaceHolder
        SceneManager.LoadScene("Win");
    }
}