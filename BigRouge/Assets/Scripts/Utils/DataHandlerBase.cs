using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigRogue.Util {
    /// <summary>
    /// 数据管理基类
    /// </summary>
    public abstract class DataHandlerBase<T> {

        public abstract T GetRecord(int id);


    }
}
