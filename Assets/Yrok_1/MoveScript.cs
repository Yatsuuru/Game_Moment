using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(10,10);
    public Vector2 direction = new Vector2(-1, 0);
    public Vector2 movement;

    public Rigidbody2D rb2d;

    private void Update()
    {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
    }
    private void FixedUpdate()
    {
        rb2d.velocity = movement;       
    }
}
