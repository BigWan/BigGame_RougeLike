using UnityEngine;
using System.Collections;
using BigRogue.ATB;
using UnityEngine.Events;

//using UnityEngine.UI;


namespace BigRogue.GameUI {

    /// <summary>
    /// 战斗场景的UI
    /// </summary>
    public class BattleUIRoot : MonoBehaviour {

        private OperateMenu opMenu;
        private HeadBar headbar;


        private void Awake() {
            opMenu = GetComponentInChildren<OperateMenu>();
            headbar = GetComponentInChildren<HeadBar>();
        }

        /// <summary>
        /// 弹出角色的操作按钮
        /// </summary>
        /// <param name="actor">操作按钮的对象实例</param>
        public void PopupOperateMenu(Actor actor) {
            opMenu.gameObject.SetActive(true);
            opMenu.SetTitle(actor.name);

            if (actor.allowMove) opMenu.ShowMoveButton(actor.OnMoveButtonClick);
           
            if (actor.allowAct) opMenu.ShowActButton(actor.OnActButtonClick);
            
           opMenu.ShowFinishButton(actor.OnFinishButtonClick);
            opMenu.FadeIn();
        }

        public void HideOperateMenu() {
            opMenu.Reset();
            opMenu.FadeOut();
        }

        /// <summary>
        /// 清除按钮状态和委托
        /// </summary>
        public void ClearData() {
            opMenu.Reset();
        }

    }
}
