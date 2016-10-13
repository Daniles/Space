using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public static class ShootOneFireParameters
    {
        public static float damage = 25f;
        public static bool collisionDestruct = true;
        public static float[] angle = { 0 };
        public static float flySpeed = 3f;
        public static GameObject prefab = Resources.Load("ball", typeof(GameObject)) as GameObject;
    }
    public static class ShootTwoFireParameters
    {
        public static float damage = 15f;
        public static bool collisionDestruct = true;
        public static float[] angle = { Mathf.PI / 12, -Mathf.PI / 12 };
        public static float flySpeed = 3f;
        public static GameObject prefab = Resources.Load("ball", typeof(GameObject)) as GameObject;
    }
}
