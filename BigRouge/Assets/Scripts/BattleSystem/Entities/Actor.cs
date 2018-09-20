using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


namespace BigRogue.BattleSystem {

    /// <summary>
    /// 角色抽象类
    /// </summary>
    public abstract class Actor : Entity {

        // 一系列事件

        protected Action StartActEventHandler;
        protected Action EndActEventHandler;

        // 一系列判断

        protected abstract bool CanAct();

        // 一系列操作

        public abstract IEnumerator ActCoroutine();

    }
}
