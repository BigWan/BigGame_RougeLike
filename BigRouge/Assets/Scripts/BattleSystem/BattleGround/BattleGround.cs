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

        private List<Block> terrain;

        private void Awake() {
            terrain = new List<Block>();
            terrain = GetComponentsInChildren<Block>().ToList();
        }


        [ContextMenu("Spawn")]
        void SpawnBlock() {
            foreach (var item in terrain) {
                DestroyImmediate(item);
            }
            terrain.Clear();

            for (int i = 0; i < length; i++) {
                for (int j = 0; j < width; j++) {
                    Block b =  Instantiate<Block>(blockPrefabs[Random.Range(0, blockPrefabs.Count)]);
                    b.transform.localPosition = new Vector3(i,0,j);
                    terrain.Add(b);
                    b.transform.SetParent(transform);
                }
            }
        }


        /// <summary>
        /// 高亮显示场景区域
        /// </summary>
        public void HighlightArea(Vector3Int center,int range,BlockHightLightType lightType) {

            List<Vector3Int> keys = GetManhattanCoordinate(center, range);
            List<Block> result = new List<Block>();
            foreach (var block in terrain) {
                if(keys.Contains(block.coordinate)) {
                    result.Add(block);
                }
            }

            foreach (var block in result) {
                block.HighLight(lightType);
            }
        }

        /// <summary>
        /// 获取曼哈顿满足曼哈顿距离的格子
        /// </summary>
        /// <param name="center"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        List<Vector3Int> GetManhattanCoordinate(Vector3Int center,int range) {
            range -= 1;
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

        private void Start() {
            List<Vector3Int> aa = new List<Vector3Int>();

            aa = GetManhattanCoordinate(new Vector3Int(5, 0, 5), 3);
            Debug.Log(aa.Count);    
            for (int i = 0; i < aa.Count; i++) {
                Debug.Log(aa[i]);
            }
        }

    }
}
