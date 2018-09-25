using UnityEngine;
using System.Collections;
using System;

namespace BigRogue.Persistent {
    [Serializable]
    public struct CharacterRecord : IRecord {

        public int id { get; set; }
        public string name;
        public int avatarID;
        public int race;
        public int moveRange;
        public int attackRange;
        public int level;
        /// <summary>
        /// 图表ID,一个能升级的东西需要对应的一个图表ID;
        /// 图表记录这ID和对应的值
        /// </summary>
        public int chartID;

        public float speed;
        // 初始属性
        public float atk;
        public float hp;
        public float def;
        public float str;
        public float @int;
        public float dex;

        public static CharacterRecord empty {
            get {
                CharacterRecord r = new CharacterRecord();
                r.id = -1;
                return r;
            }
        }

        public bool isEmpty() {
            return id == -1;
        }

        public void InitFromLine(string s) {
            try {
                string[] cells = s.Split(',');
                int i = 0;
                id = int.Parse(cells[i]); i++;
                name = cells[i]; i++;
                avatarID = int.Parse(cells[i]); i++;
                race = int.Parse(cells[i]); i++;
                moveRange = int.Parse(cells[i]); i++;
                attackRange = int.Parse(cells[i]); i++;
                level = int.Parse(cells[i]); i++;
                chartID = int.Parse(cells[i]); i++;
                speed = float.Parse(cells[i]); i++;
                atk = float.Parse(cells[i]); i++;
                hp = float.Parse(cells[i]); i++;
                def = float.Parse(cells[i]); i++;
                str = float.Parse(cells[i]); i++;
                @int = float.Parse(cells[i]); i++;
                dex = float.Parse(cells[i]); i++;

            } catch (Exception) {

                throw new UnityException($"解析数据行错误:{s}");
            }
        }

    }
}
