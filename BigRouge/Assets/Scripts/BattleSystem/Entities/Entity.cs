using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 实体,玩家,怪物,Object...的基类
    /// 地形块,发射的子弹等都是Entity
    /// </summary>
    public abstract class Entity : MonoBehaviour {

        [Header("Entity Base Property")]
        public Vector3Int coordinate3D;

        public int x { get { return coordinate3D.x; } }
        public int z { get { return coordinate3D.z; } }
        public int y { get { return coordinate3D.y; } }


        public Vector2Int coordinate2D { get { return new Vector2Int(x, z); } }
        public float height { get { return y * 0.5f; } }
    
        public Vector3 localPosition {
            get {
                return new Vector3(x, height, z);
            }
        }
    }
}
