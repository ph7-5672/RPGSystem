extends Node
class_name Game

static var entity_system:EntitySystem;
static var buff_system:BuffSystem;

func _enter_tree() -> void:
	buff_system = %BuffSystem;
	entity_system = %EntitySystem;

# 为实体添加buff
static func add_buff(entity:Entity, buff:Buff) -> void:
	buff.entity = entity;
	buff_system.add_child(buff);
