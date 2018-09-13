using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.AnimationSystem {



    /// <summary>
    /// 处理一些通用的Animation
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class EmoteAnimation : MonoBehaviour {

        private Animator m_animator;


        Coroutine stopEmoteCoroutine;

        void Awake() {
            m_animator = GetComponent<Animator>();
        }

        public void PlayEmote(int id) {
            m_animator.SetInteger("EmoteID", id);
            m_animator.SetBool("Emoting", true);
        }

        public void PlayEmoteSomeTime(int id,float time = 10f) {
            m_animator.SetInteger("EmoteID", id);
            m_animator.SetBool("Emoting", true);
            if (stopEmoteCoroutine != null)
                stopEmoteCoroutine = null;
            stopEmoteCoroutine = StartCoroutine(StopEmoteDelay(time));
        }


        IEnumerator StopEmoteDelay(float time) {
            yield return new WaitForSeconds(time);
            StopEmote();
        }

        void StopEmote() {
            m_animator.SetInteger("EmoteID", 0);
            m_animator.SetBool("Emoting", false);
        }


        private void OnGUI() {
            for (int i = 0; i < 9; i++) {
                if (GUI.Button(new Rect(30,30+50*i,100,50),$"播放{i.ToString()}号表情")) {
                    PlayEmote(i,10f);
                }
            }

            if(GUI.Button(new Rect(400, 100, 100, 50), "StopEmote")) {
                StopEmote();
            }
        }
    }
}