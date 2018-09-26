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
                return charInfo.speed + 10;
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


        public BattleGround battleGround {
            get {
                return battleManager.battleGround;
            }
        }


        [Header("Refs")]
        public BattleManager battleManager;
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

        private void Start() {
            turnState = new OutofTurn(this); 
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

        public void DeductEnergy() {
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


        int turn;
        public bool allowMove;
        public bool allowAct;
        private TurnStateBase turnState;        // 回合状态

        public Action MoveOverHandler;

        public void ChangeTurnState(TurnStateBase newState) {
            turnState.Exit();
            turnState = newState;
            turnState.Enter();
        }
        

        bool turnFinished;

        //public TurnStateBase outofTurn;
        //public TurnStateBase turnWaitSelectAction;

        //public TurnStateBase decideMoveState;
        //public TurnStateBase movingState;

        //public TurnStateBase decideActState;
        //public TurnStateBase actingState;
        

        //void CreateState() {
        //    outofTurn = 
        //    turnWaitSelectAction = ;

        //    decideMoveState = new DecideMoveState(this, battleManager.battleGround);
        //    movingState = new MovingState(this);

        //    decideActState = new DecideActState(this);
        //    actingState = new ActingState(this);
        //}


        /// <summary>
        /// 进入回合
        /// </summary>
        /// <returns></returns>
        public IEnumerator ActiveTurn() {
            turnFinished = false;
            allowMove = true;
            allowAct = true;

            EnterTurnHandler?.Invoke(this);
            turn++;

            turnState = new WaitSelectActionState(this);

            while (turnFinished != true) {
                yield return null;
            }

            FinishedTurn();
        }


        void FinishedTurn() {

        }

        public string name2;
        private void Update() {
            name2=turnState.GetType().ToString();
        }

        public void GetFinishTurnCommand() { }

        public void StartMove(Vector3Int target) {
            StartCoroutine(MovingCoroutine(target));
        }

        public  IEnumerator MovingCoroutine(Vector3Int target) {
            

            while((transform.localPosition - target).magnitude>=0.1f) {
                transform.localPosition = Vector3.Lerp(transform.localPosition, target, 0.35f);
                 yield return null;
            }



            MoveOverHandler?.Invoke();
        }
        ///// <summary>
        ///// 获取可以移动到的Block
        ///// </summary>
        ///// <returns></returns>
        //public void ShowMovingArea() {
        //    battleManager.ShowMovingArea(coordinate, moveRange);
        //}

        //public void HideMovingArea() {
        //    battleManager.HideMovingArea();
        //}



        private void Select() {

        }

        private void Deselect() {

        }

        #endregion








    }
}