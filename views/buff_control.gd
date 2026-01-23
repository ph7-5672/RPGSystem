@tool
extends Control
class_name BuffControl

## 如何绑定实体数据
## 用子节点配置数据库表的id

@export var buff_name:String;
@export var icon:String;
@export var desc:String;

var _progress:float = 0;
@export_range(0.0, 1.0, 0.1) var progress:float:
	get:
		return _progress;
	set(value):
		_progress = clamp(value, 0, 1);
		_update_mask(_progress);

func _ready() -> void:
	tooltip_text = desc;
	
func _update_mask(value: float) -> void:
	if (!has_node("MaskPanel")):
		return;
	$MaskPanel.size.y = size.y * value;
	$MaskPanel.queue_redraw();
	
