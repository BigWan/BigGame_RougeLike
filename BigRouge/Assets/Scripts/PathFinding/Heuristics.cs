using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace BigRogue.PathFinding {

    /// <summary>
    /// 2D网格结点的距离计算
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <returns></returns>
    public delegate float HeuristicsDelegate(Vector2Int p1,Vector2Int p2);


    public enum HeuristicsType {
        Manhattan,
        Chebyshev,
        Euclidean
    }


    /// <summary>
    /// 启发函数
    /// </summary>
    public class Heuristics {

        /// <summary>
        /// 曼哈顿
        /// </summary>
        public static float Manhattan(Vector2Int n1,Vector2Int n2) {
            return Mathf.Abs(n1.x-n2.x) + Mathf.Abs(n1.y-n2.y);
        }
        
        /// <summary>
        /// 欧几里得
        /// </summary>
        public static float Euclidean(Vector2Int n1, Vector2Int n2) {
            return Vector2Int.Distance(n1, n2);
        }

        /// <summary>
        /// 切比雪夫
        /// </summary>
        public static float Chebyshev(Vector2Int n1, Vector2Int n2) {
            return Mathf.Max(Mathf.Abs(n1.x-n2.x), Mathf.Abs(n1.y-n2.y));
        }


        public static HeuristicsDelegate HeuristicsFactory(HeuristicsType hType) {

            switch (hType) {
                case HeuristicsType.Manhattan:return Manhattan;
                case HeuristicsType.Chebyshev:return Chebyshev;
                case HeuristicsType.Euclidean:return Euclidean;
                default: return Manhattan;
            }

        }

    }
}
