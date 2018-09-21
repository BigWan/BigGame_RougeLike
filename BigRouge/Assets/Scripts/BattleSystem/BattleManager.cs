using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BigRogue.GameUI;

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
        public GameUI.HeadBar info;


        /// <summary>
        /// 战斗场景内所有的Actor对象
        /// </summary>
        public List<Actor> actors;
        /// <summary>
        /// 满足act条件的actor
        /// </summary>
        public List<Actor> actorQueue;
        /// <summary>
        /// 当前行动的对象
        /// </summary>
        public Actor currentActor;
        /// <summary>
        /// 当前选中的对象
        /// </summary>
        public Entity selectedEntity;

        public BattleState battleState;

        public BattleGround bg;

        static int energyToAct;

        private void Awake() {
            Init();
        }


        void Init() {

            // 初始化对象
            actors = new List<Actor>();
            actorQueue = new List<Actor>();

            // 获取配置
            energyToAct = int.Parse(GameSetting.GetSetting("ENERGY_TO_ACT"));

            // 获取对象
            actors = FindObjectsOfType<Actor>().ToList();
            opMenu = FindObjectOfType<OperateMenu>();
            info = FindObjectOfType<HeadBar>();
            bg = FindObjectOfType<BattleGround>();


            // 监听事件
            foreach (var item in actors) {
                item.TurnStartEventHandler += OnSelectActor;
            }

        }


        public void Start() {
            
        }

        public void Load() {

        }

        public void Tick() {

            if (CheckBattleOver()) {
                BattleOver();
            }
            actorQueue.Clear();

            for (int i = 0; i < actors.Count; i++) {
                actors[i].RegenEnergy();
                if (actors[i].IsEnergyEnough(energyToAct)) {
                    actorQueue.Add(actors[i]);
                }
            }
            actorQueue = actorQueue.OrderBy(x => -x.energy).ToList();

            if (actorQueue.Count > 0) {
                battleState = BattleState.Acting;
                StartCoroutine(StartTurn());
            }

        }


        /// <summary>
        /// 让可以行动的单位行动
        /// </summary>
        IEnumerator StartTurn() {
            Debug.Log(actorQueue.Count);
            //while (actorQueue.Count > 0) {
            //    yield return StartCoroutine(actorQueue.Dequeue().ActCoroutine());
            //}

            for (int i = 0; i < actorQueue.Count; i++) {
                currentActor = actorQueue[i];
                yield return StartCoroutine(currentActor.StartTurn());
            }
            currentActor = null;
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

        /// <summary>
        /// 显示场景区域
        /// </summary>
        /// <param name="center"></param>
        /// <param name="range"></param>
        public void ShowMoveRange(Vector3Int center,int range) {
            bg.HighlightArea(center, range, BlockHightLightType.Normal);
        }

        public void HideRange() {

        }


        public void AddActor(Actor a) { }

        public void RemoveActor(Actor a) { }

        public void HasActor(Actor a) { }

        public void OnSelectActor(Actor actor) {
            ShowOperateMenu((Character)actor);
        }

        //public void Update() {

        //    if (Input.GetMouseButtonDown(0)) {
        //        Debug.Log("M0");
        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        RaycastHit hitinfo;
        //        if (Physics.Raycast(ray, out hitinfo)) {
        //            Debug.Log(hitinfo.transform.name);
        //            if (hitinfo.transform.CompareTag("Character")) {
        //                Debug.Log("sHOW");
        //                ShowOperateMenu(hitinfo.transform.GetComponent<Character>());
        //            }
        //        }
        //    }

        //}


        public void ShowOperateMenu(Character c) {
            opMenu.gameObject.SetActive(true);
            opMenu.SetCharacter(c);
            opMenu.FadeIn();


            info.gameObject.SetActive(true);
            info.SetCharacter(c);
            info.FadeIn();
        }


    }
}
