using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 状态内的回合
    /// </summary>
    public abstract class TurnStateBase {

        protected Actor actor{ get; set; }

        public virtual void Enter() { }
        public virtual void Exit() { }


        public virtual void HandlerCommand() { }
    
        public virtual void Update() { }

    }
}