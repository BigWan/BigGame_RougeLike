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
    public abstract class TurnStateBase {

        protected Actor actor { get; set; }

        public TurnStateBase(Actor actor) {
            this.actor = actor;
        }

        public abstract void Enter();
        public abstract void Exit();

        public abstract void HandlerCommand(CommandType cmd);


    }
}