using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRogue.BattleSystem {
    /// <summary>
    /// 可以被伤害
    /// </summary>
    interface IDamageAble {

        void TakeHit();

        void OnTakeDamage();

    }


}
