using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 寻路模块
/// </summary>
namespace BigRogue.PathFinding {

    public delegate float HeuristicsDelegate(int x, int y);


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
        public static float Manhattan(int x,int y) {
            return Mathf.Abs(x) + Mathf.Abs(y);
        }
        
        /// <summary>
        /// 欧几里得
        /// </summary>
        public static float Euclidean(int x,int y) {
            return Mathf.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// 切比雪夫
        /// </summary>
        public static float Chebyshev(int x,int y) {
            return Mathf.Max(x, y);
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
