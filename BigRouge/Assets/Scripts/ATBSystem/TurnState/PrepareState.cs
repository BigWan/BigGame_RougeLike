using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigRogue.GameUI;
using BigRogue;

namespace BigRogue.ATB {

    /// <summary>
    /// 准备状态,等待操作,根据状态显示不同的操作菜单
    /// 弹出操作菜单,
    /// 这阶段可以进行的操作:移动,使用技能,使用道具,结束回合
    /// </summary>
    public class PrepareState : TurnStateBase {

        public PrepareState(Actor actor) : base(actor) {}


        public override void Enter() {
            Debug.Log($"进入状态{this.GetType()}");
            actor.ShowOperateMenu();
        }

        public override void Exit() {
            actor.HideOperateMenu();
        }

        public override void HandlerCommand(CommandType cmd) {

        }






    }
}
