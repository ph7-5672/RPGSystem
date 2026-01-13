extends BaseData
class_name Entity

## 实体数据

enum Stat #属性名
{
	HealthPoint, #血量
	HealthMaximum, #血量上限
	MagicPoint, #蓝量
	MagicMaximum, #蓝量上限
	AttackPower, #攻击力
	Defense, #防御力
	CriticalHitRate, #暴击率
}

var stat_values:Dictionary[Entity.Stat, Variant] = {};
