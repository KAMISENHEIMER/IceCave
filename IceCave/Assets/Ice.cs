using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class Ice : MonoBehaviour, IFreezable
{
    public int maxIceTiles = 3;

    [SerializeField] private Tilemap replacement;
    [SerializeField] private Tile tileReplace;
    [SerializeField] private Tilemap source;

    [SerializeField] public List<Vector2> icePositions = new List<Vector2>();

    void Start()
    {
        
    }

    void Update()
    {
        if(icePositions.Count > maxIceTiles)
        {
            ToggleFreeze(icePositions[0]);
            icePositions.Remove(icePositions[0]);
        }
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

        
    }
}
