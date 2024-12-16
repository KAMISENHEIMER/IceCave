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
    
    //moves the icon
    public void moveSelector(Vector2 mousePosition)
    {
        Vector2 newPos = new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y));   //clamps the sprite to the grid
        freezeSelector.transform.position = newPos;
    }

    // shows/hides the selector by making it transparant or opaque
    public void showSelector()
    {
        color.a = 1f;
    }
    public void hideSelector()
    {
        color.a = 0.5f;
    }

    public void freeze(Collider2D collider)
    {
        //is called whenever mouse1 is pressed and the mouse is over water (or other freezable object)
        
        Debug.Log(collider.name + " was clicked");

    }
}
