using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Helf
public class HealthParent : MonoBehaviour
{
    public GameObject dot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Change the UI
    public void SetHealth(int helf)
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < helf; i++)
        {
            GameObject.Instantiate(dot, transform);
        }
    }
}
