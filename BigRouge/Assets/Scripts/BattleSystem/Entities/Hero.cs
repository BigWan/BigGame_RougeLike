using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BigRogue.BattleSystem {


    /// <summary>
    /// 角色对象,
    /// </summary>
    public class Hero : Actor {

        private CombatState statGroup;

        private TakeDamageComponent takeDamageComponent;


        /// <summary>
        /// 行动
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Act() {
            
            yield return StartCoroutine(MoveCoroutine());
            yield return StartCoroutine(AttackCoroutine());
        }


        

        /// <summary>
        /// 移动
        /// </summary>
        /// <returns></returns>
        IEnumerator MoveCoroutine() {
            Debug.Log("I'an Moving1");
            yield return null;
            Debug.Log("I'an Moving2");
            yield return null;
            Debug.Log("I'an Moving3");
            yield return null;
            Debug.Log("I'an Moving4");
            yield return null;
            Debug.Log("I'an Moving5");
            yield return null;

        }


        IEnumerator AttackCoroutine() {
            Debug.Log("I'an attacking1");
            yield return null;
            Debug.Log("I'an attacking2");
            yield return null;
            Debug.Log("I'an attacking3");
            yield return null;
            Debug.Log("I'an attacking4");
            yield return null;
            Debug.Log("I'an attacking5");
            yield return null;
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
            energy += 10;
        }

        public override void useEnergy() {
            energy -= 10;
        }
    }
}