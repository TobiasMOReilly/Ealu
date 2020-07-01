using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField] private SO_Enemy enemyData;
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private GameObject EnemyPrefab;

    [SerializeField] private int enemyCount;
    [SerializeField] private Transform enemySpawn;

    [SerializeField] private int spawnGridDepth;
    [SerializeField] private int spawnGridWidth;
    [SerializeField] private int spawnGridSpacing;

    [SerializeField] private Transform target;

    // Use this for initialization
    void Start () {
        SpawnEnemiesFormation();
        AssignTarget();
    }

	//Populate the enemies list with enemies, amount = enemyCount
    private void PopulateEnemyList()
    {
        for(int i=0; i<enemyCount; i++)
        {
            enemies.Add(EnemyPrefab);
        }
    }

    //Spawn enemies in formation
    private void SpawnEnemiesFormation()
    {
        for(int i=0; i < spawnGridWidth; i++)
        {
            for (int j = 0; j < spawnGridDepth; j++)
            {
                Vector3 position = enemySpawn.position + new Vector3(i, 0, j) * spawnGridSpacing;
                enemies.Add(Instantiate(EnemyPrefab, position, Quaternion.identity));
            }
        }
        
    }

    private void AssignTarget()
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<FieldOfView>().SetFOVTarget(target);
            enemy.GetComponent<Hearing>().SetTarget(target);
        }
    }
}
