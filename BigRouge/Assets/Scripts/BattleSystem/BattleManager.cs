using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 战斗状态
    /// </summary>
    public enum BattleState {
        //Start,        // 开始状态
        WaitingInput,   // 等待操作
        Ticking,        // 自循环中
        Acting,         // 执行操作
        BattleOver,
    }


    /// <summary>
    /// 战斗管理器,从进入场景到结束战斗
    /// </summary>
    public class BattleManager : MonoBehaviour {


        [Header("Refs")]
        public GameUI.OperateMenu opMenu;

        /// <summary>
        /// 需要处理的有能量的Entity
        /// </summary>
        public List<Actor> actors;

        /// <summary>
        /// 满足act条件的actor
        /// </summary>
        public Queue<Actor> actorQueue;

        public BattleState battleState;

        static int energyToAct;

        private void Awake() {
            // 初始化对象
            actorQueue = new Queue<Actor>();

            // 获取配置
            energyToAct = int.Parse(GameSetting.GetSetting("ENERGY_TO_ACT"));

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
                if (actors[i].isEnergyEnough(energyToAct)) {
                    actorQueue.Enqueue(actors[i]);
                }
            }

            if (actorQueue.Count > 0) {
                battleState = BattleState.Acting;
                StartCoroutine(ActAll());
            }

        }


        /// <summary>
        /// 让可以行动的单位行动
        /// </summary>
        IEnumerator ActAll() {
            Debug.Log(actorQueue.Count);
            while (actorQueue.Count > 0) {
                yield return StartCoroutine(actorQueue.Dequeue().ActCoroutine());
            }
            // act end
            battleState = BattleState.Ticking;
        }


        public void BattleOver() {

        }

        bool CheckBattleOver() {
            return false;
        }

        private  void FixedUpdate() {
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



        public void Update() {

            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("M0");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitinfo;
                if (Physics.Raycast(ray, out hitinfo)) {
                    Debug.Log(hitinfo.transform.name);
                    if (hitinfo.transform.CompareTag("Character")) {
                        Debug.Log("sHOW");
                        ShowOperateMenu(hitinfo.transform.GetComponent<Character>());
                    }
                }
            }

        }


        void ShowOperateMenu(Character c) {
            opMenu.gameObject.SetActive(true);
            opMenu.SetCharacter(c);
            opMenu.FadeIn();
        }


    }
}
