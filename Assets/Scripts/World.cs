using UnityEngine;

namespace Assets.Scripts
{
    public class World : MonoBehaviour
    {
        private static Boundry bounds;

        static World()
        {
            bounds = new Boundry(6, -6, 10, -10);
        }

        public static bool IsOutOfBounds(Vector2 position)
        {
            if (position.x > bounds.xMax || position.x < bounds.xMin || position.y > bounds.yMax || position.y < bounds.yMin)
                return true;
            else
                return false;
        }
    }
}
