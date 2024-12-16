using UnityEngine;

public class Button : MonoBehaviour
{
    // The door that this button opens
/*
    public GameObject door;
    Collider2D doorCollider;
    
    Animator animator;
    Animator doorAnimator;

    void Start()
    {
        doorCollider = door.GetComponent<Collider2D>();
        animator = gameObject.GetComponent<Animator>();
        doorAnimator = door.GetComponent<Animator>();
*/
    public Door[] doors;
    public int colorIndex;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("Color", colorIndex);
//>>>>>>> 65ba2b022d8ab8d4cc0de18d613c2314f9213fdc
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("Button Pressed");
/*<<<<<<< HEAD
        doorCollider.enabled = false;
        animator.SetBool("buttonDown", true);
        doorAnimator.SetBool("buttonDown", true);

=======*/
        foreach(Door door in doors)
        {
            door.Open();
        }

        
        anim.SetBool("buttonDown", true);
//>>>>>>> 65ba2b022d8ab8d4cc0de18d613c2314f9213fdc
    }
    
    void OnTriggerExit2D(Collider2D otherCollider)
    {
        Debug.Log("Button Unpressed");
/*<<<<<<< HEAD
        doorCollider.enabled = true;
        animator.SetBool("buttonDown", false);
        doorAnimator.SetBool("buttonDown", false);
=======*/
        foreach (Door door in doors)
        {
            door.TryClose();
        }
        anim.SetBool("buttonDown", false);
//>>>>>>> 65ba2b022d8ab8d4cc0de18d613c2314f9213fdc

    }
}
