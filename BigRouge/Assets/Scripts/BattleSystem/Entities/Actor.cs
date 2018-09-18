using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 角色抽象类
    /// </summary>
    public abstract class Actor : Entity {


        [Header("Actor.EnergyGroup")]
        /// <summary>
        /// 能量值
        /// </summary>
        public float energy;

        /// <summary>
        /// 能量恢复值
        /// </summary>
        public float energyRegen;
        
        /// <summary>
        /// 使用能量
        /// </summary>
        public abstract void useEnergy();


        /// <summary>
        /// 恢复能量
        /// </summary>
        public abstract void RegenEnergy();

        /// <summary>
        /// 判断是否能行动
        /// </summary>
        /// <returns></returns>
        public abstract bool CanAct();


        /// <summary>
        /// 行动
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerator Act();

        /// <summary>
        /// 能否到达目标点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public abstract bool CanMoveTo(int x, int y);

        /// <summary>
        /// 移动到目标点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="force"></param>
        public abstract void Move(int x, int y, bool force = false);

    }
}
