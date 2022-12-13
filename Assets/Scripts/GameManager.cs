using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] fruitPrefabs;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gameWon;
    [SerializeField] GameObject[] fruits;

    [SerializeField] AudioSource gameMusic;
    AudioSource endGameMusic;

    public static int score;
    public static int lives = 3;

    public static bool gameIsOver = false;

    // Start is called before the first frame update
    public void Start()
    {
        endGameMusic = GetComponent<AudioSource>();
        InvokeRepeating("FruitSpawn", 1, 1);
    }

    void FruitSpawn()
    {
        int randomIndex = Random.Range(0, fruitPrefabs.Length);
        Instantiate(fruitPrefabs[randomIndex], SpawnLocation(), /*Quaternion.Euler(-90, 180, 0)*/ Quaternion.identity);
    }

    public Vector3 SpawnLocation()
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
        if(score >= 10)
        {
            GameWon();
        }
    }

    private void EndGame()
    {
        fruits = GameObject.FindGameObjectsWithTag("Fruit");
        CancelInvoke("FruitSpawn");
        lives = 3;
        score = 0;
        
        for (int i = 0; i < fruits.Length; i++)
        {
            Destroy(fruits[i]);
        }
        gameOver.SetActive(true);
        gameMusic.Stop();

        endGameMusic.Play();
        gameIsOver = true;
    }

    void GameWon()
    {
        fruits = GameObject.FindGameObjectsWithTag("Fruit");
        CancelInvoke("FruitSpawn");
        lives = 3;
        score = 0;

        for (int i = 0; i < fruits.Length; i++)
        {
            Destroy(fruits[i]);
        }
        gameWon.SetActive(true);
        gameMusic.Stop();

        endGameMusic.Play();
        gameIsOver = true;
    }
}
