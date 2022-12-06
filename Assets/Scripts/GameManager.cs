using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] fruitPrefabs;

    public static int score;
    public static int lives = 3;

    // Start is called before the first frame update
    public void Start()
    {
        InvokeRepeating("FruitSpawn", 1, 1);
    }

    void FruitSpawn()
    {
        int randomIndex = Random.Range(0, fruitPrefabs.Length);
        Instantiate(fruitPrefabs[randomIndex], SpawnLocation(), /*Quaternion.Euler(-90, 180, 0)*/ Quaternion.identity);
    }

    Vector3 SpawnLocation()
    {
        Vector3 spawnLocation;
        float randomFloat = Random.Range(-10, 10);
        spawnLocation = new Vector3(randomFloat, -6, 0);
        return spawnLocation;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        print("you lost");
    }
}
