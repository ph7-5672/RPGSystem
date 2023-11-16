using Game.System.Attribute;
using Game.System.Buff;
using Godot;

public partial class Test : Node2D, IBuffOwner
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BuffExtension.BuffTick += (owner, buff) =>
		{
			if (owner is IAttributeOwner attributeOwner)
			{
				
			}

		};
		this.AddBuff(0);
		this.AddBuff(1, 1000, 5000);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.BuffProcess(delta);
	}

	public IBuff[] Buffs { get; set; }
}
