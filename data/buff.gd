extends BaseData
class_name Buff

## buff配置数据。

@export var entity:Entity; #绑定实体
@export var buff_name:String; #名称
@export var icon:String; #图标
@export var desc:String; #描述
@export var bonus:StatBonus; #属性值加成
@export var duration:float; #持续时间(秒)
@export var interval:float; #触发间隔(秒)
