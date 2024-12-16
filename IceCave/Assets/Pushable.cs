using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    [SerializeField] private float pushTime;
    private Vector2 lerpPosition;
    [SerializeField] private bool testMove;
    public bool isMoving { get; private set; }

    public Vector2 lastPushDir { get; private set; } = Vector2.zero;

    private List<Pushable> connectedPushables = new List<Pushable>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        

        if(testMove == true) // PLEASE DONT LOOK AT THIS !! D:
        {
            if (Input.GetKeyDown("w"))
            {
                tryPush(new Vector2(0, 1));
            }
            else if (Input.GetKeyDown("a"))
            {
                tryPush(new Vector2(-1, 0));
            }
            else if (Input.GetKeyDown("s"))
            {
                tryPush(new Vector2(0, -1));
            }
            else if (Input.GetKeyDown("d"))
            {
                tryPush(new Vector2(1, 0));
            }
        }
        

        
    }

    private void FixedUpdate()
    {
        if (lerpPosition != Vector2.zero)
        {
            transform.position = Vector2.Lerp(transform.position, lerpPosition, pushTime);
            if ((Vector2)transform.position == lerpPosition)
            {
                lerpPosition = Vector2.zero;
                isMoving = false;
            }
        }
    }

    public void tryPush(Vector2 direction)
    {
        if (isMoving)
            return;

        connectedPushables = new List<Pushable>();

        connectedPushables.Add(this);

        RaycastHit2D hit = Physics2D.Linecast((Vector2)transform.position, (Vector2)transform.position + direction);

        if (hit)
        {
            while (hit.collider != null && (hit.transform.tag == "immovables" || hit.transform.tag == "pushables"))
            {
                if (hit.collider.transform.tag == "immovables")
                {
                    Debug.Log("Can't move!");

                    return;
                }

                

                if (hit.collider.GetComponent<Pushable>() != null)
                {
                    connectedPushables.Add(hit.collider.GetComponent<Pushable>());

                    Pushable currentPushable = connectedPushables[connectedPushables.Count - 1];

                    hit = Physics2D.Linecast(currentPushable.transform.position, (Vector2)currentPushable.transform.position + direction);
                }

                
            }
        }

        if(connectedPushables.Count > 0)
        {
            foreach (Pushable pushable in connectedPushables)
            {
                pushable.doPush(direction);
            }
        }

        lastPushDir = direction;
    }

    public void doPush(Vector2 direction)
    {
        
        isMoving = true;
        lerpPosition = (Vector2)transform.position + direction;
    }
}
