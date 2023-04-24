using UnityEngine;

namespace Tomi.TomiScripts
{
    public class GameManager : MonoBehaviour
    {
        //Variable del PLayerTank
        [SerializeField] private GameObject tankPrefab; // prefab del tanque
        [SerializeField] private Transform spawnPoint; // punto de spawn del tanque
        
        // Singleton instance variable
        private static GameManager _instance;

        // Propiedad publica para acceder a la variable.
        public static GameManager Instance
        {
            get { return _instance; }
        }

        private void Awake()
        {
            // Si ya hay otra instancia, destruye ésta.
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            // De lo contrario, propone ésta como instancia.
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            
            SpawnTank();
        }

        public void SpawnTank()
        {
            // spawn del tanque en el punto designado desde el inspector
            Instantiate(tankPrefab, spawnPoint.position, Quaternion.identity);
        }
        
    }
}
