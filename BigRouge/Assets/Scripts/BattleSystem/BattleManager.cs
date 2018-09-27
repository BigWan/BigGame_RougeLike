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


        [Header("UI Refs")]
        public GameUI.OperateMenu opMenu;
        public GameUI.HeadBar info;


        /// <summary>
        /// 战斗场景内所有的Actor对象
        /// </summary>
        public List<Actor> chars;
        /// <summary>
        /// 满足act条件的actor
        /// </summary>
        public List<Actor> charQueue;
        /// <summary>
        /// 当前行动的对象
        /// </summary>
        public Actor currentChar;
        /// <summary>
        /// 当前选中的对象
        /// </summary>
        public Entity selectedEntity;


        public BattleState battleState;

        public BattleGround battleGround;

        static int energyToAct;


        /// <summary>
        /// 进入谁的回合
        /// </summary>
        public Action<Actor> EnterTurnHandler;

        public Action<Actor> EndTurnHandler;


        private void Awake() {
            Init();
        }


        void Init() {

            // 初始化对象
            chars = new List<Actor>();
            charQueue = new List<Actor>();

            // 获取配置
            energyToAct = int.Parse(GameSetting.GetSetting("ENERGY_TO_ACT"));

            // 获取对象
            chars = FindObjectsOfType<Actor>().ToList();
            opMenu = FindObjectOfType<OperateMenu>();
            info = FindObjectOfType<HeadBar>();
            battleGround = FindObjectOfType<BattleGround>();


            //// 监听事件
            //foreach (var @char in chars) {
            //    @char.EnterTurnHandler += OnSelectActor;
            //}

        }


        public void Start() {
            
        }

        public void Load() {

        }

        public void Tick() {

            if (CheckBattleOver()) {
                BattleOver();
            }
            charQueue.Clear();

            for (int i = 0; i < chars.Count; i++) {
                chars[i].RegenEnergy();
                if (chars[i].IsEnergyEnough(energyToAct)) {
                    charQueue.Add(chars[i]);
                }
            }
            charQueue = charQueue.OrderBy(x => -x.energy).ToList();

            if (charQueue.Count > 0) {
                battleState = BattleState.Acting;
                StartCoroutine(ActiveTurn());
            }

        }


        /// <summary>
        /// 激活单位的回合
        /// </summary>
        IEnumerator ActiveTurn() {
            
            for (int i = 0; i < charQueue.Count; i++) {
                currentChar = charQueue[i];
                EnterTurnHandler?.Invoke(currentChar);
                yield return StartCoroutine(currentChar.ActiveTurn());
            }
            currentChar = null;
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
        /// 显示移动格子
        /// </summary>
        /// <param name="center"></param>
        /// <param name="range"></param>
        public void ShowMovingArea(Vector3Int center,int range) {
            battleGround.ShowMovingArea(center, range,2);
        }

        /// <summary>
        /// 关闭移动格子显示
        /// </summary>
        public void HideMovingArea() {
            battleGround.HideMovingArea();
        }


        public void AddActor(Actor a) { }

        public void RemoveActor(Actor a) { }

        public void HasActor(Actor a) { }

        //public void OnSelectActor(Actor actor) {
        //    ShowOperateMenu((Actor)actor);
        //}

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


        


    }
}
