using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 投射物体的接口
    /// </summary>
    interface IProjectAble {

        // 发射子弹(发射即击中)
        void Project(object o,int x,int y);

        // 发射实体子弹(不是马上击中的类型)
        void ProjectTile(object o,int x,int y,Func<int> onHit);

        bool CanProject(object o, int x, int y);

    }
}
