using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    public int RequiredSnowflakes;
    Door door;
    bool unlocked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door = GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Snowflake.collectedSnowflakes >= RequiredSnowflakes && !unlocked)
        {
            door.Open();
            unlocked = true;
        }
    }
}
