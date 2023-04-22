using System.Runtime;
using UnityEngine;

namespace Tomi.TomiScripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed; // velocidad del tanque
        [SerializeField] private GameObject tankPrefab; // prefab del tanque
        [SerializeField] private Transform spawnPoint; // punto de spawn del tanque
        [SerializeField] private Rigidbody rb;

        private void Update()
        {
            var input = Input.GetAxis(Input.GetButton("Horizontal")
                ? "Horizontal"
                : "Vertical"); // obtiene el input horizontal o vertical correspondiente
            var direction = Vector3.zero;

            // establece la dirección en la que se mueve el tanque
            if (Input.GetButton("Horizontal"))
                direction = new Vector3(input, 0, 0);
            else if (Input.GetButton("Vertical")) direction = new Vector3(0, 0, input);
            // Esto para que solo se puieda mover en 4 direcciones.
            // mueve el tanque en la dirección adecuada (solo en horizontal o vertical)
            rb.velocity = direction * speed;

            // hace que el cañón del tanque mire en la dirección en la que se está moviendo
            if (direction != Vector3.zero)
                transform.GetChild(0)
                    .LookAt(transform.position + direction); // suponiendo que el cañón es el primer hijo del tanque
        }

        //Dale, si. El POOL USAMOS EL DEL PROFE? O E DE UNITY?? SI, ESTA EN EL DISCORD.
        public void SpawnTank()
        {
            // spawn del tanque en el punto designado desde el inspector
            Instantiate(tankPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}