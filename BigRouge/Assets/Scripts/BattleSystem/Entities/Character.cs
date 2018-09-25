using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace BigRogue.BattleSystem {


    /// <summary>
    /// 角色对象,能穿装备,拥有技能,能战斗
    /// </summary>
    public class Character : Actor {

        public int left;

        public int avatarID;

        [Header("flags")]
        private bool isMoving;
        private bool isActing;

        private bool hasMoved;
        private bool hasActed;
        private bool turnEnd;

        private int turn;


        [Header("Refs")]
        private BattleManager battleManager;
        private Animator anim;

        private CombatState combatState;


        Coroutine moveProcessCoroutineHandler;
        Coroutine actProcessCoroutineHandler;
        /// <summary>
        /// 进入回合
        /// </summary>
        /// <returns></returns>
        public override IEnumerator ActiveTurn() {

            TurnStartEventHandler?.Invoke(this);
            turn++;
            hasActed = false;
            hasMoved = false;
            turnEnd = false;
            // 移动 
            moveProcessCoroutineHandler = StartCoroutine(MoveProcessCoroutine());
            // 行动
            actProcessCoroutineHandler = StartCoroutine(ActProcessCoroutine());

            while (!turnEnd) {
                yield return null;
            }

            if (moveProcessCoroutineHandler != null) {
                StopCoroutine(moveProcessCoroutineHandler);
                moveProcessCoroutineHandler = null;
            }

            if(actProcessCoroutineHandler != null) {
                StopCoroutine(actProcessCoroutineHandler);
                actProcessCoroutineHandler = null;
            }
        }


        protected IEnumerator ActProcessCoroutine() {
            yield return null;
        }


        protected IEnumerator MoveProcessCoroutine(int x = 0, int y = 0, int z = 0) {

            yield return StartCoroutine(GetMoveTargetCoroutine());
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

            ShowMoveAbleBlock();
            yield return new WaitUntil(()=>moveTarget!=Vector3Int.zero);

            
        }


        IEnumerator MoveToTargetCoroutine() {
            yield return null;
        }


        public void EndTurn() {
            UseEnergy();
            turnEnd = true;
            TurnEndEventHandler?.Invoke(this);
        }

        /// <summary>
        /// 显示移动的格子
        /// </summary>
        void ShowMoveAbleBlock() {
            battleManager.ShowMoveRange(new Vector3Int(5, 0, 5), 3);
        }

        /// <summary>
        /// 隐藏移动的格子
        /// </summary>
        void HideMoveAbleBlock() {

        }






        #region "能量相关"

        public override void RegenEnergy() {
            energy += energyRegen;
        }

        public override void UseEnergy() {
            energy -= 1000;
        }

        public override bool IsEnergyEnough(float eng) {
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

        protected  bool CanAttack() {
            return true;
        }

        protected  bool CanShoot() {
            return true;
        }

        protected  bool CanCastSpell() {
            return true;
        }

        #endregion



        void OnTurn() {

        }
        
        private void OnMouseDown() {
            TurnStartEventHandler?.Invoke(this);
        }
        


        private void OnSelected() {

        }

        private void LoseSelected() {

        }


        private void Start() {
            battleManager = FindObjectOfType<BattleManager>();
        }



    }
}