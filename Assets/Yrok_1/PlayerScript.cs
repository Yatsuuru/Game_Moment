using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    private Vector2 movement;
    public Rigidbody2D rd2;
    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(inputX, inputY);

        bool shoot = Input.GetButton("Fire1");
        shoot |= Input.GetButton("Fire2");

        if (shoot)
        {
            WeaponScript weapon = GetComponent <WeaponScript>();
            if(weapon != null)
            {
                weapon.Attack(false);
            }
        }
    }

    private void FixedUpdate()
    {
        rd2.velocity = movement;
    }
}
