using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    private int _currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;

        Vector3 currentPosition = transform.position;
        Vector3 newPosition = waypoints[_currentWaypointIndex].position;

// Ajusta la posición para permitir solo movimiento vertical y horizontal
        if (Mathf.Abs(newPosition.x - currentPosition.x) > Mathf.Abs(newPosition.z - currentPosition.z))
        {
            newPosition.z = currentPosition.z;
        }
        else
        {
            newPosition.x = currentPosition.x;
        }

        Vector3 direction = newPosition - currentPosition;
        direction.y = 0;
        transform.position += direction.normalized * (speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[_currentWaypointIndex].position) < 0.1f)
        {
            // Obtener un índice de waypoint aleatorio
            int newIndex = Random.Range(0, waypoints.Length);

            // Asegurarse de que no se seleccione el mismo waypoint actual
            while (newIndex == _currentWaypointIndex)
            {
                newIndex = Random.Range(0, waypoints.Length);
            }

            _currentWaypointIndex = newIndex;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            // Obtener un índice de waypoint aleatorio
            int newIndex = Random.Range(0, waypoints.Length);

            // Asegurarse de que no se seleccione el mismo waypoint actual
            while (newIndex == _currentWaypointIndex)
            {
                newIndex = Random.Range(0, waypoints.Length);
            }

            _currentWaypointIndex = newIndex;
        }
    }
}

