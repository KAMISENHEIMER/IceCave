using UnityEngine;

public class FreezeSelector : MonoBehaviour
{
    public GameObject freezeSelectorPrefab;
    private GameObject freezeSelector;
    [SerializeField] private SpriteRenderer sr;

    Color color = Color.white;


    private void Update()
    {
        sr.color = color;
    }
    void Start()
    {
        freezeSelector = Instantiate(freezeSelectorPrefab);
        color.a = 0.5f;
        sr = freezeSelector.GetComponent<SpriteRenderer>();
    }
    
    //makes the freezeSelector icon over the water (or other freezeable object) it is touching
    public void moveSelector(Vector2 mousePosition)
    {
        color.a = 1f;
        Vector2 newPos = new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y));   //clamps the sprite to the grid
        freezeSelector.transform.position = newPos;
    }

    public void hideSelector()
    {

        color.a = 0f;
        
    }

    public void freeze(Collider2D collider)
    {
        //is called whenever mouse1 is pressed and the mouse is over water (or other freezable object)
        
        Debug.Log(collider.name + " was clicked");

    }
}
