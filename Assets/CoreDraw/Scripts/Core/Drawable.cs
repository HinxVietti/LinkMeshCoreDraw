using UnityEngine;
using UnityEngine.EventSystems;


namespace HinxCor.Unity.SCD
{
    [RequireComponent(typeof(LineRenderer))]
    public abstract class Drawable : UIBehaviour
    {
        public LineType Type = LineType.Line;
        public Material ColorFul;
        //protected Vector2 MousePointOnScreen
        protected Vector2 Startp;
        protected Vector2 Endp;
        protected LineRenderer line;
        protected Vector3[] points;
        public abstract void init();

        protected override void Awake()
        {
            line = GetComponent<LineRenderer>();
            init();
        }
        public abstract void ApplyData(Rect rect);

        public virtual void SetPen(int width, PenColor color, float a)
        {
            if (!line) line = GetComponent<LineRenderer>();
            if (Type != LineType.Arrow)
            {
                line.startWidth = width;
                line.endWidth = width;
            }
            var c = GetColor(color, a);
            line.startColor = c;
            line.endColor = c;
            if (color == PenColor.colorful && Type != LineType.Arrow)
            {
                line.material = ColorFul;
            }
        }

        protected virtual Color GetColor(PenColor color, float a)
        {
            Color c = new Color();
            switch (color)
            {
                case PenColor.red:
                    c = DefaultGdiColors.Red.ToColor();
                    break;
                case PenColor.orange:
                    c = DefaultGdiColors.Orange.ToColor();
                    break;
                case PenColor.yellow:
                    c = DefaultGdiColors.Yellow.ToColor();
                    break;
                case PenColor.green:
                    c = DefaultGdiColors.Green.ToColor();
                    break;
                case PenColor.blue:
                    c = DefaultGdiColors.Blue.ToColor();
                    break;
                case PenColor.indogo:
                    c = DefaultGdiColors.Indigo.ToColor();
                    break;
                case PenColor.purple:
                    c = DefaultGdiColors.Purple.ToColor();
                    break;
                case PenColor.white:
                    c = Color.white;
                    break;
                case PenColor.black:
                    c = Color.black;
                    break;
                case PenColor.colorful:
                    c = Color.white;
                    break;
            }
            c.a = a;
            return c;
        }

        public enum PenColor
        {
            red,
            orange,
            yellow,
            green,
            blue,
            indogo,
            purple,
            white,
            black,
            colorful
        }
        public enum LineType
        {
            Rectangle = 1,
            Ellipse = 2,
            Arrow = 3,
            Line = 4,
            Dash = 5,
            Curve = 6
        }
    }

}