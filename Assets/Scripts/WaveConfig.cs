using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject pathPrefab;
    [SerializeField] private float timeBetweenSpawns = 0.5f;
    [SerializeField] private float spawnRandomFactor = 0.3f;
    [SerializeField] private int numberOfEnemies = 5;
    [SerializeField] private float moveSpeed = 2f;

    public GameObject EnemyPrefab
    {
        get{ return enemyPrefab; }
    }

    public List<Transform> GetWayPoints
    {
        get {
            var waveWayPoints = new List<Transform>();

            foreach(Transform child in pathPrefab.transform)
            {
                waveWayPoints.Add(child);
            }

            return waveWayPoints;
        }
    }

    public float TimeBetweenSpawns
    {
        get { return timeBetweenSpawns; }
    }

    public float SpawnRandomFactor
    {
        get { return spawnRandomFactor; }
    }

    public int NumberOfEnemies
    {
        get { return numberOfEnemies; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }
}
