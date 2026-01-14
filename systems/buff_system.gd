extends BaseSystem
class_name BuffSystem

func _on_child_added(node: Node) -> void:
	var buff:Buff = node as Buff;
	if (!buff or !buff.entity):
		return;
	_init_buff(buff);

func _init_buff(buff: Buff) -> void:
	buff.set_meta("elapsed", buff.effect.interval);
	var timer = get_tree().create_timer(buff.duration);
	await timer.timeout;
	_end_buff(buff);
	
func _execute_buff(buff: Buff) -> void:
	print(buff.effect.name + "触发");
	match buff.effect.ComputeMode:
		Effect.ComputeMode.Add:
			buff.entity.stat_values[buff.effect.stat] += buff.effect.value;
		Effect.ComputeMode.Mul:
			buff.entity.stat_values[buff.effect.stat] *= buff.effect.value;

func _end_buff(buff: Buff) -> void:
	## buff结束
	print(buff.effect.name + "结束了");
	buff.queue_free();
	
func _process_child(node: Node, delta :float) -> void:
	var buff:Buff = node as Buff;
	if (!buff or !buff.entity):
		return;
	var elapsed:float = buff.get_meta("elapsed") + delta;
	if (elapsed >= buff.effect.interval):
		_execute_buff(buff);
		elapsed = elapsed - buff.effect.interval;
	buff.set_meta("elapsed", elapsed);
