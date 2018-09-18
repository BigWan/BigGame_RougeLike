using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 战斗状态
    /// </summary>
    public enum BattleState {
        //Start,      // 开始状态
        WaitingInput,  // 等待操作
        Ticking,        // 自循环中
        Acting,     // 执行操作
        BattleOver,
    }


    /// <summary>
    /// 战斗管理器,从进入场景到结束战斗
    /// </summary>
    public class BattleManager : MonoBehaviour {

        /// <summary>
        /// 需要处理的有能量的Entity
        /// </summary>
        public List<Actor> actors;

        /// <summary>
        /// 满足act条件的actor
        /// </summary>
        public Queue<Actor> actorQueue;

        public BattleState battleState;

        const float energyToAct = 100;

        private void Awake() {
            //actors = new List<Actor>();
            actorQueue = new Queue<Actor>();
        }


        public void Start() {
            
        }

        public void Load() {

        }

        public void Tick() {

            if (CheckBattleOver()) {
                BattleOver();
            }

            for (int i = 0; i < actors.Count; i++) {
                actors[i].RegenEnergy();
                if (actors[i].energy > energyToAct) {
                    actorQueue.Enqueue(actors[i]);
                }
            }

            if (actorQueue.Count > 0) {
                battleState = BattleState.Acting;
                StartCoroutine(ActActors());
            }

        }

        /// <summary>
        /// 让可以行动的单位行动
        /// </summary>
        IEnumerator ActActors() {

            while (actorQueue.Count==0) {
                yield return StartCoroutine(actorQueue.Dequeue().Act());
            }


        }


        public void BattleOver() {

        }

        bool CheckBattleOver() {
            return true;
        }

        private void FixedUpdate() {
            switch (battleState) {
                case BattleState.Ticking:
                    Tick();
                    break;
                case BattleState.Acting:                    
                    break;
                case BattleState.BattleOver:
                    break;
                default:
                    break;
            }
        }



        public void AddActor(Actor a) { }

        public void RemoveActor(Actor a) { }

        public void HasActor(Actor a) { }

    }
}
