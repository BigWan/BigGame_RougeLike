using UnityEngine;
using System.Collections;
using BigRogue.BattleSystem;

namespace BigRogue {
    public abstract class Command {
        public abstract void Execute();
    }

    public class MoveCommand : Command {

        Actor character;
        Vector3 speed;
        System.Action callBack;

        MoveCommand(Actor character, Vector3 speed, System.Action callBack) {
            this.character = character;
            this.speed = speed;
            this.callBack = callBack;
        }

        public override void Execute() {

        }
    }

}
