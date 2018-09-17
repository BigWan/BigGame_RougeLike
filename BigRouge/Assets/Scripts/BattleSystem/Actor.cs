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
    public abstract class Actor : Entity, IEnergy, IProjectAble, ILevelup,IDamageAble,IMeleeAttack {

        //public new string name { get { return transform.name; }set { transform.name = value; } }
        public int level = 1;
        public int sight = 20;

        public CombatStats stat;

        /// <summary>
        /// 行动速度,每次Tick增加的能量值
        /// </summary>
        public float energySpeed;

        int ILevelup.startLevel => throw new NotImplementedException();

        int ILevelup.level => throw new NotImplementedException();

        int ILevelup.maxLevel => throw new NotImplementedException();


        float IEnergy.energy => throw new NotImplementedException();

        float IEnergy.energyRegen => throw new NotImplementedException();

        public abstract override void Tick();

        public abstract void CanAct();
        public abstract void Act();

        public abstract void CanMoveTo(int x, int y);
        public abstract void Move(int x,int y,bool force = false);


        void IProjectAble.Project(object o, int x, int y) {
            throw new NotImplementedException();
        }

        void IProjectAble.ProjectTile(object o, int x, int y, Func<int> onHit) {
            throw new NotImplementedException();
        }

        bool IProjectAble.CanProject(object o, int x, int y) {
            throw new NotImplementedException();
        }

        void IMeleeAttack.Attack() {
            throw new NotImplementedException();
        }

        void IMeleeAttack.OnAttack() {
            throw new NotImplementedException();
        }

        void IDamageAble.TakeHit() {
            throw new NotImplementedException();
        }



        void IDamageAble.OnTakeDamage() {
            throw new NotImplementedException();
        }



        int ILevelup.nextLevelNeedExp(int nextLevel) {
            throw new NotImplementedException();
        }

        void ILevelup.Levelup() {
            throw new NotImplementedException();
        }

        void ILevelup.LevelTo(int level) {
            throw new NotImplementedException();
        }

        void ILevelup.GainExp(int exp) {
            throw new NotImplementedException();
        }

        void IEnergy.useEnergy() {
            throw new NotImplementedException();
        }
    }
}
