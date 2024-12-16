using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerInputs : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public FreezeSelector freezeSelector;
    
    public Animator animator;
    
    private Vector2 movementVector;

    private bool mouseDown;
    private Vector2 mousePosition;

    private Vector2 lastMovedDirection;

    [SerializeField] private Vector2 facingDirection;
    
    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
        if (movementVector != Vector2.zero)
        {
            
            facingDirection = movementVector;
            //new Vector2(Mathf.Round(movementVector.x), Mathf.Round(movementVector.y)
        }
        movementVector.Normalize();

        animator.SetBool("isMoving", movementVector != Vector2.zero);
        animator.SetFloat("Horizontal", facingDirection.x);
        animator.SetFloat("Vertical", facingDirection.y);


        Debug.DrawLine((Vector2)transform.position, (Vector2)transform.position + facingDirection / 1.5f);

        if (Input.GetKeyDown("space")) {
            
            RaycastHit2D hit = Physics2D.Linecast((Vector2)transform.position, (Vector2)transform.position + facingDirection/1.5f);
            
            if (hit && hit.collider != null && hit.transform.tag == "pushables" && hit.collider.GetComponent<Pushable>() != null)
            {
                float xOffset = transform.position.x - hit.collider.transform.position.x;
                float yOffset = transform.position.y - hit.collider.transform.position.y;


                StartCoroutine("ToggleAnimBool", "isPushing");
                if (Mathf.Abs(xOffset) > Mathf.Abs(yOffset))
                    hit.collider.GetComponent<Pushable>().tryPush(new Vector2(-Mathf.Sign(xOffset), 0));
                else
                    hit.collider.GetComponent<Pushable>().tryPush(new Vector2(0, -Mathf.Sign(yOffset)));



            }
        }

        // converts mouse position from screen coordinates to game coordinates  
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D hitFreeze = Physics2D.OverlapPoint(mousePosition);
        if (hitFreeze && hitFreeze.name == "Water")
        {
            freezeSelector.moveSelector(mousePosition);

            if (Input.GetButtonDown("Fire1"))
            {
                freezeSelector.freeze(hitFreeze);
            }
        }
        else
        {
            freezeSelector.hideSelector();
        }
        
        //resets the level
        if (Input.GetKeyDown("r"))
        {
            //loads the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    
    private void FixedUpdate()
    {
        playerMovement.MovePlayer(movementVector);
    }

    IEnumerator ToggleAnimBool(string animBool)
    {
        animator.SetBool(animBool, true);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool(animBool, false);
    }
}
