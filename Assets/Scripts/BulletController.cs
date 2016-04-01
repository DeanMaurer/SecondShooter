using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
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
            var transform = GetComponent<Transform>();
            if (World.IsOutOfBounds((Vector2)transform.position))
                Destroy(gameObject);
        }
    }
}
