using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {

    public enum AvatarPartType {
        Body  = 1,
        Beard = 2,
        Ears  = 3,
        Hari  = 4,
        Horn  = 5
    }

    public enum SexType {
        Both = 0,
        Female = 1,
        Male = 2
    }



	/// <summary>
	/// 负责读取数据表
	/// </summary>
	public static class AvatarDataUtil   {

		public static string m_meshFolder = "Avatar/Arts/Fbx/";

		public static string m_matFolder = "Avatar/Arts/Material/";

		public static string m_configPath;




        public static BodyAvatar GetAvatarPartBody(int id) {
     
            return Resources.Load<BodyAvatar>("Avatar/AvatarParts/Bodys/AvatarPartBodyNormal");

        }

	}


    public class AvatarMeshRecord {

    }

    public class AvatarMaterialRecord {
        public int id;
        public string name;
 
    }
    
    public static class AvatarMaterialJson{

        public static string rootPath = "Avatar/Arts/Material/";

        [SerializeField]
		public static List<AvatarMaterialRecord> materialRecords;




        public static void ReadFromText(TextAsset text) {

        }

    }

}