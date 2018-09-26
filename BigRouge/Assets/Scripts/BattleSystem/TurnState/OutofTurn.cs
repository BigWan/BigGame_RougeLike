using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.BattleSystem {
    /// <summary>
    /// 不在回合内的状态
    /// </summary>
    public class OutofTurn : TurnStateBase {


        public OutofTurn(Actor actor) {
            this.actor = actor; 
        }

        public override void Enter() {
            
        }

        public override void Exit() {
        }

        public override void HandlerCommand() {
        }

        public override void Update() {
            
        }

        

    }
}
