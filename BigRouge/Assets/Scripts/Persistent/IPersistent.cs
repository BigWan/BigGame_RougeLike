using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Persistent {

    public interface IPersistentable {
        void SaveData();
        void ReadData();
        //string SaveData();

    }

}


