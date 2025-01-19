using UnityEngine;

public class Slippery : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    Pushable pushable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        Debug.Log("hit");
        pushable = collision.GetComponent<Pushable>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pushable != null && pushable.isMoving == false)
        {

            if(pushable.canPush(pushable.lastPushDir) == false)
                pushable = null;
            else
            {
                pushable.tryPush(pushable.lastPushDir);
                pushable = null;
            }
                
        }
    }
}
