using Godot;

namespace Game.System.Attribute;

public struct Attribute : IAttribute
{
    public string Name { get; set; }
    public Variant Value { get; set; }
}