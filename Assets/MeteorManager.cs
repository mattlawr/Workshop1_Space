using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    public GameObject meteorPrefab;

    public float timeSpawn = 1f;    // Seconds to wait before spawning a new meteor
    float timer = 0f;

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
        float randomX = Random.Range(-15f, 15f);

        GameObject m = Instantiate(meteorPrefab, transform.position + Vector3.right * randomX, transform.rotation);
    }
}
