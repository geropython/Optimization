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

        Vector3 direction = waypoints[_currentWaypointIndex].position - transform.position;
        direction.y = 0;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.z))
        {
            direction.z = 0;
        }
        else
        {
            direction.x = 0;
        }

        transform.position += direction.normalized * (speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[_currentWaypointIndex].position) < 0.1f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        }
    }
    
}
