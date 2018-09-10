using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigRogue.Avatar {
    /// <summary>
    /// 部件信息
    /// </summary>
    public struct AvatarPartRecord {

        public static AvatarPartRecord empty = new AvatarPartRecord(-1,"","");


        /// <summary>
        /// 部件ID
        /// </summary>
        public int id;
        /// <summary>
        /// 部件的AvatarPartTypeRecord类型
        /// </summary>
        public string avatarPartTypeName;
        /// <summary>
        /// 部件美术路径
        /// </summary>
        public string path;

        public AvatarPartRecord(int id = -1,string avatarPartTypeName = "", string path = "") {
            this.id = id;
            this.path = path;
            this.avatarPartTypeName = avatarPartTypeName;
        }

        
    }

    /// <summary>
    /// 负责读取数据表
    /// 部件类型表(部件类型名字和部件挂点类型)
    /// 部件表(部件id,部件类型,部件资源)
    /// </summary>
    public static class AvatarDataHandler {

        const string avatarPartTypeFileName = "Avatar/Texts/AvatarPartType";
        const string avatarPartFileName     = "Avatar/Texts/AvatarPart";

        const string avatarResFolder = "Avatar/AvatarParts/";

        /// <summary>
        /// AvatarPartTypeRecord 的数据库
        /// key = 部件类型名称
        /// value = 资源的挂点类型
        /// </summary>
        static Dictionary<string, MountingType> avatarPartTypeDataSheet;

        /// <summary>
        /// avatar 的部件ID 表
        /// key 部件ID
        /// value 部件记录
        /// </summary>
        static Dictionary<int, AvatarPartRecord> avatarPartDataSheet;

        public static int Count {
            get {
                return avatarPartDataSheet.Count;
            }
        }

        static AvatarDataHandler() {
            avatarPartTypeDataSheet = new Dictionary<string, MountingType>();
            avatarPartDataSheet = new Dictionary<int, AvatarPartRecord>();

            LoadAvatarPartType();
            LoadAvatarPart();
        }

        /// <summary>
        /// 载入类型描述文件
        /// </summary>
        static void LoadAvatarPartType() {

            string[] lines = Util.SimpleCsv.OpenCsv(avatarPartTypeFileName);

            string[] cells;
            for (int i = 0; i < lines.Length; i++) {
                try {

                    cells = lines[i].Split(',');
                    if (cells == null || cells.Length < 2) continue;
                    avatarPartTypeDataSheet.Add(
                        cells[0],
                        (MountingType)System.Enum.Parse(typeof(MountingType), cells[1])
                        );

                } catch (System.Exception) {

                    throw;
                }
               
            }
        }

        // 载入部件信息表
        static void LoadAvatarPart() {
            string[] lines = Util.SimpleCsv.OpenCsv(avatarPartFileName);
            string[] cells;

            for (int i = 0; i < lines.Length; i++) {
                try {
                    cells = lines[i].Split(',');
                    AvatarPartRecord apr = new AvatarPartRecord(
                    int.Parse(cells[0]), cells[1], avatarResFolder+cells[2]
                    );

                    avatarPartDataSheet.Add(apr.id, apr);
                } catch (System.Exception) {

                    throw;
                }
                
            }

        }


        // API
        /// <summary>
        /// 根据部件类型名查询部件的挂点信息
        /// </summary>
        /// <param name="avatarPartName">部件的名称信息</param>
        /// <returns>挂载类型</returns>
        public static MountingType GetMountingType(string avatarPartName) {
            return avatarPartTypeDataSheet[avatarPartName];
        }

        /// <summary>
        /// 获取Apr
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AvatarPartRecord GetAvatarPartRecord(int id) {
            if (avatarPartDataSheet.ContainsKey(id))
                return avatarPartDataSheet[id];
            else
                return AvatarPartRecord.empty;
        }

    }

}