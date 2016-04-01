using System;

namespace Assets.Scripts
{
    [Serializable]
    public class Boundry
    {
        public float xMin, xMax, yMin, yMax;

        public Boundry()
        {

        }

        public Boundry(float xMax, float xMin, float yMax, float yMin)
        {
            this.xMax = xMax;
            this.xMin = xMin;
            this.yMax = yMax;
            this.yMin = yMin;
        }
    }
}
