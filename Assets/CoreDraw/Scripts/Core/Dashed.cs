using System.Collections.Generic;
using UnityEngine;


namespace HinxCor.Unity.SCD
{

    public class Dashed : Drawable
    {
#pragma warning disable
        [SerializeField] private LineRenderer prefab_3px, prefab_5px, prefab_9px;
        private LineRenderer current_prefab;
        private int current_spacing;
        private List<LineRenderer> pool = new List<LineRenderer>();
        int sp_3px = 22;
        int sp_5px = 30;
        int sp_9px = 40;
        private Stack<LineRenderer> hasDisplay = new Stack<LineRenderer>();

        private LineRenderer Get()
        {
            foreach (var line in pool)
            {
                if (!line.gameObject.activeInHierarchy)
                {
                    line.gameObject.SetActive(true);
                    return line;
                }
            }
            var new_line = Instantiate(current_prefab, transform);
            pool.Add(new_line);
            new_line.gameObject.SetActive(true);
            return new_line;
        }

        private void Return(LineRenderer go)
        {
            go.gameObject.SetActive(false);
        }

        public override void ApplyData(Rect rect)
        {
            rect = rect.ToScreenRect();
            points[0] = Startp = rect.position;
            points[1] = Endp = rect.position + rect.size;
            var length = (Endp - Startp).magnitude;
            int linec = (int)length / current_spacing + 1;
            if (hasDisplay.Count < linec)
            {
                for (int i = hasDisplay.Count; i < linec; i++)
                {
                    var go = Get();
                    go.transform.localPosition = Vector3.up * i * current_spacing;
                    hasDisplay.Push(go);
                }
            }

            while (hasDisplay.Count > linec)
            {
                var go = hasDisplay.Pop();
                Return(go);
            }


            var dir = (Endp - Startp);

            var anglez = Vector2.Angle(Vector2.up, dir);

            transform.eulerAngles = new Vector3(0, 0, (dir.x < 0 ? anglez : -anglez));
            transform.position = Startp;
        }

        public override void init()
        {
            Type = LineType.Dash;
            points = new Vector3[2];
            line.enabled = false;
            prefab_3px.gameObject.SetActive(false);
            prefab_5px.gameObject.SetActive(false);
            prefab_9px.gameObject.SetActive(false);

            current_prefab = prefab_5px;
            current_spacing = sp_5px;

        }

        public override void SetPen(int width, PenColor color, float a)
        {
            base.SetPen(width, color, a);
            switch (width)
            {
                case 3:
                    current_prefab = prefab_3px;
                    current_spacing = sp_3px;
                    break;
                case 5:
                    current_prefab = prefab_5px;
                    current_spacing = sp_5px;
                    break;
                case 9:
                    current_prefab = prefab_9px;
                    current_spacing = sp_9px;
                    break;
            }
        }

    }

}
