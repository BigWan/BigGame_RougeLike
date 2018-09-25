using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BigRogue.BattleSystem {




    /// <summary>
    /// 战斗场景
    /// </summary>
    public class BattleGround : MonoBehaviour {


        public List<Block> blockPrefabs;

        public int width;
        public int length;

        private List<Block> terrain=new List<Block>();

        private void Awake() {
            terrain = GetComponentsInChildren<Block>().ToList();
        }

        private void Start() {
            SpawnBlock();
        }

        [ContextMenu("Spawn")]
        void SpawnBlock() {
            if (terrain != null) {
                foreach (var item in terrain) {
                    DestroyImmediate(item);
                }
                terrain.Clear();
            }

            for (int i = 0; i < length; i++) {
                for (int j = 0; j < width; j++) {
                    Block b =  Instantiate<Block>(blockPrefabs[Random.Range(0, blockPrefabs.Count)]);
                    b.transform.localPosition = new Vector3(i,0,j);
                    terrain.Add(b);
                    b.transform.SetParent(transform);
                    b.coordinate = new Vector3Int(i, 0, j);
                }
            }
        }



        private List<Block> moveRange;
        /// <summary>
        /// 高亮显示场景区域
        /// </summary>
        public void HighlightArea(Vector3Int center,int range,int lightColorIndex) {
            Debug.Log("显示高丽囊格子");
            List<Vector3Int> keys = GetManhattanCoordinate(center, range);
            Debug.Log($"找到{keys.Count}");
            if (moveRange == null)
                moveRange = new List<Block>();

            moveRange.Clear();
            //List<Block> result = new List<Block>();
            foreach (var block in terrain) {
                if(keys.Contains(block.coordinate)) {
                    moveRange.Add(block);
                }
            }
            Debug.Log($"有{moveRange.Count}个格子");

            foreach (var block in moveRange) {
                block.HighLight(lightColorIndex);
            }
        }

        /// <summary>
        /// 关闭高亮的地块
        /// </summary>
        public void CloseHighLight() {
            if (moveRange == null) {
                return;
            }

            foreach (var block in moveRange) {
                block.CloseHighLight();
            }
        }

        /// <summary>
        /// 获取曼哈顿满足曼哈顿距离的格子
        /// </summary>
        /// <param name="center"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        List<Vector3Int> GetManhattanCoordinate(Vector3Int center,int range) {
            List<Vector3Int> result = new List<Vector3Int>();
            int offset1 = 0;
            int offset2 = 0;
            for (int x =-range; x <= range; x++) {
                offset1 = range - Mathf.Abs(x); 
                for (int z = - offset1; z <= +offset1; z++) {
                    offset2 = range - Mathf.Abs(x) - Mathf.Abs(z);
                    for (int y = -offset2; y <= offset2; y++) {
                       result.Add(new Vector3Int(x, y, z)+center);
                    }
                }
            }

            return result;
        }


        public Texture2D BuildMiniMap() {
            return null;
        }



    }
}
