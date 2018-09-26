using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 状态内的回合
    /// </summary>
    public abstract class TurnStateBase {

        protected Actor actor{ get; set; }

        public abstract void Enter();
        public abstract void Exit();


        public abstract void HandlerCommand();

        public abstract void Update();

    }
}