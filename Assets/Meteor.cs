using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 6f;    // How fast is our meteor?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move downward
        transform.position += (Vector3.down * speed * Time.deltaTime);


        // Get rid of our meteor if we fall too far off screen
        if (transform.position.y < -200f)
        {
            Destroy(gameObject);
        }
    }
}
