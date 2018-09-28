using UnityEngine;
using System.Collections;

namespace BigRogue.PathFinding {

    /// <summary>
    /// 寻路的结点
    /// </summary>
    public class PathNode {

        public Vector2Int coordinate2D;       // 坐标

        public int y { get; set; }

        public int x { get { return coordinate2D.x; } }
        public int z { get { return coordinate2D.y; } }

        public bool aviable;   // 能否行走


        /// <summary>
        /// Node的坐标
        /// </summary>
        public Vector3 position {
            get {
                return new Vector3(x,y,z);
            }
        }

        public Vector3Int coordinate3D {
            get { return new Vector3Int(x, y, z); }
        }

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
            coordinate2D = new Vector2Int(block.x, block.z);
            y = block.y;
            aviable = true;
        }

        public PathNode(Vector2Int coordinate2D) {
            this.coordinate2D = coordinate2D;
            y = 0;
            aviable = true;
        }


        public PathNode parent;             // 
        public PathNode child;

        public override bool Equals(object obj) {
            if (!(obj is PathNode)) return false;
            PathNode node = (PathNode)obj;
            return coordinate2D == node.coordinate2D;
        }

        public override int GetHashCode() {
            return coordinate2D.x ^ coordinate2D.y;
        }

        /// <summary>
        /// 是否需要更新 center 为新的 parent
        /// </summary>
        /// <param name="center"></param>
        /// <param name="func"></param>
        public void UpdateFrom(PathNode center,HeuristicsDelegate func) {
            float deltaG = func(this.coordinate2D, center.coordinate2D);
            float newG = center.g + deltaG;
            if(newG < g) {
                parent = center;
                g = newG;
            }
        }

        // 发现一个新点
        public void InitFrom(PathNode center,PathNode end,HeuristicsDelegate func) {
            float deltaG = func(this.coordinate2D, center.coordinate2D);
            g = center.g + deltaG;
            h = func(this.coordinate2D, end.coordinate2D);
            parent = center;
        }

    }

}
