using UnityEngine;

public class Button : MonoBehaviour
{
    // The door that this button opens
    public Door[] doors;
    public int colorIndex;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("Color", colorIndex);
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("Button Pressed");
        foreach(Door door in doors)
        {
            door.Open();
        }

        
        anim.SetBool("buttonDown", true);
    }
    
    void OnTriggerExit2D(Collider2D otherCollider)
    {
        Debug.Log("Button Unpressed");
        foreach (Door door in doors)
        {
            door.TryClose();
        }
        anim.SetBool("buttonDown", false);

    }
}
