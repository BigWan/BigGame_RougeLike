using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace BigRogue.BattleSystem {


    /// <summary>
    /// 角色对象,能穿装备,拥有技能,能战斗
    /// </summary>
    public class Character : Actor {

        public int left;


        public float energy;
        public float energyRegen;

        private bool isMoving;
        private bool isAttacking;

        private int turn;

        private Animator anim;

        private CombatState combatState;

        /// <summary>
        /// 行动
        /// </summary>
        /// <returns></returns>
        public override IEnumerator ActCoroutine() {
            turn++;
            Debug.Log($"{name}开始行动");

            yield return StartCoroutine(GetMoveInput());
            yield return StartCoroutine(MoveCoroutine());

            yield return StartCoroutine(GetAttackInput());
            yield return StartCoroutine(AttackCoroutine());

            useEnergy();
            Debug.Log($"{name}行动结束===");
        }


        private bool hasMoveCommand;
        public IEnumerator GetMoveInput() {
            Debug.Log("等待移动操作");
            hasMoveCommand = false;
            while (!hasMoveCommand) {
                yield return null;
            }
            Debug.Log("得到移动操作");
        }



        private bool hasAttackCommand;
        public IEnumerator GetAttackInput() {
            Debug.Log("等待攻击操作");
            hasAttackCommand = false;
            while (!hasAttackCommand) {
                yield return null;
            }
            Debug.Log("得到攻击操作");

        }



        protected override bool CanAct() {
            return true;
        }

        protected bool CanMoveTo(int x, int y) {
            return true;

        }


        public void RegenEnergy() {
            energy += energyRegen;
        }

        protected void useEnergy() {
            energy -= 1000;
        }

        public bool isEnergyEnough(int eng) {
            return energy >= eng;
        }



        protected void OnGUI() {
            if (GUI.Button(new Rect(left , 100, 200, 50), $"{name}移动操作")) {
                hasMoveCommand = true;
            }
            if (GUI.Button(new Rect(left , 200, 200, 50), $"{name}攻击操作")) {
                hasAttackCommand = true;
            }
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

    }
}