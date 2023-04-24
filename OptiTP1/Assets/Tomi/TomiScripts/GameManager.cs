using UnityEngine;

namespace Tomi.TomiScripts
{
    public class GameManager : MonoBehaviour
    {
        //Variable del PLayerTank
        [SerializeField] private GameObject tankPrefab; // prefab del tanque
        [SerializeField] private Transform spawnPoint; // punto de spawn del tanque

        // Singleton instance variable

        // Propiedad publica para acceder a la variable.
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
        }

        private void SpawnTank()
        {
            // spawn del tanque en el punto designado desde el inspector
            Instantiate(tankPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}