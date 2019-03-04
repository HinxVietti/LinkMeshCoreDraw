using UnityEngine;

namespace HinxCor.Unity.SCD
{
    public class Rectangle : Drawable
    {

        public override void init()
        {
            points = new Vector3[4];
            line.loop = true;
            line.positionCount = 4;
            line.numCapVertices = 5;
            line.numCornerVertices = 5;
            line.useWorldSpace = true;
            Type = LineType.Rectangle;
        }


        public override void ApplyData(Rect rect)
        {
            //rect
            rect = rect.ToScreenRect();
            points[0] = new Vector2(rect.x, rect.y);
            points[1] = new Vector2(rect.x + rect.width, rect.y);
            points[3] = new Vector2(rect.x, rect.y + rect.height);
            points[2] = new Vector2(rect.x + rect.width, rect.y + rect.height);
            line.SetPositions(points);
        }
    }

}
