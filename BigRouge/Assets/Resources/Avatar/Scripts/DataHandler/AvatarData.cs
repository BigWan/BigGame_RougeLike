using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


namespace BigRogue.Avatar {

    public struct AvatarRecord {
        public int id;
        public MountPointType mpt;
        public string path;

        public AvatarRecord(int id,MountPointType mpt, string path) {
            this.id = id;
            this.mpt = mpt;
            this.path = path;
        }
    }


    /// <summary>
    /// 一个AvatarData 实例表示一个Avatar中的内容
    /// </summary>
    public class AvatarData:IEnumerable<AvatarRecord> {

        // 文件中的记录
        public string dataFileName;

        // ID PATH
        //Dictionary<int, string> records;

        List<AvatarRecord> records;

        // 构造方法
        public AvatarData(string dataFileName,TextAsset text) {
            this.dataFileName = dataFileName;
            //records = new Dictionary<int, string>();
            records = new List<AvatarRecord>();
            ParseText(text);
        }

        public AvatarData(string dataFileName,string path) {
            this.dataFileName = dataFileName;
            //records = new Dictionary<int, string>();
            records = new List<AvatarRecord>();
            TextAsset text = Resources.Load<TextAsset>(path);
            if (text == null) throw new UnityException($"文件不存在{path}");
            ParseText(text);
        }

        /// <summary>
        /// 将配置文件转为字典
        /// </summary>
        private void ParseText(TextAsset text) {
            Regex regex = new Regex("\r\n");
            string[] lines = regex.Split(text.text);

            if(lines==null || lines.Length <= 0) return;
            string[] cells;
            string line;
            for (int i = 0,j = 0; i < lines.Length; i++) {
                line = lines[i];
                if (line.StartsWith("//")) continue;

                cells = lines[i].Split(',');
                
                if (cells == null || cells.Length < 2) continue;

                records.Add(new AvatarRecord( 
                    int.Parse(cells[0]), 
                    (MountPointType)(int.Parse(cells[1])), 
                    cells[1].Trim() 
                ));
                j++;
            }
        }



        /// <summary>
        /// 外部迭代方法
        /// </summary>
        /// <returns></returns>
        public IEnumerator<AvatarRecord> GetEnumerator() {
            foreach (var item in records) {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public AvatarRecord this[int key]{
            get { return records[key]; }
        }

        public int Count {
            get { return records.Count; }
        }
        



    }





}
