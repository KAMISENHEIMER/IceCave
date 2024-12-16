using UnityEngine;

public class EndDoor : MonoBehaviour
{
    [SerializeField] private int RequiredSnowflakes;
    bool open;
    Animation opening;
    Collider2D col;

    SpriteRenderer sr;
    public Sprite[] curDoors;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider2D>();
        opening = GetComponent<Animation>();
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!open)
        {
            sr.sprite = curDoors[Snowflake.collectedSnowflakes];
        }


        if (RequiredSnowflakes <= Snowflake.collectedSnowflakes)
        {
            open = true;
            

            col.enabled = false;

            sr.enabled = false;
        }




    }
}
