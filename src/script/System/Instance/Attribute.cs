using Game.System.Attribute;
using Godot;

namespace Game.System.Instance;

public struct Attribute : IAttribute
{
    public string Name { get; set; }
    public Variant Value { get; set; }
}