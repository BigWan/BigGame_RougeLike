using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BigRogue.Persistent {

    public static class CharacterInfoHandler {

        static string path = "Texts/Character";

        static Dictionary<int, CharacterRecord> s_data;

        static CharacterInfoHandler() {
            s_data = new Dictionary<int, CharacterRecord>();
            s_data = Util.SimpleCsv.OpenCsvAs<CharacterRecord>(path);
        }

        public static CharacterRecord GetRecord(int id) {
            if (s_data.ContainsKey(id))
                return s_data[id];
            else
                return CharacterRecord.empty;
        }


    }
}
