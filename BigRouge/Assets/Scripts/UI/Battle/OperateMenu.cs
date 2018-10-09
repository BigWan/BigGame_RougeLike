using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BigRogue.BattleSystem;
using System;
using UnityEngine.Events;

namespace BigRogue.GameUI {

    /// <summary>
    /// 单位的操作菜单
    /// </summary>
    public class OperateMenu : MonoBehaviour {

        [SerializeField]
        private Text CaptionText;

        [Header("按钮")]
        [SerializeField] private  Button btnMove;
        [SerializeField] private  Button btnAction;
        [SerializeField] private  Button btnFinish;
        [Header("子菜单")]
        [SerializeField] private  GameObject actGroup;
        [SerializeField] private  Button btnAttack;
        [SerializeField] private  Button btnSpell;
        [SerializeField] private  Button btnItem;

        [Header("法术子菜单")]
        [SerializeField] private  GameObject spellGroup;

        CanvasGroup cg;
        RectTransform rectTrans;

        private void Awake() {
            cg = GetComponent<CanvasGroup>();
            rectTrans = GetComponent<RectTransform>();
            actGroup.SetActive(false);
        }

        void ShowButton(Button btn, UnityAction action) {
            btn._SetActive(true);
            btn.onClick.AddListener(action);
        }

        /*   public  method    */

        /// <summary> 淡入 </summary>
        public void FadeIn() {
            cg.alpha = 1;
        }

        /// <summary> 淡出 </summary>
        public void FadeOut() {
            cg.alpha = 0f;
        }

        /// <summary> 设置标题 </summary>
        public void SetTitle(string title) {
            CaptionText.text = title.ToUpper();
        }

        /// <summary> 绑定移动按钮 </summary>
        public void ShowMoveButton(UnityAction action) {
            ShowButton(btnMove, action);
        }

        /// <summary> 绑定行动按钮//TODO 行动需要分类型 </summary>
        public void ShowActButton(UnityAction action) {
            ShowButton(btnAction, action);
        }

        /// <summary> 绑定结束按钮 </summary>
        /// <param name="action"></param>
        public void ShowFinishButton(UnityAction action) {
            ShowButton(btnFinish, action);
        }


        /// <summary>
        /// 清除绑定
        /// </summary>
        public void Reset() {
            btnMove._SetActive(false);
            btnMove.onClick.RemoveAllListeners();

            btnAction._SetActive(false);
            btnAction.onClick.RemoveAllListeners();

            btnFinish._SetActive(false);
            btnFinish.onClick.RemoveAllListeners();
        }



    }
}
