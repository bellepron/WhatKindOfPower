using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZ_Pooling;

public class SpawnManager : MonoBehaviour, IEndGameObserver
{
    // public GameObject[] enemyPrefabs;
    [SerializeField] Transform hydra_Prefab;

    private float spawnRangeX = 4;
    private float spawnPosZ = 80;
    public float startDelay = 1;
    GameSceneController gameSceneController;
    [HideInInspector] public float spawnInterval;
    [HideInInspector] public float hydraSpeed;
    [HideInInspector] public float chimeraSpeed;
    CheckeredFloor checkeredFloor;
    bool canContinue;

    public void StartSpawning()
    {
        gameSceneController = FindObjectOfType<GameSceneController>();

        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);

        checkeredFloor = FindObjectOfType<CheckeredFloor>();

        GameManager.Instance.AddObserver(this);
    }

    void SpawnRandomEnemy()
    {
        spawnPosZ = InputHandler.Instance.transform.position.z + 100;
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        // int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        // Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);



        // Hydra hydra = Instantiate(Resources.Load("Hydra"), spawnPos, Quaternion.identity) as Hydra;
        // GameObject hydra_GO = Instantiate(Resources.Load("Hydra"), spawnPos, Quaternion.Euler(0, 180, 0)) as GameObject;
        Transform hydra_GO = EZ_PoolManager.Spawn(hydra_Prefab, spawnPos, Quaternion.Euler(0, 180, 0)) as Transform;
        Hydra hydra = hydra_GO.gameObject.GetComponent<Hydra>();
        // hydra.gameObject.layer = LayerMask.NameToLayer("Dynamic");
        hydra.speed = gameSceneController.currentLevel.hydraSpeed;
    }

    public void DespawnEnemy_Hydra(Transform t)
    {
        EZ_PoolManager.Despawn(t);
    }

    public void GameEnd()
    {
        CancelInvoke("SpawnRandomEnemy");

        GameManager.Instance.RemoveObserver(this);
    }
}