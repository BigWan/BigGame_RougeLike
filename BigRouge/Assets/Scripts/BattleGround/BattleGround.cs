using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BigRogue.PathFinding;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 战斗场景
    /// </summary>
    public class BattleGround : MonoBehaviour {

        [Header("Prefab Refs")]
        public List<Block> blockPrefabs;

        [Header("BG Size")]
        public int width;
        public int length;

        /// <summary>
        /// 一个单位坐标表示几米高度
        /// </summary>
        public float heightStep = 0.5f;

        [Header("Selected")]
        public List<Block> selectedBlocks;

        public System.Action<Block> SelectBlockEventHandler;


        // Refs
        private List<Block> terrain;


        private void Awake() {
            terrain = new List<Block>();
            terrain = GetComponentsInChildren<Block>().ToList();
            selectedBlocks = new List<Block>();
            movingArea = new List<Block>();
        }

        private void Start() {
            SpawnBlock();
        }

        void SpawnBlock() {
            if (terrain != null) {
                foreach (var item in terrain) {
                    DestroyImmediate(item);
                }
                terrain.Clear();
            }

            for (int z = 0; z < length; z++) {
                for (int x = 0; x < width; x++) {
                    Block b = Instantiate<Block>(blockPrefabs[Random.Range(0, blockPrefabs.Count)]);

                    b.coord = new Vector3Int(x, 0, z);
                    b.battleGround = this;

                    b.transform.localPosition = b.coord;
                    b.transform.SetParent(transform);

                    terrain.Add(b);
                }
            }
        }

        public bool allowMultiple = true;
        public void SelectBlock(Block block) {
            if (!allowMultiple) {
                foreach (var b in selectedBlocks) {
                    b.Deselect();
                }
                selectedBlocks.Clear();
            }
            selectedBlocks.Add(block);
            SelectBlockEventHandler?.Invoke(block);
        }


        public List<Block> movingArea;
        /// <summary>
        /// 显示一个单位可以移动的范围
        /// </summary>
        public List<Block> ShowMovingArea(Vector3Int center, int range, int lightColorIndex) {

            List<Vector3Int> keys = GetManhattanCoordinate(center, range);
            Debug.Log($"GetManhattanCoordinate:{keys.Count}");

            movingArea.Clear();
            foreach (var block in terrain) {
                if (keys.Contains(block.coord)) {
                    movingArea.Add(block);
                }
            }
            Debug.Log($"movingArea.Count:{movingArea.Count}");
            foreach (var block in movingArea) {
                block.HighLight(lightColorIndex);
            }
            return movingArea;
        }

        public List<Block> ShowMovingArea(Actor actor) {
            throw new UnityException("功能未实现");
        }



        /// <summary>
        /// 关闭高亮的地块
        /// </summary>
        public void HideMovingArea() {
            foreach (var block in movingArea) {
                block.CloseHighLight();
            }
        }

        /// <summary>
        /// 获取曼哈顿满足曼哈顿距离的格子
        /// </summary>
        /// <param name="center"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        List<Vector3Int> GetManhattanCoordinate(Vector3Int center, int range) {
            List<Vector3Int> result = new List<Vector3Int>();
            int offset1 = 0;
            int offset2 = 0;
            for (int x = -range; x <= range; x++) {
                offset1 = range - Mathf.Abs(x);
                for (int z = -offset1; z <= +offset1; z++) {
                    offset2 = range - Mathf.Abs(x) - Mathf.Abs(z);
                    for (int y = -offset2; y <= offset2; y++) {
                        result.Add(new Vector3Int(x, y, z) + center);
                    }
                }
            }

            return result;
        }





        public Texture2D BuildMiniMap() {
            return null;
        }

        /// <summary>
        ///// 获取寻路的结点
        ///// </summary>
        ///// <returns></returns>
        //public List<PathNode> GetPathNode() {
        //    PathFinding.PathFinding.FindPath()
        //}

        /// <summary>
        /// 生成寻路网
        /// </summary>
        public NodeMesh PathNodeMesh() {
            NodeMesh mesh = new NodeMesh();
            foreach (var block in terrain /*movingArea*/) {
                mesh.AddNode(block.coord, new PathNode(block));
            }
            return mesh;
        }

    }
}
