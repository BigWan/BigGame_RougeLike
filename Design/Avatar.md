# 角色换装

角色外观由若干个换装部件构成,

其中身体部件为必要部件`MainBody`,
身体部件上有挂点信息.


换装部件包括换装资源和资源挂点信息

## 部件信息

```cs
AvatarPart{
    ResID,
    MountPointType,
}
```

## 挂点类型

```cs
MountPointType{
    Base,
    Head,
    Back,
    Left,
    Right
}
```

部件资源存储在一张avatar的配置表中
