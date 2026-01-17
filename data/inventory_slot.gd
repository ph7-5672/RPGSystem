extends BaseData
class_name InventorySlot

@export var entity:Entity; #所属实体
@export var inventory_name:String; #所属仓库名称
@export var item_type:ItemType; #支持的物品类型
@export var item:Item; #物品id
@export var count:int; #数量

enum ItemType
{
	None = 0,
	Gear = 1 << 0, #装备
	Consumable = 1 << 1, #消耗品
	Material = 1 << 2, #材料
	Misc = 1 << 3, #杂项
}
