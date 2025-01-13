using UnityEngine;

public class CloseGame : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        //if the space is down, quit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
