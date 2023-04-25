using System;
using UnityEditor;
using UnityEngine;

namespace GodMachine {

    public static class GMU {

        #region Constants

        public const float TAU = 6.28318530717959f;
        public const float PI = 3.14159265359f;
        public const float E = 2.71828182846f;
        public const float GOLDEN_RATIO = 1.61803398875f;
        public const float SQRT2 = 1.41421356237f;
        public const float DegreeToRadians = TAU / 360f;
        public const float DTR = TAU / 360f;
        public const float RadiansToDegree = 360f / TAU;
        public const float RTD = 360f / TAU;
        public const float LIGHT_SPEED = 299792458f;
        public const float EARTH_GRAVITY = 9.807f;

        #endregion

        #region Math Operations

        public static float Sqrt (float value) => (float) Math.Sqrt (value);
        public static Vector2 Sqrt (Vector2 v) => new Vector2 (Sqrt (v.x), Sqrt (v.y));
        public static Vector3 Sqrt (Vector3 v) => new Vector3 (Sqrt (v.x), Sqrt (v.y), Sqrt (v.z));

        public static float Pow (float value, float exponent) => (float) Math.Pow (value, exponent);
        public static Vector2 Pow (Vector2 v, float exponent) => new Vector2 (
            (float) Math.Pow (v.x, exponent),
            (float) Math.Pow (v.y, exponent)
        );
        public static Vector3 Pow (Vector3 v, float exponent) => new Vector3 (
            (float) Math.Pow (v.x, exponent),
            (float) Math.Pow (v.y, exponent),
            (float) Math.Pow (v.z, exponent)
        );

        public static float Cos (float angRad) => (float) Math.Cos (angRad);
        public static float Sin (float angRad) => (float) Math.Sin (angRad);
        public static float Tan (float angRad) => (float) Math.Tan (angRad);
        public static float Acos (float value) => (float) Math.Acos (value);
        public static float Asin (float value) => (float) Math.Asin (value);
        public static float Atan (float value) => (float) Math.Atan (value);
        public static float Atan2 (float y, float x) => (float) Math.Atan2 (y, x);

        public static int Clamp (int value, int min, int max) => value<min ? min : value> max ? max : value;
        public static float Clamp (float value, float min, float max) => value<min ? min : value> max ? max : value;
        public static Vector2 Clamp (Vector2 v, Vector2 min, Vector2 max) =>
            new Vector2 (
                v.x<min.x ? min.x : v.x> max.x ? max.x : v.x,
                v.y<min.y ? min.y : v.y> max.y ? max.y : v.y
            );
        public static Vector3 Clamp (Vector3 v, Vector3 min, Vector3 max) =>
            new Vector3 (
                v.x<min.x ? min.x : v.x> max.x ? max.x : v.x,
                v.y<min.y ? min.y : v.y> max.y ? max.y : v.y,
                v.z<min.z ? min.z : v.z> max.z ? max.z : v.z
            );

        #endregion

        #region Abs

        public static float Abs (float value) => Math.Abs (value);
        public static int Abs (int value) => Math.Abs (value);
        public static Vector2 Abs (Vector2 v) => new Vector2 (Abs (v.x), Abs (v.y));
        public static Vector3 Abs (Vector3 v) => new Vector3 (Abs (v.x), Abs (v.y), Abs (v.z));
        public static Vector4 Abs (Vector4 v) => new Vector4 (Abs (v.x), Abs (v.y), Abs (v.z), Abs (v.w));

        #endregion

        #region Min & Max

        public static float Min (float a, float b) => a < b ? a : b;
        public static float Min (float a, float b, float c) => Min (Min (a, b), c);
        public static float Min (float a, float b, float c, float d) => Min (Min (a, b), Min (c, d));
        public static float Max (float a, float b) => a > b ? a : b;
        public static float Max (float a, float b, float c) => Max (Max (a, b), c);
        public static float Max (float a, float b, float c, float d) => Max (Max (a, b), Max (c, d));
        public static int Min (int a, int b) => a < b ? a : b;
        public static int Min (int a, int b, int c) => Min (Min (a, b), c);
        public static int Min (int a, int b, int c, int d) => Min (Min (a, b), Min (c, d));
        public static int Max (int a, int b) => a > b ? a : b;
        public static int Max (int a, int b, int c) => Max (Max (a, b), c);
        public static int Max (int a, int b, int c, int d) => Max (Max (a, b), Max (c, d));
        public static float Min (Vector2 v) => Min (v.x, v.y);
        public static float Min (Vector3 v) => Min (v.x, v.y, v.z);
        public static float Min (Vector4 v) => Min (v.x, v.y, v.z, v.w);
        public static float Max (Vector2 v) => Max (v.x, v.y);
        public static float Max (Vector3 v) => Max (v.x, v.y, v.z);
        public static float Max (Vector4 v) => Max (v.x, v.y, v.z, v.w);

        #endregion

        #region Signs & Values

        public static float Sign (float value) => value >= 0f ? 1 : -1;
        public static Vector2 Sign (Vector2 value) => new Vector2 (value.x >= 0f ? 1 : -1, value.y >= 0f ? 1 : -1);
        public static Vector3 Sign (Vector3 value) => new Vector3 (value.x >= 0f ? 1 : -1, value.y >= 0f ? 1 : -1, value.z >= 0f ? 1 : -1);
        public static Vector4 Sign (Vector4 value) => new Vector4 (value.x >= 0f ? 1 : -1, value.y >= 0f ? 1 : -1, value.z >= 0f ? 1 : -1, value.w >= 0f ? 1 : -1);
        public static int Sign (int value) => value >= 0 ? 1 : -1;
        public static int FloatToIntSign (float value) => value >= 0f ? 1 : -1;
        public static float SignWithZero (float value, float zeroThreshold) => Abs (value) < zeroThreshold ? 0 : Sign (value);
        public static int SignWithZero (int value) => value == 0 ? 0 : Sign (value);
        public static Vector2 SignWithZero (Vector2 value, float zeroThreshold = 0.000001f) =>
            new Vector2 (
                Abs (value.x) < zeroThreshold ? 0 : Sign (value.x),
                Abs (value.y) < zeroThreshold ? 0 : Sign (value.y)
            );
        public static Vector3 SignWithZero (Vector3 value, float zeroThreshold = 0.000001f) =>
            new Vector3 (
                Abs (value.x) < zeroThreshold ? 0 : Sign (value.x),
                Abs (value.y) < zeroThreshold ? 0 : Sign (value.y),
                Abs (value.z) < zeroThreshold ? 0 : Sign (value.z)
            );
        public static Vector4 SignWithZero (Vector4 value, float zeroThreshold = 0.000001f) =>
            new Vector4 (
                Abs (value.x) < zeroThreshold ? 0 : Sign (value.x),
                Abs (value.y) < zeroThreshold ? 0 : Sign (value.y),
                Abs (value.z) < zeroThreshold ? 0 : Sign (value.z),
                Abs (value.w) < zeroThreshold ? 0 : Sign (value.w)
            );

        #endregion

        #region Floor & Ceil

        public static float Floor (float value) => (float) Math.Floor (value);
        public static Vector2 Floor (Vector2 value) =>
            new Vector2 (
                (float) Math.Floor (value.x),
                (float) Math.Floor (value.y)
            );
        public static Vector3 Floor (Vector3 value) =>
            new Vector3 (
                (float) Math.Floor (value.x),
                (float) Math.Floor (value.y),
                (float) Math.Floor (value.z)
            );
        public static float Ceil (float value) => (float) Math.Ceiling (value);
        public static Vector2 Ceil (Vector2 value) =>
            new Vector2 (
                (float) Math.Ceiling (value.x),
                (float) Math.Ceiling (value.y)
            );
        public static Vector3 Ceil (Vector3 value) =>
            new Vector3 (
                (float) Math.Ceiling (value.x),
                (float) Math.Ceiling (value.y),
                (float) Math.Ceiling (value.z)
            );

        #endregion

        #region Draw Gizmos

        public static void DrawNormalizedVector (Vector3 origin, Vector3 direction) => Handles.DrawAAPolyLine (1, origin, origin + direction);
        public static void DrawNormalizedVector (Vector3 origin, Vector3 direction, float size) => Handles.DrawAAPolyLine (size, origin, origin + direction);

        public static void DrawXYZGizmos (Vector3 origin) {
            Handles.color = Color.green;
            DrawNormalizedVector (origin, Vector3.up, 5);
            Handles.color = new Color (0f, .75f, 0f, 1f);
            DrawNormalizedVector (origin, -Vector3.up, 1);
            Handles.color = Color.red;
            DrawNormalizedVector (origin, Vector3.right, 5);
            Handles.color = new Color (.75f, 0f, 0f, 1f);
            DrawNormalizedVector (origin, -Vector3.right, 1);
            Handles.color = Color.blue;
            DrawNormalizedVector (origin, Vector3.forward, 5);
            Handles.color = new Color (0f, 0f, .75f, 1f);
            DrawNormalizedVector (origin, -Vector3.forward, 1);
        }
        public static void DrawXYZGizmos (Vector3 origin, Vector3 right, Vector3 up) {
            Vector2 forward = Vector3.Cross (right, up).normalized;
            Handles.color = Color.green;
            DrawNormalizedVector (origin, up, 5);
            Handles.color = new Color (0f, .75f, 0f, 1f);
            DrawNormalizedVector (origin, -up, 1);
            Handles.color = Color.red;
            DrawNormalizedVector (origin, right, 5);
            Handles.color = new Color (.75f, 0f, 0f, 1f);
            DrawNormalizedVector (origin, -right, 1);
            Handles.color = Color.blue;
            DrawNormalizedVector (origin, forward, 5);
            Handles.color = new Color (0f, 0f, .75f, 1f);
            DrawNormalizedVector (origin, -forward, 1);
        }
        public static void DrawXYZGizmos (Vector3 origin, Vector3 right, Vector3 up, Vector3 forward) {
            Vector3 r = right.normalized;
            Vector3 u = up.normalized;
            Vector3 f = forward.normalized;
            Handles.color = Color.green;
            DrawNormalizedVector (origin, u, 5);
            Handles.color = new Color (0f, .75f, 0f, 1f);
            DrawNormalizedVector (origin, -u, 1);
            Handles.color = Color.red;
            DrawNormalizedVector (origin, r, 5);
            Handles.color = new Color (.75f, 0f, 0f, 1f);
            DrawNormalizedVector (origin, -r, 1);
            Handles.color = Color.blue;
            DrawNormalizedVector (origin, f, 5);
            Handles.color = new Color (0f, 0f, .75f, 1f);
            DrawNormalizedVector (origin, -f, 1);
        }

        public static void DrawXYZPositiveGizmos (Vector3 origin) {
            Handles.color = Color.green;
            DrawNormalizedVector (origin, Vector3.up, 1);
            Handles.color = Color.red;
            DrawNormalizedVector (origin, Vector3.right, 1);
            Handles.color = Color.blue;
            DrawNormalizedVector (origin, Vector3.forward, 1);
        }
        public static void DrawXYZPositiveGizmos (Vector3 origin, int size) {
            Handles.color = Color.green;
            DrawNormalizedVector (origin, Vector3.up, size);
            Handles.color = Color.red;
            DrawNormalizedVector (origin, Vector3.right, size);
            Handles.color = Color.blue;
            DrawNormalizedVector (origin, Vector3.forward, size);
        }
        public static void DrawXYZPositiveGizmos (Vector3 origin, Vector3 right, Vector3 up) {
            Vector2 forward = Vector3.Cross (right, up).normalized;
            Handles.color = Color.green;
            DrawNormalizedVector (origin, up, 1);
            Handles.color = Color.red;
            DrawNormalizedVector (origin, right, 1);
            Handles.color = Color.blue;
            DrawNormalizedVector (origin, forward, 1);
        }
        public static void DrawXYZPositiveGizmos (Vector3 origin, Vector3 right, Vector3 up, int size) {
            Vector2 forward = Vector3.Cross (right, up).normalized;
            Handles.color = Color.green;
            DrawNormalizedVector (origin, up, size);
            Handles.color = Color.red;
            DrawNormalizedVector (origin, right, size);
            Handles.color = Color.blue;
            DrawNormalizedVector (origin, forward, size);
        }
        public static void DrawXYZPositiveGizmos (Vector3 origin, Vector3 right, Vector3 up, Vector3 forward) {
            Vector3 r = right.normalized;
            Vector3 u = up.normalized;
            Vector3 f = forward.normalized;
            Handles.color = Color.green;
            DrawNormalizedVector (origin, u, 1);
            Handles.color = Color.red;
            DrawNormalizedVector (origin, r, 1);
            Handles.color = Color.blue;
            DrawNormalizedVector (origin, f, 1);
        }
        public static void DrawXYZPositiveGizmos (Vector3 origin, Vector3 right, Vector3 up, Vector3 forward, int size) {
            Vector3 r = right.normalized;
            Vector3 u = up.normalized;
            Vector3 f = forward.normalized;
            Handles.color = Color.green;
            DrawNormalizedVector (origin, u, size);
            Handles.color = Color.red;
            DrawNormalizedVector (origin, r, size);
            Handles.color = Color.blue;
            DrawNormalizedVector (origin, f, size);
        }

        public static void DrawCubeVertex (Matrix4x4 pointToWorld) {
            Vector3 [ ] vtx = new Vector3 [ ] {
                new Vector3 (1, 0, 1), // Bottom
                new Vector3 (-1, 0, 1),
                new Vector3 (1, 0, -1),
                new Vector3 (-1, 0, -1),
                new Vector3 (1, 2, 1), // Top
                new Vector3 (-1, 2, 1),
                new Vector3 (1, 2, -1),
                new Vector3 (-1, 2, -1)
            };
            Gizmos.color = Color.white;
            for (int i = 0; i < vtx.Length; i++) {
                Vector3 worldPoint = pointToWorld.MultiplyPoint3x4 (vtx [i]);
                Gizmos.DrawSphere (worldPoint, 0.1f);
                if (i > 0) {
                    Handles.DrawAAPolyLine ();
                }
            }
        }
        public static void DrawCubeVertex (Matrix4x4 pointToWorld, int size) {
            Vector3 [ ] vtx = new Vector3 [ ] {
                new Vector3 (1, 0, 1) * size, // Bottom
                new Vector3 (-1, 0, 1) * size,
                new Vector3 (1, 0, -1) * size,
                new Vector3 (-1, 0, -1) * size,
                new Vector3 (1, 2, 1) * size, // Top
                new Vector3 (-1, 2, 1) * size,
                new Vector3 (1, 2, -1) * size,
                new Vector3 (-1, 2, -1) * size
            };
            Gizmos.color = Color.white;
            for (int i = 0; i < vtx.Length; i++) {
                Vector3 worldPoint = pointToWorld.MultiplyPoint3x4 (vtx [i]);
                Gizmos.DrawSphere (worldPoint, 0.1f);
                if (i > 0) {
                    Handles.DrawAAPolyLine ();
                }
            }
        }
        public static void DrawCubeVertex (Matrix4x4 pointToWorld, Color c) {
            Vector3 [ ] vtx = new Vector3 [ ] {
                new Vector3 (1, 0, 1), // Bottom
                new Vector3 (-1, 0, 1),
                new Vector3 (1, 0, -1),
                new Vector3 (-1, 0, -1),
                new Vector3 (1, 2, 1), // Top
                new Vector3 (-1, 2, 1),
                new Vector3 (1, 2, -1),
                new Vector3 (-1, 2, -1)
            };
            Gizmos.color = c;
            for (int i = 0; i < vtx.Length; i++) {
                Vector3 worldPoint = pointToWorld.MultiplyPoint3x4 (vtx [i]);
                Gizmos.DrawSphere (worldPoint, 0.1f);
                if (i > 0) {
                    Handles.DrawAAPolyLine ();
                }
            }
        }
        public static void DrawCubeVertex (Matrix4x4 pointToWorld, int size, Color c) {
            Vector3 [ ] vtx = new Vector3 [ ] {
                new Vector3 (1, 0, 1) * size, // Bottom
                new Vector3 (-1, 0, 1) * size,
                new Vector3 (1, 0, -1) * size,
                new Vector3 (-1, 0, -1) * size,
                new Vector3 (1, 2, 1) * size, // Top
                new Vector3 (-1, 2, 1) * size,
                new Vector3 (1, 2, -1) * size,
                new Vector3 (-1, 2, -1) * size
            };
            Gizmos.color = c;
            for (int i = 0; i < vtx.Length; i++) {
                Vector3 worldPoint = pointToWorld.MultiplyPoint3x4 (vtx [i]);
                Gizmos.DrawSphere (worldPoint, 0.1f);
                if (i > 0) {
                    Handles.DrawAAPolyLine ();
                }
            }
        }

        public static Vector2 [ ] DrawCircle (int vertexCount, bool spheres) {
            int d = vertexCount;
            Vector2 [ ] point = new Vector2 [d];
            for (int i = 0; i < d; i++) {
                float t = i / (float) d;
                float angleRad = t * TAU;
                point [i] = AngToDir (angleRad);
                if (spheres) Gizmos.DrawSphere (point [i], 0.05f);
            }
            return point;
        }
        public static Vector2 [ ] DrawCircle (int vertexCount, bool spheres, bool edges) {
            int d = vertexCount;
            Vector2 [ ] point = new Vector2 [d];
            for (int i = 0; i < d; i++) {
                float t = i / (float) d;
                float angleRad = t * TAU;
                point [i] = AngToDir (angleRad);
                if (spheres) Gizmos.DrawSphere (point [i], 0.05f);
                if (edges) {
                    if (i > 0) {
                        Handles.DrawAAPolyLine (point [i], point [i - 1]);
                    }
                    if (i == point.Length - 1) {
                        Handles.DrawAAPolyLine (point [i], point [0]);
                    }
                }
            }
            return point;
        }
        public static Vector2 [ ] DrawCircle (int vertexCount, bool spheres, bool edges, bool lines) {
            int d = vertexCount;
            Vector2 [ ] point = new Vector2 [d];
            for (int i = 0; i < d; i++) {
                float t = i / (float) d;
                float angleRad = t * TAU;
                point [i] = AngToDir (angleRad);
                if (spheres) Gizmos.DrawSphere (point [i], 0.05f);
                if (lines) Handles.DrawAAPolyLine (point [i], Vector2.zero);
                if (edges) {
                    if (i > 0) {
                        Handles.DrawAAPolyLine (point [i], point [i - 1]);
                    }
                    if (i == point.Length - 1) {
                        Handles.DrawAAPolyLine (point [i], point [0]);
                    }
                }
            }
            return point;
        }

        #endregion

        #region 3D Shapes Curves and Stuff

        public static Vector2 [ ] SetCircleVertex (int vertexCount) {
            int d = vertexCount;
            Vector2 [ ] point = new Vector2 [d];
            for (int i = 0; i < d; i++) {
                float t = i / (float) d;
                float angleRad = t * TAU;
                point [i] = AngToDir (angleRad);
            }
            return point;
        }
        public static Vector3 [ ] SetCubeVertex (Matrix4x4 pointToWorld) {
            Vector3 [ ] vtx = new Vector3 [ ] {
                new Vector3 (1, 0, 1), // Bottom
                new Vector3 (-1, 0, 1),
                new Vector3 (1, 0, -1),
                new Vector3 (-1, 0, -1),
                new Vector3 (1, 2, 1), // Top
                new Vector3 (-1, 2, 1),
                new Vector3 (1, 2, -1),
                new Vector3 (-1, 2, -1)
            };
            return vtx;
        }
        public static Vector3 [ ] SetCubeVertex (Matrix4x4 pointToWorld, int size) {
            Vector3 [ ] vtx = new Vector3 [ ] {
                new Vector3 (1, 0, 1) * size, // Bottom
                new Vector3 (-1, 0, 1) * size,
                new Vector3 (1, 0, -1) * size,
                new Vector3 (-1, 0, -1) * size,
                new Vector3 (1, 2, 1) * size, // Top
                new Vector3 (-1, 2, 1) * size,
                new Vector3 (1, 2, -1) * size,
                new Vector3 (-1, 2, -1) * size
            };
            return vtx;
        }

        public static Vector2 BezierCurve (Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t) =>
            p0 +
            t * (-3 * p0 + 3 * p1) +
            t * t * (3 * p0 - 6 * p1 + 3 * p2) +
            t * t * t * (-p0 + 3 * p1 - 3 * p2 + p3);
        public static Vector2 BezierCurve (Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) =>
            p0 +
            t * (-3 * p0 + 3 * p1) +
            t * t * (3 * p0 - 6 * p1 + 3 * p2) +
            t * t * t * (-p0 + 3 * p1 - 3 * p2 + p3);
        public static Vector2 BezierCurvePoint (Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t) =>
            (-p0 * (t * t * t) + 3 * p0 * (t * t) - 3 * p0 * t + p0) +
            (3 * p1 * (t * t * t) - 6 * p1 * (t * t) + 3 * p1 * t) +
            (-3 * p2 * (t * t * t) + 3 * p2 * t * t) +
            (p3 * (t * t * t));
        public static Vector3 BezierCurvePoint (Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) =>
            (-p0 * (t * t * t) + 3 * p0 * (t * t) - 3 * p0 * t + p0) +
            (3 * p1 * (t * t * t) - 6 * p1 * (t * t) + 3 * p1 * t) +
            (-3 * p2 * (t * t * t) + 3 * p2 * t * t) +
            (p3 * (t * t * t));
        public static Vector2 BezierCurveBernstein (Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t) =>
            p0 * (-(t * t * t) + 3 * (t * t) - 3 * t + 1) +
            p1 * (3 * (t * t * t) - 6 * (t * t) + 3 * t) +
            p2 * (-3 * (t * t * t) + 3 * (t * t)) +
            p3 * (t * t * t);
        public static Vector3 BezierCurveBernstein (Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) =>
            p0 * (-(t * t * t) + 3 * (t * t) - 3 * t + 1) +
            p1 * (3 * (t * t * t) - 6 * (t * t) + 3 * t) +
            p2 * (-3 * (t * t * t) + 3 * (t * t)) +
            p3 * (t * t * t);

        #endregion

        #region Range Repeating

        public static float Fractional (float x) => x - Floor (x);
        public static Vector2 Fractional (Vector2 v) => new Vector2 (v.x - Floor (v.x), v.y - Floor (v.y));
        public static Vector3 Fractional (Vector3 v) => new Vector3 (v.x - Floor (v.x), v.y - Floor (v.y), v.z - Floor (v.z));
        public static Vector4 Fractional (Vector4 v) => new Vector4 (v.x - Floor (v.x), v.y - Floor (v.y), v.z - Floor (v.z), v.w - Floor (v.w));
        public static float Repeat (float value, float length) => Clamp (value - Floor (value / length) * length, 0.0f, length);
        public static float PingPong (float t, float length) => length - Abs (Repeat (t, length * 2f) - length);

        #endregion 

        #region Angles and Direction

        public static float DirToAng (Vector2 v) => Atan2 (v.y, v.x);
        public static Vector2 AngToDir (float angRad) => new Vector2 (Cos (angRad), Sin (angRad));

        #endregion

    }
}