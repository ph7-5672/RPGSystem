extends BaseSystem
class_name BuffSystem

func _on_child_added(node: Node) -> void:
	var buff:Buff = node as Buff;
	if (!buff or !buff.entity):
		return;
	_init_buff(buff);

func _init_buff(buff: Buff) -> void:
	buff.set_meta("elapsed", buff.interval);
	var timer = get_tree().create_timer(buff.duration);
	await timer.timeout;
	_end_buff(buff);
	
func _execute_buff(buff: Buff) -> void:
	print(buff.buff_name + "触发");
	match buff.bonus.ComputeMode:
		StatBonus.ComputeMode.Add:
			buff.entity.stat_values[buff.bonus.stat] += buff.bonus.value;
		StatBonus.ComputeMode.Mul:
			buff.entity.stat_values[buff.bonus.stat] *= buff.bonus.value;

func _end_buff(buff: Buff) -> void:
	## buff结束
	print(buff.buff_name + "结束了");
	buff.queue_free();
	
func _process_child(node: Node, delta:float) -> void:
	var buff:Buff = node as Buff;
	if (!buff or !buff.entity):
		return;
	var elapsed:float = buff.get_meta("elapsed");
	if (elapsed >= buff.interval):
		_execute_buff(buff);
		elapsed = buff.interval - elapsed;
	buff.set_meta("elapsed", elapsed + delta);
