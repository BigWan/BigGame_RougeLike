using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigRogue.PathFinding;
using BigRogue;
using BigRogue.ATB;
using BigRogue.BattleSystem;
using BigRogue.Ground;

namespace BigRogue.ATB {
    /// <summary>
    /// 移动处理 
    /// 1.选择目的地
    /// 2.移动
    /// </summary>
    public class MoveState : TurnStateBase {

        private BattleGround battleGround;

        //private List<Block> movingArea;

        private Vector3Int moveTargetCoord;

        public MoveState(Actor actor,BattleGround bg):base(actor) {
            this.battleGround = bg;
            //movingArea = new List<Block>();

            battleGround.SelectBlockEventHandler += SelectBlock;
            actor.MoveOverHandler += MoveFinish;
        }


        public void SelectBlock(Block b) {
            if (battleGround.movingArea.Contains(b)) {
                moveTargetCoord = b.coord;
                //StartMoving(moveTarget); // lerp
                battleGround.HideMovingArea();
                actor.StartMove(b);
            }
        }

        //void StartMove(Vector3Int target) {
        //    battleGround.HideMovingArea();
        //    actor.StartMove(target);
        //    //actor.ChangeTurnState(new MovingState(actor, b));
        //}

        public override void Enter () {

            moveTargetCoord = Vector3Int.zero;
            battleGround.ShowMovingArea(actor.coord, actor.moveRange, 2);
            
            //Debug.Log($"可行动区域有{battleGround.movingArea.Count}");
        }

        /// <summary>
        /// 移动结束切回待机
        /// </summary>
        void MoveFinish() {
            actor.allowMove = false;
            actor.EnterState(TurnStateType.Preparing);
        }

        public override void Exit() {
            battleGround.SelectBlockEventHandler -= SelectBlock;
            actor.MoveOverHandler -= MoveFinish;



            battleGround.HideMovingArea();
        }

        public override void HandlerCommand(CommandType cmd) {
            throw new System.NotImplementedException();
        }

    }
}
