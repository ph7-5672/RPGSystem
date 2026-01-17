extends BaseData
class_name Buff

## buff配置数据。

@export var entity:Entity; #绑定实体
@export var effect:Effect; #buff效果
@export var value:float; #加成值
@export var duration:float; #持续时间(秒)
@export var total_elapsed:float; #已经过时间
@export var executed_elapsed:float; #执行的冷却时间
