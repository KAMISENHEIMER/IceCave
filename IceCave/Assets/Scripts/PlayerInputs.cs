using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public FreezeSelector freezeSelector;
    
    private Vector2 movementVector;

    // Update is called once per frame
    void Update()
    {
        /*
        //gets input directions for X and Y
        
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = Input.GetAxis("Vertical");
        
        //makes sure diagonal movement is the same speed as vertical/horizontal
        movementVector = movementVector.normalized;
        */
        // I like this, but i dont think diagonal movement works with our game
        
        if (Input.GetKey("w")) {
            movementVector = Vector2.up;
        }
        else if (Input.GetKey("a")) {
            movementVector = Vector2.left;
        }
        else if (Input.GetKey("s")) {
            movementVector = Vector2.down;
        }
        else if (Input.GetKey("d")) {
            movementVector = Vector2.right;
        }
        else {
            movementVector = Vector2.zero;
        }
    }
    
    private void FixedUpdate()
    {
        playerMovement.MovePlayer(movementVector);
    }
}
