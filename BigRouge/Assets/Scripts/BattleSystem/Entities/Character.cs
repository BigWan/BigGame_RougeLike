using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BigRogue.BattleSystem {


    /// <summary>
    /// 角色对象,能穿装备,拥有技能,能战斗
    /// </summary>
    public class Character : Actor {

        private bool isMoving;
        private bool isAttacking;

        private int turn;

        private CombatState combatState;

        private TakeDamageComponent takeDamageComponent;

        /// <summary>
        /// 行动
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Act() {
            turn++;
            Debug.Log($"{name}开始行动");
            useEnergy();
            yield return StartCoroutine(MoveCoroutine());
            yield return StartCoroutine(AttackCoroutine());
            Debug.Log($"{name}行动结束");
        }

        IEnumerator MoveCoroutine() {
            isMoving = true;
            Debug.Log($"{name}I'an Moving1");
            yield return new WaitForSeconds(1f);

            isMoving = false;
        }


        IEnumerator AttackCoroutine() {
            isAttacking = true;
            Debug.Log("I'an attacking1");
            yield return new WaitForSeconds(1f);
            isAttacking = false;
        }


        public override bool CanAct() {
            throw new System.NotImplementedException();
        }

        public override bool CanMoveTo(int x, int y) {
            throw new System.NotImplementedException();
        }

        public override void Move(int x, int y, bool force = false) {
            throw new System.NotImplementedException();
        }

        public override void RegenEnergy() {
            energy += energyRegen;
        }

        public override void useEnergy() {
            energy -= 1000;
        }


    }
}