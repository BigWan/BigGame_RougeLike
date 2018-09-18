using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BigRogue.BattleSystem {


    public struct AttributeInfo : IRecord {

        public int id { get; set; }
        public string name;
        public string code;
        public float min;
        public float max;
        public string desc;

        void IRecord.InitFromLine(string s) {
            throw new NotImplementedException();
        }

        bool IRecord.isEmpty() {
            throw new NotImplementedException();
        }
    }
}