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
        private bool hasTurnEnd;

        private int turn;


        [Header("Refs")]
        private BattleManager battleManager;
        private Animator anim;

        private CombatState combatState;

        /// <summary>
        /// 开始回合
        /// </summary>
        /// <returns></returns>
        public override IEnumerator StartTurn() {

            TurnStartEventHandler?.Invoke(this);
            turn++;
            hasActed = false;
            hasMoved = false;
            hasTurnEnd = false;
            while (!hasTurnEnd) {
                yield return null;
            }

            UseEnergy();
            TurnEndEventHandler?.Invoke(this);
        }

        /// <summary>
        /// 移动操作
        /// </summary>
        public void MoveOperate() {




            StartCoroutine(MoveCoroutine());
        }

        public void ShowMoveRadius() {
            battleManager.ShowMoveRange(new Vector3Int(5, 0, 5), 3);
        }



        //private bool hasMoveCommand;
        //public IEnumerator GetMoveInput() {
        //    Debug.Log("等待移动操作");
        //    hasMoveCommand = false;
        //    while (!hasMoveCommand) {
        //        yield return null;
        //    }
        //    Debug.Log("得到移动操作");
        //}



        private bool hasAttackCommand;
        public IEnumerator GetAttackInput() {
            Debug.Log("等待攻击操作");
            hasAttackCommand = false;
            while (!hasAttackCommand) {
                yield return null;
            }
            Debug.Log("得到攻击操作");

        }



        protected  bool CanAct() {
            return true;
        }

        protected bool CanMoveTo(int x, int y) {
            return true;

        }


        public override void RegenEnergy() {
            energy += energyRegen;
        }

        public override void UseEnergy() {
            energy -= 1000;
        }

        public override bool IsEnergyEnough(float eng) {
            return energy >= eng;
        }



        protected  bool CanMove() {
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


        protected  IEnumerator AttackCoroutine() {
            yield return null;
        }


        protected  IEnumerator MoveCoroutine(int x = 0,int y = 0, int z = 0) {
            isMoving = true;
            Debug.Log($"{name}I'an Moving1");

            transform.SetLocalPositionX(Random.Range(1, 5));
            transform.SetLocalPositionZ(Random.Range(1, 5));
            yield return null;

            isMoving = false;
        }


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