using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundry
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public Boundry boundry;
    public float speed;
    // Need the game camera object to translate the player's position into a pixel position
    public Camera cam;
    public bool useMouse = false;

    private Rigidbody2D rb;
    private float nextFire = 0.0f;
    private float fireRate = 0.25f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (useMouse)
            MouseMovement();
        else
            KeyboardMovement();

        PreventPlayerFromLeavingPlayArea();
    }

    private void KeyboardMovement()
    {
        // Keyboard input is -1 for left, 1 for right
        // 1 for up, and -1 for down
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;
    }

    private void MouseMovement()
    {
        // Takes the rigidBody position and turns it into a pixel position
        // Need to do this because the mousePosition is a pixel position
        var playerPosition = cam.WorldToScreenPoint(rb.position);
        var mousePosition = Input.mousePosition;
        var movement = new Vector2(0, 0);

        if (mousePosition.x < playerPosition.x - speed)
            movement.x = -1;
        else if (mousePosition.x > playerPosition.x + speed)
            movement.x = 1;

        if (mousePosition.y < playerPosition.y - speed)
            movement.y = -1;
        else if (mousePosition.y > playerPosition.y + speed)
            movement.y = 1;

        rb.velocity = movement * speed;
    }

    private void PreventPlayerFromLeavingPlayArea()
    {
        rb.position = new Vector2
        (
            Mathf.Clamp(rb.position.x, boundry.xMin, boundry.xMax),
            Mathf.Clamp(rb.position.y, boundry.yMin, boundry.yMax)
        );
    }
}
