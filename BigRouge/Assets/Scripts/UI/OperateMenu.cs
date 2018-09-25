using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BigRogue.BattleSystem;
using DG.Tweening;


namespace BigRogue.GameUI {

    /// <summary>
    /// 游戏中在单位点出来的菜单
    /// //常见功能有 移动 攻击 待机
    /// </summary>
    public class OperateMenu : MonoBehaviour {

        public Text CaptionText;
        public Button MoveButton;
        public Button ActButton;
        public Button FinishButton;

        private Actor character;

        CanvasGroup cg ;
        RectTransform rectTrans;

        private void Awake() {
            cg = GetComponent<CanvasGroup>();
            rectTrans = GetComponent<RectTransform>();
        }

        //public void SetCharacter(Character character) {
        //    this.character = character;
        //    CaptionText.text = character.name;
        //}

        public void FadeIn() {
            rectTrans.anchoredPosition3D = new Vector3(400, 50, 0);
            var x = rectTrans.DOAnchorPos3D(new Vector3(-50, 50, 0), 0.3f);
            cg.alpha = 0;
            var y = cg.DOFade(1, 1f);
        }


        /// <summary>
        /// 绑定事件
        /// </summary>
        public void Bind(Actor character) {
            this.character = character;
            CaptionText.text = character.name;
            MoveButton.onClick.AddListener(character.StartMove);
            
            FinishButton.onClick.AddListener(character.FinishTurn);

            //AttackButton.onClick.AddListener()

        }

        public void Clear() {

        }


    }
}
