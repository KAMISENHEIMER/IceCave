using UnityEngine;

public class Button : MonoBehaviour
{
    // The door that this button opens
    public GameObject door;
    Collider2D doorCollider;
    
    Animator animator;
    Animator doorAnimator;

    void Start()
    {
        doorCollider = door.GetComponent<Collider2D>();
        animator = gameObject.GetComponent<Animator>();
        doorAnimator = door.GetComponent<Animator>();
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("Button Pressed");
        doorCollider.enabled = false;
        animator.SetBool("buttonDown", true);
        doorAnimator.SetBool("buttonDown", true);

    }
    
    void OnTriggerExit2D(Collider2D otherCollider)
    {
        Debug.Log("Button Unpressed");
        doorCollider.enabled = true;
        animator.SetBool("buttonDown", false);
        doorAnimator.SetBool("buttonDown", false);

    }
}
