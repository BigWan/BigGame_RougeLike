using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.ATB {
    /// <summary>
    /// 操作命令类型
    /// </summary>
    public enum CommandType {
        MoveCommand,
        AttackCommand,
        FinishCommand,
    }
    /// <summary>
    /// 状态内的回合
    /// </summary>
    public class TurnStateBase {

        protected Actor actor { get; set; }

        public TurnStateBase(Actor actor) {
            this.actor = actor;
        }

        /// <summary> 进入状态 </summary>
        public virtual void Enter() { }

        /// <summary> 退出状态 </summary>
        public virtual void Exit() { }
        /// <summary> 响应操作 </summary>
        public virtual void HandlerCommand(CommandType cmd) { }


    }
}