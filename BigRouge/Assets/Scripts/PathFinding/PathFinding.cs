using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BigRogue.PathFinding {

    /// <summary>
    /// 寻路功能主体
    /// </summary>
    public static class PathFinding {



        static List<PathNode> openList;
        static List<PathNode> closeList;

        static PathFinding() {
            openList = new List<PathNode>();
            closeList = new List<PathNode>();
        }

        /// <summary>
        /// 检测能否到达邻点
        /// </summary>
        /// <param name="current">起点</param>
        /// <param name="neighbour">邻点</param>
        /// <param name="hightLimit">高差限制(能从高处走到低处,不能从低处走向高处)</param>
        /// <returns></returns>
        static bool CanMoveTo(PathNode current, PathNode neighbour, float hightLimit) {
            if (!neighbour.aviable) return false;

            return neighbour.height - current.height < hightLimit;
        }


        /// <summary>
        /// 寻路主算法
        /// </summary>
        /// <param name="mesh">寻路结点网格</param>
        /// <param name="start">开始结点</param>
        /// <param name="end">结束结点</param>
        /// <param name="hType">启发函数类型</param>
        /// <param name="hightLimit">高度限制</param>
        /// <returns>寻路结果,从起点到终点的结点列表</returns>
        public static List<PathNode> FindPath(NodeMesh mesh, PathNode start, PathNode end, HeuristicsType hType, bool isIgnoreCorner, float hightLimit = 0) {

            HeuristicsDelegate hFunc = Heuristics.HeuristicsFactory(hType);

            openList.Clear();
            closeList.Clear();

            // 算法
            PathNode current;
            openList.Add(start);

            // 循环处理开放节点列表(边界)
            while (openList.Count > 0) {

                openList.OrderBy(n => n.f).ToList();

                current = openList[0];

                if (current == end) break;

                openList.Remove(current);
                closeList.Add(current);

                // 获取相邻节点
                List<PathNode> neighbours = mesh.GetNeighbour(current, isIgnoreCorner);

                // 遍历处理邻居节点
                foreach (PathNode nb in neighbours) {
                    // 已经在关闭列表则跳过
                    if (!CanMoveTo(current, nb, hightLimit)) continue;
                    if (closeList.IndexOf(nb) > -1) continue;

                    // 在开放列表(检测边界)
                    if (openList.IndexOf(nb) > -1) {   // nb在open列表中
                        // 检测,是否需要 (更新G值,设置parent为current)
                        nb.UpdateFrom(current, hFunc);
                    }
                    // 新出现的节点
                    else {
                        // 计算H 和parent和G
                        nb.InitFrom(current, end, hFunc);

                    }
                }
            }
            return new List<PathNode>(); 
        }

    }
}
