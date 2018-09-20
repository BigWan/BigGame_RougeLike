using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BigRogue.BattleSystem;

namespace BigRogue.GameUI {

    /// <summary>
    /// 游戏中在单位身上点出来的菜单
    /// //常见功能有 移动 攻击 待机
    /// </summary>
    public class OperateMenu : MonoBehaviour {

        public Text CaptionText;
        public Button MoveButton;
        public Button AttackButton;
        public Button EndButton;

        private Character character;


        private void Awake() {
            
        }


        public void SetCharacter(Character character) {
            this.character = character;
            CaptionText.text = character.name;
        }

        Coroutine fadeinCo;
        public void FadeIn() {
            if (fadeinCo != null)
                fadeinCo = null;
            fadeinCo = StartCoroutine(FadeInCoroutine());
        }

        IEnumerator FadeInCoroutine() {
            CanvasGroup cg = GetComponent<CanvasGroup>();
            cg.alpha = 0;
            while (cg.alpha < 0.99F) {
                cg.alpha +=0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            cg.alpha = 1;
        }
    }
}
