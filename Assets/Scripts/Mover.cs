using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;

    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

        body.velocity = new Vector2(0, speed);
    }
}
