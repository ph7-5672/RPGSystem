extends Node
class_name Game

static var entities:Node;
static var inventory_slots:Node;
static var effects:Node;
static var gears:Node;

static var buff_system:BuffSystem;
static var event_system:EventSystem;

func _enter_tree() -> void:
	entities = %Entities;
	inventory_slots = %InventorySlots;
	effects = %Effects;
	gears = %Gears;
	buff_system = %BuffSystem;
	event_system = %EventSystem;
