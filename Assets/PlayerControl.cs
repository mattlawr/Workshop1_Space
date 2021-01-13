/**
 * For "Creating Your First Game in Unity" Workshop
 * 11/2/2020
 * Created by VGDC
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 20f;   // How fast does the ship move?

    public GameObject shootPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.timeScale == 0f) return;   // If game is paused don't let the player be controlled!

        // Movement
        float horizontal = 0f;

        // If we are pressing a move key AND we are not too far left/right on the screen...
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 20f)
        {
            horizontal = 1f;    // We are pressing right!
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -20f)
        {
            horizontal = -1f;    // We are pressing left!
        }

        // MOVE our player to the left or to the right
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);


        // If we are pressing space...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire(); // FIRE a bullet!
        }
    }

    /// <summary>
    /// This method will spawn a bullet prefab at our player position
    /// </summary>
    void Fire()
    {
        GameObject bullet = Instantiate(shootPrefab, transform.position, transform.rotation);
    }
}
