using Godot;

namespace Game.System.Attribute;

public interface IAttribute
{
    string Name { get; set; }

    Variant Value { get; set; }
    
}