using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BigRogue {

    /// <summary>
    /// 实体,玩家,怪物,Object...的基类
    /// 地形块,发射的子弹等都是Entity
    /// </summary>
    public abstract class Entity : MonoBehaviour {

        [Header("Entity Base Property")]
        public Vector3Int coord;

    }
}
