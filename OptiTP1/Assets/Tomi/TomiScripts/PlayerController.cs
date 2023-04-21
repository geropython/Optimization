using UnityEngine;

namespace Tomi.TomiScripts
{
    public class PlayerController : MonoBehaviour
    {
        //Variables de Movimiento
        [SerializeField] private float speed = 5.0f;

        //Variables de SpawnPoint
        [SerializeField] private Transform spawnPoint;
        private Rigidbody _playerRigidbody;

        //Variables básicas
        private Transform _playerTransform;

        private void Start()
        {
            //Obtengo los componentes Transform y RigidBody Del Player.
            _playerTransform = GetComponent<Transform>();
            _playerRigidbody = GetComponent<Rigidbody>();

            //Asigno la posición del spawnPoint al transform del jugador al inicio.
            if (spawnPoint != null)
            {
                _playerTransform.position = spawnPoint.position;
                _playerTransform.rotation = spawnPoint.rotation;
            }
        }

        private void FixedUpdate()
        {
            //Se obtiene el input del usuario ya sea con W,A,S,D  o Analógicos.
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            var verticalInput = Input.GetAxisRaw("Vertical");

            //Vector de movimiento que funciona con el input creado anteirormente.
            var movement = new Vector3(horizontalInput, 0.0f, verticalInput);

            // Si el vector de movimiento es  distinto de cero, rotamos el objeto del jugador en la dirección del movimiento.
            if (movement != Vector3.zero) _playerTransform.rotation = Quaternion.LookRotation(movement);

            // Movemos el PLayer en la dirección del vector de movimiento normalizado, multiplicado por la velocidad y el tiempo entre actualizaciones de física.
            _playerRigidbody.MovePosition(_playerTransform.position +
                                          movement.normalized * (speed * Time.fixedDeltaTime));
        }

        //Este método permite cambiar el spawnPoint desde el Editor.
        public void SetSpawnPoint(Transform newSpawnPoint)
        {
            spawnPoint = newSpawnPoint;
        }
    }
}