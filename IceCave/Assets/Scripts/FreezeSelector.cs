using UnityEngine;

public class FreezeSelector : MonoBehaviour
{
    public GameObject freezeSelectorPrefab;
    private GameObject freezeSelector;

    void Start()
    {
        freezeSelector = Instantiate(freezeSelectorPrefab);
        freezeSelector.SetActive(false);
    }
    
    //makes the freezeSelector icon over the water (or other freezeable object) it is touching
    public void moveSelector(Vector2 mousePosition)
    {
        freezeSelector.SetActive(true);
        Vector2 newPos = new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y));   //clamps the sprite to the grid
        freezeSelector.transform.position = newPos;
    }

    public void hideSelector()
    {
        freezeSelector.SetActive(false);
    }

    public void freeze(Collider2D collider)
    {
        //is called whenever mouse1 is pressed and the mouse is over water (or other freezable object)
        Debug.Log(collider.name + " was clicked");
    }
}
