using UnityEngine;

public class Button : MonoBehaviour
{

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
        //ensures if there is still something on the button, it doesnt try to open the doors
        Collider2D[] thingsOnButton = Physics2D.OverlapPointAll(gameObject.transform.position);
        if (thingsOnButton.Length > 1) {
            return;
        }
        
        Debug.Log("Button Unpressed");

        foreach (Door door in doors)
        {
            door.TryClose();
        }
        anim.SetBool("buttonDown", false);

    }
}
