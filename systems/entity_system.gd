extends BaseSystem
class_name EntitySystem

#func _process(delta: float) -> void:
#	var children = get_children();
#	for child in children:
#		var entity:Entity = child as Entity;
#		if (entity):
#			_process_entity(entity, delta);

func _on_child_added(node: Node) -> void:
	var entity:Entity = node as Entity;
	if (!entity):
		return;
	_init_entity(entity);

func _init_entity(_entity:Entity) -> void:
	pass;

func _process_entity(_entity: Entity, _delta: float) -> void:
	pass;
