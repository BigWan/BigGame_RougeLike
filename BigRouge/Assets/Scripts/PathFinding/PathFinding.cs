using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BigRogue.PathFinding {

    /// <summary>
    /// 寻路功能主体
    /// </summary>
    public static class PathFinding {

        static int EdgeG = 10;    // 到边的ΔG
        static int CornerG = 14;  // 到角的ΔG

        static List<PathNode> openList;
        static List<PathNode> closeList;

        static PathFinding() {
            openList = new List<PathNode>();
            closeList = new List<PathNode>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh">寻路结点网格</param>
        /// <param name="start">开始结点</param>
        /// <param name="end">结束结点</param>
        /// <param name="hType">启发函数类型</param>
        /// <param name="hightLimit">高度限制</param>
        /// <returns>寻路结果,从起点到终点的结点列表</returns>
        public static List<PathNode> FindPath(NodeMesh mesh,
                                                PathNode start,
                                                PathNode end,
                                                HeuristicsType hType,
                                                bool isIgnoreCorner,
                                                float hightLimit = 0) {

            HeuristicsDelegate h = Heuristics.HeuristicsFactory(hType);


            openList.Clear();
            closeList.Clear();

            // 算法
            PathNode current;

            openList.Add(start);

            while (openList.Count !=0) {
                openList.OrderBy(n => n.f).ToList();
                current = openList[0];
                openList.RemoveAt(0);

                closeList.Add(current);


                List<PathNode> neighbours = mesh.GetNeighbour(current, isIgnoreCorner);

                foreach (PathNode item in neighbours) {
                    if (!!item.walkAble || closeList.Exists(x => x == item)) continue;
                    if (openList.Exists(x=>x==item) {

                    }
                }

                return new List<PathNode>(); ;
            }

        }

    }
}
