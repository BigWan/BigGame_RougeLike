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

        public AttributeInfo(
            int id,
            string name = "",
            string code= "",
            float min = 0,
            float max = 0,
            string desc = "") {

            this.id = id;
            this.name = name;
            this.code = code.ToUpper();
            this.min = min;
            this.max = max;
            this.desc = desc;
        }

        public static AttributeInfo empty { get { return new AttributeInfo(-1); } }

        void IRecord.InitFromLine(string s) {
            try {
                string[] cells = s.Split(',');
                int i = 0;
                id = int.Parse(cells[i]); i++;
                name = cells[i]; i++;
                code = cells[i]; i++;
                min = int.Parse(cells[i]); i++;
                max = int.Parse(cells[i]); i++;
                desc = cells[i]; i++;
            } catch(Exception) {
                throw new UnityEngine.UnityException("读取属性记录错误");
            }
        }


        bool IRecord.isEmpty() {
            return id == -1;            
        }
    }
}