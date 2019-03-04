using UnityEngine;

namespace HinxCor.Unity.SCD
{

    public class Line : Drawable
    {
        public override void ApplyData(Rect rect)
        {
            rect = rect.ToScreenRect();
            points[0] = Startp = rect.position;
            points[1] = Endp = rect.position + rect.size;
            line.SetPositions(points);
        }

        public override void init()
        {
            Type = LineType.Dash;
            points = new Vector3[2];
            line.positionCount = 2;
        }
    }
}
