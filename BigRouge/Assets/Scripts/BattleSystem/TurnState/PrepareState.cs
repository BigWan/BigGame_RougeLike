using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigRogue.GameUI;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 准备状态,等待操作,根据状态显示不同的操作菜单
    /// 弹出操作菜单,
    /// 这阶段可以进行的操作:移动,使用技能,使用道具,结束回合
    /// </summary>
    public class PrepareState : TurnStateBase {

        public OperateMenu opMenu;

        public PrepareState(Actor actor) {
            this.actor = actor;
            this.opMenu = actor.battleManager.opMenu;
            Enter();
        }


        public override void HandlerCommand() {
            throw new System.NotImplementedException();
        }

        public override void Enter() {
            Debug.Log($"进入状态{this.GetType()}");
            ShowOperateMenu();
        }

        public override void Exit() {
            HideOperateMenu();
        }

        void MoveButton() {
            actor.ChangeTurnState(new MoveState(actor,actor.battleGround));
        }

        void ActButton() {

        }

        void FinishButton() {
            actor.turnFinished = true;
        }

        public void ShowOperateMenu() {
            opMenu.gameObject.SetActive(true);
            opMenu.Bind(actor);
            if (actor.allowMove) {
                opMenu.MoveButton.onClick.RemoveAllListeners();
                opMenu.MoveButton.onClick.AddListener(MoveButton);
                opMenu.MoveButton.gameObject.SetActive(true);
            } else {
                opMenu.MoveButton.gameObject.SetActive(false);
            }
            if (actor.allowAct) {
                opMenu.ActButton.onClick.RemoveAllListeners();
                opMenu.ActButton.onClick.AddListener(ActButton);
                opMenu.ActButton.gameObject.SetActive(true);
            } else {
                opMenu.ActButton.gameObject.SetActive(false);
            }
            opMenu.FinishButton.onClick.RemoveAllListeners();
            opMenu.FinishButton.onClick.AddListener(FinishButton);

            opMenu.FadeIn();

            //info.gameObject.SetActive(true);
            //info.SetCharacter(c);
            //info.FadeIn();
        }

        public void HideOperateMenu() {
            opMenu.gameObject.SetActive(false);
        }

        public override void Update() {
        }


    }
}
