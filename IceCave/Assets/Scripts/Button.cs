using UnityEngine;

public class Button : MonoBehaviour
{
    // The door that this button opens
    public GameObject door;
    Collider2D doorCollider;

    void Start()
    {
        doorCollider = door.GetComponent<Collider2D>();
    }
    
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("Button Pressed");
        doorCollider.enabled = false;
    }
    
    void OnTriggerExit2D(Collider2D otherCollider)
    {
        Debug.Log("Button Unpressed");
        doorCollider.enabled = true;

    }
}
