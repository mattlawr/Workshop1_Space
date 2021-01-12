using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 6f;    // How fast is our meteor?
    public float endPoint = -20f;   // How far should we fall before dealing damage

    MeteorManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Remember our manager for later, and rotate randomly
    public void Init(MeteorManager m)
    {
        manager = m;
        transform.rotation = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Move downward
        transform.position += (Vector3.down * speed * Time.deltaTime);


        // Get rid of our meteor if we fall too far off screen
        if (transform.position.y < endPoint)
        {
            DieOffScreen();
        }
    }

    // When falling past player
    private void DieOffScreen()
    {
        // Decrease health
        if (manager) manager.LoseHealth();

        Destroy(gameObject);
    }

    // When shot by bullet
    public void Die()
    {
        // Increase score
        if (manager) manager.ScorePoint();

        Destroy(gameObject);
    }
}
