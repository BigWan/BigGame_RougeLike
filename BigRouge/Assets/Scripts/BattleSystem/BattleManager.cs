using System;
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

        public BattleState battleState;

        const float energyToAct = 1000;

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
                    actors[i].Act();
                }
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



        public void AddEntity(Entity e) { }

        public void RemoveEntity(Entity e) { }

        public void HasEntity(Entity e) { }

    }
}
