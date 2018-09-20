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



        public Texture2D BuildMiniMap() {
            return null;
        }
        
    }
}
