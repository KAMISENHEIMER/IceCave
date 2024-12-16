using UnityEngine;

public class Door : MonoBehaviour
{
    BoxCollider2D col;
    public bool isOpen;
    public bool shouldClose;
    Animator anim;
    public float colorIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        anim.SetFloat("Color", colorIndex);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D BoxCheck = Physics2D.OverlapBox(col.bounds.center, col.size/1.5f, 0f);
        
        if(BoxCheck != null && BoxCheck.transform.tag == "pushables")
        {
            isOpen = true;
        }

        if (shouldClose == true)
        {
            if (BoxCheck == null)
            {
                isOpen = false;
                shouldClose = false;
                
            }
            else
            {
                if (BoxCheck.transform.tag == "pushables")
                {
                    isOpen = true;
                    Debug.Log(BoxCheck.gameObject.name);
                }
            }
        }

        col.enabled = !isOpen;
        anim.SetBool("buttonDown", isOpen);
    }



    public void Open()
    {
        isOpen = true;
    }

    public void TryClose()
    {
        shouldClose = true;
        
    }
}
