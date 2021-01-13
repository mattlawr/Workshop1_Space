using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 60f;   // How fast is our bullet?

    public AudioClip hitClip;   // Explosion sound
    public GameObject fxPrefab; // Explosion effect

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move upward
        rb.position += (Vector3.up * speed * Time.deltaTime);


        // Get rid of our bullet if we go far off screen...
        if (rb.position.y > 200f)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the meteor we just hit
        if (collision.gameObject)
        {
            Destroy(collision.gameObject);

            AudioSource.PlayClipAtPoint(hitClip, transform.position);

            GameObject fx = Instantiate(fxPrefab, transform.position, transform.rotation);
            Destroy(fx, 4f);
        }

        // Destroy THIS bullet
        Destroy(gameObject);
    }
}
