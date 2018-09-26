using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigRogue.GameUI;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 回合等待输入的状态
    /// 需要处理按钮输入
    /// </summary>
    public class WaitSelectActionState : TurnStateBase {

        OperateMenu opMenu;

        public WaitSelectActionState(Actor actor) {
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
            actor.ChangeTurnState(new FinishingState(actor));
        }

        public void ShowOperateMenu() {
            opMenu.gameObject.SetActive(true);
            opMenu.Bind(actor);
            if (actor.allowMove) {
                opMenu.MoveButton.onClick.AddListener(MoveButton);
                opMenu.MoveButton.gameObject.SetActive(true);
            } else {
                opMenu.MoveButton.gameObject.SetActive(false);
            }
            if (actor.allowAct) {
                opMenu.ActButton.onClick.AddListener(ActButton);
                opMenu.ActButton.gameObject.SetActive(true);
            } else {
                opMenu.ActButton.gameObject.SetActive(false);
            }
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
