using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigRogue;

namespace BigRogue.ATB {

    /// <summary>
    /// 处理行动
    /// 1.选择行动类型(道具,法术,攻击,特技等)
    /// 2.选择行动目标
    /// 3.执行行动
    /// </summary>
    public class ActState : TurnStateBase {


        private int actType;
        private Actor target;
        private int skillID;


        public ActState(Actor actor):base(actor) {
        }





        public override void Enter() {
            throw new System.NotImplementedException();
        }



        public override void Exit() {
            throw new System.NotImplementedException();
        }

        public override void HandlerCommand(CommandType cmd) {
            throw new System.NotImplementedException();
        }


    }
}
