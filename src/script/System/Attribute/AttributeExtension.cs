namespace Game.System.Attribute;

public static partial class AttributeExtension
{
    /// <summary>
    /// 根据索引尝试获取属性值。
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="index"></param>
    /// <param name="attr"></param>
    /// <returns></returns>
    public static bool TryGetAttribute(this IAttributeOwner owner, int index, out IAttribute attr)
    {
        if (owner.Attributes != null && 
            owner.Attributes.Length <= index)
        {
            attr = owner.Attributes[index];
            return true;
        }

        attr = default;
        return false;
    }

    /// <summary>
    /// 修改对应索引的属性。
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="index"></param>
    /// <param name="attr"></param>
    public static void UpdateAttribute(this IAttributeOwner owner, int index, IAttribute attr)
    {
        owner.Attributes ??= new IAttribute[128];
        owner.Attributes[index] = attr;
    }




}