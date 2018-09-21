using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BigRogue.BattleSystem;
using DG.Tweening;


namespace BigRogue.GameUI {

    /// <summary>
    /// 游戏中在单位身上点出来的菜单
    /// //常见功能有 移动 攻击 待机
    /// </summary>
    public class HeadBar : MonoBehaviour {

        public Image  HeadImage;
        public Text NameText;

        private Character character;

        CanvasGroup cg ;
        RectTransform rectTrans;

        private void Awake() {
            cg = GetComponent<CanvasGroup>();
            rectTrans = GetComponent<RectTransform>();
        }

        public void SetCharacter(Character character) {
            this.character = character;
            NameText.text = character.name;
        }

        public void FadeIn() {
            rectTrans.anchoredPosition3D = new Vector3(-700, 0, 0);
            var x = rectTrans.DOAnchorPos3D(new Vector3(0, 0, 0), 0.3f);
            cg.alpha = 0;
            var y = cg.DOFade(1, 1f);
        }

    }
}
