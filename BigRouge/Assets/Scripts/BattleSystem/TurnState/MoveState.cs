using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.BattleSystem {
    /// <summary>
    /// 移动处理 
    /// 1.选择目的地
    /// 2.移动
    /// </summary>
    public class MoveState : TurnStateBase {

        private BattleGround battleGround;

        private List<Block> movingArea;

        private Vector3Int moveTarget;

        public MoveState(Actor actor,BattleGround bg) {
            this.actor = actor;
            this.battleGround = bg;
            movingArea = new List<Block>();

            battleGround.SelectBlockEventHandler += SelectBlock;
            actor.MoveOverHandler += MoveFinish;
        }


        public void SelectBlock(Block b) {
            if (movingArea.Contains(b)) {
                moveTarget = b.coordinate;
                StartMoving(moveTarget);
            } else {
                Debug.Log($"无法移动到{b.coordinate}");
            }
        }

        private void StartMoving(Vector3Int target) {
            actor.StartMove(target);
            //actor.ChangeTurnState(new MovingState(actor, b));
        }

        public override void Enter () {
            movingArea = battleGround.HighlightArea(actor.coordinate, actor.moveRange, 2);
            
            Debug.Log($"可行动区域有{movingArea.Count}");
        }

        void MoveFinish() {
            actor.allowMove = false;
            actor.ChangeTurnState(new WaitInputState(actor));
        }

        public override void Exit() {
            battleGround.SelectBlockEventHandler -= SelectBlock;
            actor.MoveOverHandler -= MoveFinish;
            movingArea.Clear();
            battleGround.HideMovingArea();
            
        }


    }
}
