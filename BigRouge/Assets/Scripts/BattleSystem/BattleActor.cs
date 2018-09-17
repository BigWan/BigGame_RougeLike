using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.BattleSystem {

    

    /// <summary>
    /// 战斗角色
    /// </summary>
    public abstract class BattleActor : MonoBehaviour {

        /// <summary>
        /// 行动速度,每次Tick增加的速度值
        /// </summary>
        public float actionSpeed;



        public abstract void Tick();

        public abstract void Act();

        public abstract void Move(int x,int y,bool force = false);

        public abstract void CanMoveTo(int x, int y);

        public abstract void KnockBack();

        /// <summary>
        /// 开始行动
        /// </summary>
        public abstract void TickBegin();

        /// <summary>
        /// 行动
        /// </summary>
        public abstract void Tick();



        /// <summary>
        /// 行动结束
        /// </summary>
        public abstract void TickEnd();



    }
}
