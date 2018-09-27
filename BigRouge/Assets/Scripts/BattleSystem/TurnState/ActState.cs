using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.BattleSystem {


    /// <summary>
    /// 处理行动
    /// 1.选择行动类型(道具,法术,攻击,特技等)
    /// 2.选择行动目标
    /// 3.执行行动
    /// </summary>
    public class ActState : TurnStateBase {

        private int actType;
        private Actor Target;
        private int skillID;


        public ActState(Actor actor) {
            this.actor = actor;
        }


        public override void HandlerCommand() {
        }


        public override void Enter () {
        }
        public override void Exit() {
        }


        public override void Update() {

        }


    }
}
