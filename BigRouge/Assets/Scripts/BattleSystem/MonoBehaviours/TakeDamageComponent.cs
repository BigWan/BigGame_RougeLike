using System;
using UnityEngine;


namespace BigRogue.BattleSystem {
    /// <summary>
    /// 受击组件
    /// </summary>
    public class TakeDamageComponent : MonoBehaviour {

        /// <summary>
        /// 受伤事件
        /// </summary>
        public Action TakeHitEventHandler;

        /// <summary>
        /// 治疗事件
        /// </summary>
        public Action TakeHealEventHandler;

        /// <summary>
        /// 死亡事件
        /// </summary>
        public Action DieEventHandler;

        /// <summary>
        /// 最大生命值
        /// </summary>
        [SerializeField]
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
        /// 受到治疗加血
        /// </summary>
        void TakeHeal() {

        }

        /// <summary>
        /// 死亡处理
        /// </summary>
        void Die() {

        }
    }


}
