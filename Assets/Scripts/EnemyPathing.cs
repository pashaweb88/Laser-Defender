using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private WaveConfig waveConfig;

    private List<Transform> waypoints = new List<Transform>();

    

    private int wayPointIndex = 0;

    
    public void SetWaveConfig (WaveConfig currentWave)
    {
        this.waveConfig = currentWave;
    }
    
    private void Start()
    {
        waypoints = waveConfig.GetWayPoints;

        transform.position = waypoints[0].transform.position;
    }

    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        if (wayPointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[wayPointIndex].transform.position;
            var movementThisFrame = waveConfig.MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
