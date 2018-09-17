using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRogue.BattleSystem {

    /// <summary>
    /// 可升级对象
    /// </summary>
    public interface ILevelup {

        int startLevel { get; }

        int level { get; }

        int maxLevel { get; }
        
        int nextLevelNeedExp(int nextLevel);

        /// <summary>
        /// 升级
        /// </summary>
        void Levelup();


        /// <summary>
        /// 升级到多少级(只能升级,退级无效果)
        /// </summary>
        /// <param name="level"></param>
        void LevelTo(int level);

        /// <summary>
        /// 获取经验值
        /// </summary>
        /// <param name="exp"></param>
        void GainExp(int exp);   

    }
}
