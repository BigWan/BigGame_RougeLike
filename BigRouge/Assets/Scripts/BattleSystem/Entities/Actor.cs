using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


namespace BigRogue.BattleSystem {

    /// <summary>
    /// 角色抽象类
    /// 角色可以行动()
    /// </summary>
    public abstract class Actor : Entity {

        // 属性
        public float energy;
        public float energyRegen;

        public abstract void RegenEnergy();
        public abstract void UseEnergy();
        public abstract bool IsEnergyEnough(float energy);

        // 一系列事件

        protected Action<Actor> ActStartEventHandler;
        protected Action<Actor> ActEndEventHandler;
        public Action<Actor> TurnStartEventHandler;
        public Action<Actor> TurnEndEventHandler;
        public Action<Actor> MoveStartEventHandler;
        public Action<Actor> MoveEndEventHandler;


        // 一系列操作

        public abstract IEnumerator ActiveTurn();

    }
}
