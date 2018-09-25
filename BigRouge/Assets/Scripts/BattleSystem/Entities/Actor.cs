using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
using BigRogue.Persistent;

namespace BigRogue.BattleSystem {


    /// <summary>
    /// 角色
    /// </summary>
    public class Actor : Entity {

        /// <summary>
        /// 配置表记录ID
        /// </summary>
        public int charInfoID;

        [SerializeField]
        /// <summary>
        /// 角色基础信息
        /// </summary>
        private Persistent.CharacterRecord charInfo;

        

        [Header("Energy")]
        public float energy;
        public float energyRegen {
            get {
                return charInfo.speed  + 10;
            }
        }

        public int moveRange {
            get {
                return charInfo.moveRange;
            }
        }

        public int attackRange {
            get {
                return charInfo.attackRange;
            }
        }




        [Header("Refs")]
        private BattleManager battleManager;
        private CombatState combatState;

        [Header("Event")]


        /// <summary>
        /// 角色进入回合
        /// </summary>
        public Action<Actor> EnterTurnHandler; 
        /// <summary>
        /// 角色结束回合
        /// </summary>
        public Action<Actor> FinishTurnHandler;

        /// <summary>
        /// 
        /// </summary>
        protected Action<Actor> ActStartEventHandler;
        protected Action<Actor> ActEndEventHandler;

        /// <summary>
        /// 角色开始移动
        /// </summary>
        public Action<Actor> MoveStartEventHandler;
        /// <summary>
        /// 角色移动完毕
        /// </summary>
        public Action<Actor> MoveEndEventHandler;


        // MonoBehaviour Message

        private void Awake() {
            battleManager = FindObjectOfType<BattleManager>();
            GetCharInfo();
        }





        
        /// <summary>
        /// 获取配置表数据
        /// </summary>
        void GetCharInfo() {
            charInfo = CharacterInfoHandler.GetRecord(charInfoID);
            if (charInfo.isEmpty()) {
                throw new UnityException($"配置信息错误{charInfoID}");
            }
        }


        #region "能量相关"

        public void RegenEnergy() {
            energy += energyRegen;
        }

        public void UseEnergy() {
            energy -= 1000;
        }

        public bool IsEnergyEnough(float eng) {
            return energy >= eng;
        }

        #endregion


        #region "Check Funcs"

        protected bool CanAct() {
            return true;
        }

        protected bool CanMoveTo(int x, int y) {
            return true;

        }
        protected bool CanMove() {
            return true;
        }

        protected bool CanAttack() {
            return true;
        }

        protected bool CanShoot() {
            return true;
        }

        protected bool CanCastSpell() {
            return true;
        }

        #endregion


        #region "Avatar相关"
        // some
        #endregion


        #region "状态机相关"


        enum TurnState {
            OutSide,   // 没有进入回合
            WaitForInput,  // 等待输入
            DecideMove,    // 移动输入操作
            Moving,         // 移动
            DecideAct,      // 行动输入
            Acting,          // 行动
            TurnFinish,     // 回合结束
        }


        //private bool isMoving;
        //private bool isActing;

        //private bool hasMoved;
        //private bool hasActed;
        //private bool isTurnFinished;

        private int turn;
        TurnState turnState;        // 回合状态
        [Header("Co")]
        Coroutine moveProcessCoroutineHandler;
        Coroutine actProcessCoroutineHandler;

        /// <summary>
        /// 进入回合
        /// </summary>
        /// <returns></returns>
        public IEnumerator ActiveTurn() {
            turnState = TurnState.WaitForInput;
            EnterTurnHandler?.Invoke(this);
            turn++;


            while (turnState!=TurnState.TurnFinish) {
                yield return null;
            }
        }






        protected IEnumerator ActProcessCoroutine() {
            yield return null;
        }


        public void StartMove() {
            Debug.Log("StartMove",transform);
            moveProcessCoroutineHandler = StartCoroutine(MoveProcessCoroutine());
        }

        public void StartAct() {
            Debug.Log("Move");
            actProcessCoroutineHandler = StartCoroutine(ActProcessCoroutine());
        }

        public void StartUseItem() { }
        public void StartAttack() { }
        public void StartCastSpell() { }


        public void FinishTurn() {
            isTurnFinished = true;
        }

        protected IEnumerator MoveProcessCoroutine(int x = 0, int y = 0, int z = 0) {
            // 选取坐标
            yield return StartCoroutine(GetMoveTargetCoroutine());
            // 移动到目的地
            yield return StartCoroutine(MoveToTargetCoroutine());
            isMoving = true;
            Debug.Log($"{name}I'an Moving1");


            isMoving = false;
        }

        /// <summary>
        /// 获取移动输入
        /// 移动到哪个格子
        /// </summary>
        /// <returns></returns>
        Vector3Int moveTarget;
        IEnumerator GetMoveTargetCoroutine() {

            ShowMoveArea();

            yield return new WaitUntil(() => moveTarget != Vector3Int.zero);

            HideMoveArea();
        }


        IEnumerator MoveToTargetCoroutine() {
            yield return null;
        }


        public void EndTurn() {
            UseEnergy();
            isTurnFinished = true;
            FinishTurnHandler?.Invoke(this);
        }

        /// <summary>
        /// 显示移动的格子
        /// </summary>
        void ShowMoveArea() {
            Debug.Log("显示格子");
            battleManager.ShowMoveRange(coordinate, moveRange);
        }

        /// <summary>
        /// 隐藏移动的格子
        /// </summary>
        void HideMoveArea() {
            battleManager.HideMoveRange();
        }

        void OnTurn() {

        }

        //private void OnMouseDown() {
        //    TurnStartEventHandler?.Invoke(this);
        //}



        private void Select() {

        }

        private void Deselect() {

        }

        #endregion








    }
}