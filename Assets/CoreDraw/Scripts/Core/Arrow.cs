using HinxCor.Unity.SCD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Drawable
{

    public LineRenderer child;
    float length { get { return (Endp - Startp).magnitude; } }
    Vector2 end { get { return Vector2.up * length; } }

    public override void ApplyData(Rect rect)
    {
        rect = rect.ToScreenRect();

        Startp = rect.position;
        Endp = rect.position + rect.size;

        var dir = (Endp - Startp);

        var anglez = Vector2.Angle(Vector2.up, dir);

        transform.eulerAngles = new Vector3(0, 0, (dir.x < 0 ? anglez : -anglez));
        transform.position = Startp;
        line.SetPosition(1, end);
        child.transform.localPosition = end;

    }

    public override void SetPen(int width, PenColor color, float a)
    {
        base.SetPen(width, color, a);
        child.endColor = GetColor(color, a);
        child.startColor = child.endColor;
    }

    public override void init()
    {
        Type = LineType.Arrow;
        points = new Vector3[2];
        line.positionCount = 2;

    }

}
