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
    [SerializeField] public List<GameObject> BoxesOnIce = new List<GameObject>();

    void Start()
    {

    }

    public void CantFreezeError()
    {
        Debug.Log("can't remove ice here!");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "pushables" || collision.transform.tag == "Player")
        {
            Vector2 colPos = collision.transform.position;

            foreach (Vector2 icePos in icePositions)
            {
                if (source.WorldToCell(colPos) == source.WorldToCell(icePos))
                {
                    BoxesOnIce.Add(collision.transform.gameObject);
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "pushables" || collision.transform.tag == "Player")
        {
            Vector2 colPos = collision.transform.position;

            foreach (GameObject box in BoxesOnIce)
            {
                if (box == collision.gameObject)
                {
                    Vector3Int boxCell = source.WorldToCell(box.transform.position);

                    if (icePositions.Count > 0)
                    {
                        for (int i = 0; i < icePositions.Count; i++)
                        {
                            if (source.WorldToCell(icePositions[i]) == boxCell)
                            {
                                BoxesOnIce.Remove(box);
                            }
                        }
                    }

                    BoxesOnIce.Remove(collision.gameObject);
                }
            }

        }
    }

    void Update()
    {
        // if(icePositions.Count > maxIceTiles)
        // {
        //     if(CheckForBox(icePositions[0]) == false)
        //     {
        //         ToggleFreeze(icePositions[0]);

        //     }

        // }
    }

    //gets rid of the first tile on function call, instead of every frame
    public void ClearFirstFrozen()
    {
        if (CheckForBox(icePositions[0]) == false)
        {
            ToggleFreeze(icePositions[0]);
        }

    }

    public void ToggleFreeze(Vector2 position)
    {


        Vector3Int cellPosition = source.WorldToCell(position);



        if (CheckForBox(position) == true)
            return;

        TileBase sourceTile = source.GetTile(cellPosition);

        if (sourceTile != null)
        {

            if (icePositions.Count > 0)
            {
                if (icePositions.Count > 1)
                {
                    Debug.Log("Destroy?");
                    for (int i = 0; i < icePositions.Count; i++)
                    {
                        if (cellPosition == source.WorldToCell(icePositions[i]))
                        {
                            Debug.Log("Destroy");
                            icePositions.Remove(icePositions[i]);
                        }
                    }
                }
                else
                {
                    if (cellPosition == source.WorldToCell(icePositions[0]))
                    {
                        Debug.Log("Destroy");
                        icePositions.Remove(icePositions[0]);
                    }
                }


            }

            source.SetTile(cellPosition, null);
            replacement.SetTile(cellPosition, tileReplace);







        }


    }

    public bool CheckForBox(Vector2 position)
    {
        Vector3Int cellPosition = source.WorldToCell(position);

        foreach (GameObject box in BoxesOnIce)
        {
            if (cellPosition == source.WorldToCell(box.transform.position))
            {

                CantFreezeError();
                return true;
            }
        }

        return false;
    }

    public int GetNumFrozenObjects()
    {
        return icePositions.Count;
    }
    
    public int getIndexOfIcePosition(Vector2 position)
    {
        Vector3Int cellPosition = source.WorldToCell(position);

        for (int i = 0; i < icePositions.Count; i++)
        {
            if (source.WorldToCell(icePositions[i]) == cellPosition)
            {
                return i;
            }
        }



        //DEBUGGING
        string debug = "Couldnt find position " + position + " in icePositions:\n";
        foreach (Vector2 pos in icePositions)
        {
            debug = debug + pos + "\n";
        }
        Debug.Log(debug);

        return -1;
    }
}
