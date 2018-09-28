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
        private Animator m_animator;

        [Header("Event")]


        /// <summary>
        /// 角色进入回合
        /// </summary>
        public Action<Actor> EnterTurnHandler;
        /// <summary>
        /// 角色结束回合
        /// </summary>
        public Action<Actor> FinishTurnHandler;

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
            m_animator = GetComponentInChildren<Animator>();
            //turnState = new IdleState(); 
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


        #region "Check Flags"

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

        public bool turnFinished;

        /// <summary>
        /// 进入回合
        /// </summary>
        /// <returns></returns>
        public IEnumerator ActiveTurn() {
            Debug.Log($"name{name}进入回合");
            turnFinished = false;
            allowMove = true;
            allowAct = true;

            EnterTurnHandler?.Invoke(this);
            turn++;

            turnState = new PrepareState(this);

            while (turnFinished != true) {
                yield return null;
            }

            FinishedTurn();
        }


        void FinishedTurn() {
            Debug.Log("Im done");
            turnState = null;
            energy -= 1000f;
        }

        public void GetFinishTurnCommand() { }

        public void StartMove(Vector3Int target) {
            StartCoroutine(MovingCoroutine(target));
        }

        public void StartMove(List<PathFinding.PathNode> blocks) {
            StartCoroutine(MovingCoroutine(blocks));
        }

        /// <summary>
        /// Lerp 到一个坐标
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public IEnumerator MovingCoroutine(Vector3Int target) {

            while((transform.localPosition - target).magnitude >= 0.1f) {
                transform.localPosition = Vector3.Lerp(transform.localPosition, target, 0.35f);
                 yield return null;
            }
            transform.localPosition = target;
            coordinate3D = target;

            MoveOverHandler?.Invoke();
        }

        /// <summary>
        /// 一个一个的移动
        /// </summary>
        /// <param name="blocks"></param>
        /// <returns></returns>
        public IEnumerator MovingCoroutine(List<PathFinding.PathNode> blocks) {
            for (int i = blocks.Count-1; i >=0 ; i--) {
                transform.localPosition = blocks[i].position;
                yield return new WaitForSeconds(0.1f);
            }
            transform.localPosition = blocks[0].position;
            coordinate3D = blocks[0].coordinate3D;
            MoveOverHandler?.Invoke();
        }


        private void Select() {

        }

        private void Deselect() {

        }

        #endregion


    }
}