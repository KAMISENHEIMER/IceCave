using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    //moves the player a small increment based on the inputted direction
    public void MovePlayer(Vector2 direction)
    {
        //moves based on the player speed, the time, and the movement direction
        //Time.fixedDeltaTime is to ensure altering frame rates do not affect speed
        //rb.MovePosition(rb.position+(speed * Time.fixedDeltaTime * direction));
        rb.linearVelocity = direction * speed;
    }
}
