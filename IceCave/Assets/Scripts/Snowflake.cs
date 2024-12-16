using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Snowflake : MonoBehaviour
{
    //holds the amount of snowflakes that have been picked up in order to open the door
    public static int collectedSnowflakes = 0;
    public static List<int> collectedStages = new List<int>();
    
    public Collider2D collider;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (int stage in collectedStages)
        {
            if (stage == SceneManager.GetActiveScene().buildIndex)
            {
                Destroy(gameObject);
                break;
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        collectedSnowflakes++;
        Debug.Log(collectedSnowflakes);
        //display particle effect or snowflake flying off screen here
        collectedStages.Add(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    }
}
