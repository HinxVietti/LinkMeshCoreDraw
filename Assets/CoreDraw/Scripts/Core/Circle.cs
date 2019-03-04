using UnityEngine;

namespace HinxCor.Unity.SCD
{

    public class Circle : Drawable
    {

        public override void ApplyData(Rect rect)
        {
            if (rect.width == 0 || rect.height == 0) return;
            rect = rect.ToScreenRect();
            bool wb = Mathf.Abs(rect.width) > Mathf.Abs(rect.height);// width bigger
            float rid = (wb ? rect.width : rect.height) / 2;

            int pcounts = getPcounts(rid);
            points = new Vector3[pcounts];
            for (int i = 0; i < pcounts; i++)
            {
                float θ = (float)i / pcounts * 2 * Mathf.PI;
                points[i] = rect.position + rect.size / 2f //center
                    + new Vector2(Mathf.Sin(θ) * (wb ? 1 : rect.width / rect.height), //x
                    Mathf.Cos(θ) * (wb ? rect.height / rect.width : 1)) //y
                    * rid;
            }
            line.positionCount = pcounts;
            line.SetPositions(points);
        }

        public override void init()
        {
            Type = LineType.Ellipse;
            line.loop = true;
        }

        private int getPcounts(float rid)
        {
            return Mathf.Clamp((int)Mathf.Abs(rid), 16, 256);
        }
    }
}

