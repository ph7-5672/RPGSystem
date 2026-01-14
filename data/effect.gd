extends BaseData
class_name Effect

## buff效果/属性值加成

enum ComputeMode #加成计算方式
{
	Add, #加算
	Sub, #减算
	Mul, #乘算
}

@export var icon:String; #图标
@export_multiline var desc:String; #描述
@export var stat:Entity.Stat; #属性名
@export var mode:ComputeMode; #计算方式。
@export var interval:float; #触发间隔(秒)
