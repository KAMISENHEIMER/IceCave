using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class Deer : MonoBehaviour, IFreezable
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite frozenSprite;

    bool isFrozen = false;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // random idle animation every few seconds?
    }

    public void ToggleFreeze(Vector2 position)
    {
        isFrozen = !isFrozen;
        if (isFrozen)
        {
            gameObject.tag = "pushables";
            sr.sprite = frozenSprite;   //sprites will have to be changed when the idle animation stuff is added
        }
        else
        {
            gameObject.tag = "immovables";
            sr.sprite = normalSprite;
        }
    }

    public int GetNumFrozenObjects()
    {
        return isFrozen?1:0;
    }
}
