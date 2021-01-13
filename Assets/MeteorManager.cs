using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    public Meteor meteorPrefab;

    public float timeSpawn = 1f;    // Seconds to wait before spawning a new meteor
    float timer = 0f;

    int health = 3;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Count how many seconds are passing
        timer += Time.deltaTime;

        // If we have passed a certain amount of seconds...
        if (timer > timeSpawn)
        {
            Spawn();    // Spawn a meteor!
            timer = 0f; // Reset our time counter!
        }
    }

    /// <summary>
    /// Spawns a meteor at this object position but with random X axis offset
    /// </summary>
    void Spawn()
    {
        if (!meteorPrefab)
        {
            Debug.LogError("Meteor prefab not set in Meteor Manager!");
            return;
        }

        float randomX = Random.Range(-15f, 15f);

        Meteor m = Instantiate(meteorPrefab, transform.position + Vector3.right * randomX, transform.rotation);

        m.Init(this);   // Tells the meteor some important info
    }

    /// <summary>
    /// Decrease player health.
    /// </summary>
    public void LoseHealth()
    {
        health--;

        print("Health: " + health);

        if(health <= 0)
        {
            health = 0;

            GameOver();
        }
    }

    /// <summary>
    /// Increase score
    /// </summary>
    public void ScorePoint()
    {
        score++;

        print("Score: " + score);
    }

    /// <summary>
    /// End the game! Stop the game.
    /// </summary>
    void GameOver()
    {
        Time.timeScale = 0f;    // Freezes time in Unity!

        print("Game Over");
    }
}
