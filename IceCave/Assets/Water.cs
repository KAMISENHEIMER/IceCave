using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class Water : MonoBehaviour, IFreezable
{
    [SerializeField] private Tilemap replacement;
    [SerializeField] private Tile tileReplace;
    [SerializeField] private Tilemap source;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ToggleFreeze(Vector2 position)
    {
        Vector3Int cellPosition = source.WorldToCell(position);

        TileBase sourceTile = source.GetTile(cellPosition);

        if(sourceTile != null)
        {
            source.SetTile(cellPosition, null);
            replacement.SetTile(cellPosition, tileReplace);
        }

        replacement.GetComponent<Ice>()?.icePositions.Add(position);


    }
}
