using UnityEngine;
using System.Collections;
using System;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 可以被攻击
    /// </summary>
    public interface IDamageAble {

        // 一系列事件

        /// <summary>
        /// 受击事件
        /// </summary>
        Action TakeHitEventHandler { get; }
        /// <summary>
        /// 受伤事件
        /// </summary>
        Action TakeDamageEventHanlder { get; }
        /// <summary>
        /// 死亡事件
        /// </summary>
         Action DieEventHandler { get; }

        /// <summary>
        /// 当前生命值
        /// </summary>        
        float currentHp { get; set; }

        /// <summary>
        /// 受伤
        /// </summary>
        void TakeHit();

        /// <summary>
        /// 死亡处理
        /// </summary>
        void Die();

    }
}


