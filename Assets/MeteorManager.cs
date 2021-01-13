using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorManager : MonoBehaviour
{
    public Meteor meteorPrefab;

    public GameObject gameOverPanel;

    public HealthParent healthParent;

    public Text textScore;
    public Text textTime;

    public float timeSpawn = 1f;    // Seconds to wait before spawning a new meteor
    float timer = 0f;

    float gameTimer = 0f;

    int health = 4;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (healthParent) healthParent.SetHealth(health);

        if(textScore)
        {
            textScore.text = 0.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Count how many seconds are passing
        timer += Time.deltaTime;
        gameTimer += Time.deltaTime;

        UpdateTimeText(gameTimer);

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

    void UpdateTimeText(float t)
    {
        if (textTime) textTime.text = Mathf.FloorToInt(t).ToString();
        else Debug.LogError("No reference");
    }

    /// <summary>
    /// Decrease player health.
    /// </summary>
    public void LoseHealth()
    {
        health--;

        print("Health: " + health);

        if(healthParent) healthParent.SetHealth(health);    // Update UI

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
        score += 100;

        print("Score: " + score);

        if (textScore) textScore.text = score.ToString();
        else Debug.LogError("No reference");
    }

    /// <summary>
    /// End the game! Stop the game.
    /// </summary>
    void GameOver()
    {
        Time.timeScale = 0f;    // Freezes time in Unity!

        gameOverPanel.SetActive(true);

        print("Game Over");
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
