using UnityEngine;
using System.Collections.Generic;

public class FreezeSelector : MonoBehaviour
{
    public GameObject freezeSelectorPrefab;
    private GameObject freezeSelector;
    [SerializeField] private SpriteRenderer sr;

    Color color = Color.white;

    //for handeling how many things can be frozen at once.
    //this should be here instead of the ice script, so that mutliple frozen objects abide by the maximum rule.
    public int maxIceTiles = 3;
    [SerializeField] public List<IFreezable> frozenObjects = new List<IFreezable>();

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

    //is called whenever mouse1 is pressed and the mouse is over water (or other freezable object)
    public void ToggleFreeze(Collider2D hitFreeze, Vector2 mousePosition)
    {
        Debug.Log(hitFreeze.name + " was clicked");

        //check how many frozen objects are apart of this freezable object
        int NumFrozenParts = hitFreeze.GetComponent<IFreezable>().GetNumFrozenObjects();

        //check if its ice to know we need to remove it from the list now, as it will be gone after we toggle freeze.
        if (hitFreeze.GetComponent<IFreezable>().GetType() == typeof(Ice))
        {
            int posIndex = (hitFreeze.GetComponent<IFreezable>() as Ice).getIndexOfIcePosition(mousePosition);    //returns index in the ice array, now skip any other objects until
                                                                                                                  //TODO: count down from the posIndex, skipping other objects then remove the water object when posIndex gets to 0
            Debug.Log("Index of ice position (in ice array): " + posIndex);

            for (int i = 0; i < frozenObjects.Count; i++)
            {
                if (frozenObjects[i].GetType() == typeof(Water))
                {
                    if (posIndex == 0)
                    {
                        frozenObjects.RemoveAt(i);
                    }
                    else
                    {
                        posIndex--;
                    }
                }
            }
        }

        //toggle freeze on the currently selected object
        hitFreeze.GetComponent<IFreezable>().ToggleFreeze(mousePosition);

        //if the number of frozen objects has increased, add it to the list, else remove it
        if (hitFreeze.GetComponent<IFreezable>().GetNumFrozenObjects() > NumFrozenParts)
        {
            frozenObjects.Add(hitFreeze.GetComponent<IFreezable>());
        }
        else
        {
            //number of frozen parts decreased, check for ice (to make sure we remove the right instance of ice)
            if (hitFreeze.GetComponent<IFreezable>().GetType() == typeof(Ice))
            {

            }
            else
            {    //not ice, just remove it
                frozenObjects.Remove(hitFreeze.GetComponent<IFreezable>());
            }

            //DEBUGGING
            string debug = "Frozen Objects:\n";
            foreach (IFreezable obj in frozenObjects)
            {
                debug = debug + obj + "\n";
            }
            Debug.Log(debug);

        }

        //remove the first frozen object if there are too many
        if (frozenObjects.Count > maxIceTiles)
        {
            //because Ice is set up differently (keeps track of tile locations), it has to be handled differently
            if (frozenObjects[0].GetType() == typeof(Water))
            {
                (frozenObjects[0] as Water).ClearFirstFrozen();
            }
            else
            {
                frozenObjects[0].ToggleFreeze(mousePosition);
            }
            frozenObjects.RemoveAt(0);
        }


    }

    public int GetNumFrozenObjects()
    {
        return frozenObjects.Count;
    }
}
