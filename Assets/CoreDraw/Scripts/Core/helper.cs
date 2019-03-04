using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Screen core draw
/// </summary>

namespace HinxCor.Unity.SCD
{
    public static class helper
    {
        public static Rect ToScreenRect(this Rect ori)
        {
            return new Rect(ori.x - Screen.width / 2, ori.y - Screen.height / 2, ori.width, ori.height);
        }

        public static Vector2 ToScreenSpace(this Vector2 ori)
        {
            return new Vector2(ori.x - Screen.width / 2, ori.y - Screen.height / 2);
        }
    }
}


