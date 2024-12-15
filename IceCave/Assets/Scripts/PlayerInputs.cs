using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public FreezeSelector freezeSelector;
    
    public Animator animator;
    
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
            
            animator.SetBool("left", false);
            animator.SetBool("down", false);
            animator.SetBool("right", false);
            
            animator.SetBool("up", true);

        }
        else if (Input.GetKey("a")) {
            movementVector = Vector2.left;
            
            animator.SetBool("up", false);
            animator.SetBool("down", false);
            animator.SetBool("right", false);
            
            animator.SetBool("left", true);
        }
        else if (Input.GetKey("s")) {
            movementVector = Vector2.down;
            
            animator.SetBool("left", false);
            animator.SetBool("up", false);
            animator.SetBool("right", false);
            
            animator.SetBool("down", true);

        }
        else if (Input.GetKey("d")) {
            movementVector = Vector2.right;
            
            animator.SetBool("left", false);
            animator.SetBool("down", false);
            animator.SetBool("up", false);
            
            animator.SetBool("right", true);

        }
        else {
            movementVector = Vector2.zero;
            animator.SetBool("left", false);
            animator.SetBool("down", false);
            animator.SetBool("right", false);
            animator.SetBool("up", false);
        }
    }
    
    private void FixedUpdate()
    {
        playerMovement.MovePlayer(movementVector);
    }
}
