using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRogue.BattleSystem {

    public interface IMeleeAttack {

        void Attack();
        void OnAttack();
    }
}
