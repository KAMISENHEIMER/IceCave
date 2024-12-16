using UnityEngine;

public class Slippery : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("hit");
        Pushable pushable = collision.GetComponent<Pushable>();
        if (pushable != null)
        {
            pushable.tryPush(pushable.lastPushDir);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
