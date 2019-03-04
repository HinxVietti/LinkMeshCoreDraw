using System.Collections.Generic;
using UnityEngine;

namespace HinxCor.Unity.SCD
{

    public class Curve : Drawable
    {
        private List<Vector3> poits = new List<Vector3>();
        private Vector2 current;

        public override void ApplyData(Rect rect)
        {
            rect = rect.ToScreenRect();
            if (poits.Count == 0)
                AddPoint(rect.position);

            TryAddPoint(rect.position + rect.size);
        }

        private void TryAddPoint(Vector2 dest)
        {
            if ((dest - current).magnitude >= 3)
                AddPoint(dest);
        }

        private void AddPoint(Vector2 p)
        {
            poits.Add(p);
            current = p;
            line.positionCount = poits.Count;
            line.SetPositions(poits.ToArray());
        }

        public override void init()
        {
            Type = LineType.Curve;
        }

    }


}