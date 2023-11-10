
namespace Game.System.Attribute;

public interface IAttributeOwner
{
    /// <summary>
    /// 属性数组。
    /// </summary>
    IAttribute[] Attributes { get; set; }
}