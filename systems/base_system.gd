extends Node
class_name BaseSystem

func _enter_tree() -> void:
	child_entered_tree.connect(_on_child_added);

func _on_child_added(_node: Node) -> void:
	pass;

func _process(delta: float) -> void:
	var children = get_children();
	for node in children:
		_process_child(node, delta);

func _process_child(_node: Node, _delta:float) -> void:
	pass;
