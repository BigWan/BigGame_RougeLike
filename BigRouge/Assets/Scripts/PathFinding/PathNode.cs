using UnityEngine;
using System.Collections;

namespace BigRogue.PathFinding {

    /// <summary>
    /// 寻路的结点
    /// </summary>
    public class PathNode {

        public Vector2Int coordinate;       // 坐标

        public bool aviable;   // 能否寻路

        public float height;   // 高度

        /// <summary>
        /// 到终点的Cost,只需计算一次
        /// </summary>
        public float h;

        /// <summary>
        /// 到起点的Cost,会不断更新
        /// </summary>
        public float g;

        /// <summary>
        /// 整体的Cost
        /// </summary>
        public float f { get { return h + g; } }

        /// <summary>
        /// 从Block构造
        /// </summary>
        /// <param name="block"></param>
        public PathNode(BattleSystem.Block block) {
            coordinate = new Vector2Int(block.coordinate.x, block.coordinate.z);
            height = block.coordinate.y;
        }


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

        /// <summary>
        /// 是否需要更新 center 为新的 parent
        /// </summary>
        /// <param name="center"></param>
        /// <param name="func"></param>
        public void UpdateFrom(PathNode center,HeuristicsDelegate func) {
            float deltaG = func(this.coordinate, center.coordinate);
            float newG = center.g + deltaG;
            if(newG < g) {
                parent = center;
                g = newG;
            }
        }

        // 发现一个新点
        public void InitFrom(PathNode center,PathNode end,HeuristicsDelegate func) {
            float deltaG = func(this.coordinate, center.coordinate);
            g = center.g + g;
            h = func(this.coordinate, end.coordinate);
            parent = center;
        }

    }

}
