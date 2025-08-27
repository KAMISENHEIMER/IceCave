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
        Ice ice = replacement.GetComponent<Ice>();



        Vector3Int cellPosition = source.WorldToCell(position);

        TileBase sourceTile = source.GetTile(cellPosition);

        if (sourceTile != null)
        {
            if (ice.icePositions.Count == ice.maxIceTiles)
            {
                if (ice.CheckForBox(ice.icePositions[0]) == true)
                {
                    ice.CantFreezeError();
                    return;
                }
            }

            replacement.GetComponent<Ice>().icePositions.Add(position);

            source.SetTile(cellPosition, null);
            replacement.SetTile(cellPosition, tileReplace);
        }




    }

    public int GetNumFrozenObjects()
    {
        return replacement.GetComponent<Ice>().icePositions.Count;
    }

    //exists here so that FreezeSelector can unfreeze ice tiles from the water object.
    public void ClearFirstFrozen()
    {
        replacement.GetComponent<Ice>().ClearFirstFrozen();
    }
    public int getIndexOfIcePosition(Vector2 position)
    {
        return replacement.GetComponent<Ice>().getIndexOfIcePosition(position);
    }

}
