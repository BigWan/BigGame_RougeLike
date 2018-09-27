using UnityEngine;
using System.Collections;

namespace BigRogue.PathFinding {

    /// <summary>
    /// 寻路的结点
    /// </summary>
    public class PathNode {

        public Vector2Int coordinate;       // 坐标
        public bool walkAble;               // 是否可走
                                            //public float weight;                // 权重

        /// <summary>
        /// 本Node到终点的h启发函数的值
        /// </summary>
        public float h;

        /// <summary>
        /// 本Node到起点的值
        /// </summary>
        public float g;

        /// <summary>
        /// 股价函数值
        /// </summary>
        public float f { get { return h + g; } }

        public PathNode parent;             // 
        public PathNode child;

        public override bool Equals(object obj) {
            if (!(obj is PathNode)) return false;
            PathNode node = (PathNode)obj;
            return coordinate == node.coordinate;
        }

        public override int GetHashCode() {
            return coordinate.x ^ coordinate.y;
        }

    }

}
