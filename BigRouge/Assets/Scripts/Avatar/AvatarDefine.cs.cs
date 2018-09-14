
namespace BigRogue.CharacterAvatar {

    /// <summary>
    /// 换装的孔位
    /// </summary>
    public enum AvatarSlot {
        MainBody = 0,
        Beard = 1,
        Ears = 2,
        Hair = 3,
        Face = 4,
        Horns = 5,
        Wing = 6,
        Bag = 7,
        MainHand = 101,
        OffHand = 102
    }

    /// <summary>
    /// Avatar的部件类型,除了武器,部件类型的孔位是固定的
    /// </summary>
    public enum AvatarPartType {
        MainBody = 0,
        Beard = 1,
        Ears = 2,
        Hair = 3,
        Face = 4,
        Horns = 5,
        Wing = 6,
        Bag = 7,
        Weapon = 100
    }

    /// <summary>
    /// Avatar部件的挂载类型
    /// </summary>
    public enum MountingType {
        None = -1,
        Root = 0,
        Base = 1,
        Head = 2,
        Back = 3,
        LeftHand = 4,
        RightHand = 5,
        BothHand = 6,
    }

    /// <summary>
    /// 挂点位置枚举
    /// </summary>
    public enum MountingPoint {
        Root, Base, Head, Back, Left, Right
    }

    /// <summary>
    /// 性别类型
    /// </summary>
    public enum SexType {
        None = 0,
        Female = 1,
        Male = 2,
        Other = 3,
    }
}