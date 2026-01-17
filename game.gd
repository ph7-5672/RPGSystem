extends Node
class_name Game

static var entities:Node;
static var inventory_slots:Node;
static var effects:Node;
static var gears:Node;
static var buff_system:BuffSystem;

func _enter_tree() -> void:
	entities = %Entities;
	inventory_slots = %InventorySlots;
	effects = %Effects;
	gears = %Gears;
	buff_system = %BuffSystem;

# 创建实体
static func create_entity() -> Entity:
	var entity = Entity.new();
	entities.add_child(entity);
	return entity;

# 创建格子
static func create_slot() -> InventorySlot:
	var slot = InventorySlot.new();
	inventory_slots.add_child(slot);
	return slot;

# 为实体添加buff
static func add_buff(entity: Entity, buff: Buff) -> void:
	buff.entity = entity;
	buff_system.add_child(buff);
