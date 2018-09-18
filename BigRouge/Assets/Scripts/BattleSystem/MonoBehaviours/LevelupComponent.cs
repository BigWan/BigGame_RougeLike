using System;
using UnityEngine;
namespace BigRogue.BattleSystem {

    /// <summary>
    /// 经验值升级组件
    /// </summary>
    public class LevelupComponent : MonoBehaviour {

        public Action<int> LevelupEventHandler;

        public Action<int> GainExpEventHandler;

        public int startLevel;

        int level;

        int exp;

        int maxLevel;

        /// <summary>
        /// 下一次升级需要的经验
        /// </summary>
        /// <returns></returns>
        int getLevelupExp(int level) {
             return 100 * (level + 1); 
        }

        /// <summary>
        /// 升级
        /// </summary>
        void Levelup() {
            exp -= getLevelupExp(level);
            level++;
            LevelupEventHandler?.Invoke(level);
        }

        /// <summary>
        /// 升级到多少级(只能升级,退级无效果)
        /// </summary>
        /// <param name="lvl"></param>
        void LevelTo(int lvl) {
            while (level < lvl) {
                Levelup();
            }
            exp = 0;
        }

        /// <summary>
        /// 获取经验值
        /// </summary>
        /// <param name="exp">得到的经验值</param>
        void GainExp(int gainedExp) {
            exp += gainedExp;
            GainExpEventHandler?.Invoke(exp);
            if (exp >= getLevelupExp(level))
                Levelup();
        }


    }
}
