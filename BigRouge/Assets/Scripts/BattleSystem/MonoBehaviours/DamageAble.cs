using System;
using UnityEngine;


namespace BigRogue.BattleSystem {
    /// <summary>
    /// 管理被攻击的组件
    /// </summary>
    public class DamageAble:MonoBehaviour {

        /// <summary>
        /// 受伤事件
        /// </summary>
        public Action TakeHitEventHandler;

        /// <summary>
        /// 死亡事件
        /// </summary>
        public Action DieEventHandler;

        /// <summary>
        /// 最大生命值
        /// </summary>
        float maxHp { get; set; }


        /// <summary>
        /// 当前生命值
        /// </summary>
        float currentHp{ get; set; }


        /// <summary>
        /// 受伤
        /// </summary>
        void TakeHit() {

        }

        /// <summary>
        /// 死亡处理
        /// </summary>
        void Die() {

        }
    }


}
