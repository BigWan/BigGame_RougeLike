using UnityEngine;
using System.Collections;

namespace BigRogue.BattleSystem {


    /// <summary>
    /// 角色对象,
    /// </summary>
    public class Character : Actor {

        private CombatState statGroup;

        private TakeDamageComponent takeDamageComponent;



        public override bool Act() {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public override void useEnergy() {
            throw new System.NotImplementedException();
        }
    }
}