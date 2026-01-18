extends Node


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	Game.event_system.subscribe_event("test", event_test);

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	var value = randf();
	Game.event_system.raise_event("test", "Hello world!", value);
	if (value > 0.5):
		Game.event_system.unsubscribe_event("test", event_test);

func event_test(info, value):
	print(info, value);
