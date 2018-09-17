using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 能量接口
    /// </summary>
    public interface IEnergy {
        // 能量恢复速度
        float energy { get; }
        float energyRegen { get; }
        void useEnergy();
    }


    /// <summary>
    /// 战斗角色
    /// </summary>
    public abstract class Actor : Entity {

        //public new string name { get { return transform.name; }set { transform.name = value; } }
        public int sight = 20;

        public CombatStats stat;

        public abstract override void Tick();

        public abstract void CanAct();
        public abstract void Act();

        public abstract void CanMoveTo(int x, int y);
        public abstract void Move(int x,int y,bool force = false);

    }
}
