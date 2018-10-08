using UnityEngine;
using System.Collections;
//using UnityEngine.UI;


namespace BigRogue.GameUI {

    /// <summary>
    /// 战斗场景的UI
    /// </summary>
    public class BattleUIRoot : MonoBehaviour {

        public OperateMenu opMenu;
        public HeadBar headbar;


        private void Awake() {
            opMenu = GetComponentInChildren<OperateMenu>();
            headbar = GetComponentInChildren<HeadBar>();
        }


        public void ShowOperateMenu(Actor actor) {
            opMenu.gameObject.SetActive(true);
            opMenu.Bind(actor);
            if (actor.allowMove) {
                opMenu.MoveButton.onClick.RemoveAllListeners();
                opMenu.MoveButton.onClick.AddListener(actor.move);
                opMenu.MoveButton.gameObject.SetActive(true);
            } else {
                opMenu.MoveButton.gameObject.SetActive(false);
            }
            if (allowAct) {
                opMenu.ActButton.onClick.RemoveAllListeners();
                opMenu.ActButton.onClick.AddListener(() => ChangeTurnState(TurnStateType.Moving));
                opMenu.ActButton.gameObject.SetActive(true);
            } else {
                opMenu.ActButton.gameObject.SetActive(false);
            }
            opMenu.FinishButton.onClick.RemoveAllListeners();
            opMenu.FinishButton.onClick.AddListener(() => turnFinished = true);

            opMenu.FadeIn();
        }


    }
}
