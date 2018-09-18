using System;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 发射器,发射子弹和法术等投射物实体Entity
    /// </summary>
    public class Shooter : MonoBehaviour {

        // 发射子弹(发射即击中)
        void Project(object o,int x,int y) { }

        // 发射实体子弹(不是马上击中的类型)
        void ProjectEntity(Entity e, int x, int y) { }

        bool CanProject(Entity e, int x, int y) {
            return true;
        }

    }
}
