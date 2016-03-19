using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

        body.velocity = new Vector2(0, speed);
    }

    private void Update()
    {
        var test = GetComponent<Transform>();
        if (test.position.y > 10)
            Destroy(gameObject);
    }
}
