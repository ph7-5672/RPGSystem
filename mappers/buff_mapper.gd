extends Node
class_name BuffMapper

var control: BuffControl;
@export var entity_id: int;
@export var buff_id: int;

func _ready() -> void:
	control = get_parent();

func query() -> void:
	Database.db.query("select * from buffs");
	print(Database.db.query_result);
