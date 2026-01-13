extends Resource
class_name StatBonus

## 属性值加成

enum ComputeMode #加成计算方式
{
	Add, #加算
	Mul, #乘算
}

@export var stat:Entity.Stat; #属性名
@export var value:float; #加成值
@export var mode:ComputeMode; #计算方式。
