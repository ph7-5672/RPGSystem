extends Node

func _process(delta: float) -> void:
	var children = get_children();
		
	pass;


func _on_child_added(node: Node) -> void:
	var buff:Buff = node as Buff;
	if (buff):
		_init_buff(buff);

func _init_buff(buff: Buff) -> void:
	_execute_buff(buff);
	if (buff.duration == 0):
		_end_buff(buff);
		return;
	
	var tree = get_tree();
	var duration_timer = tree.create_timer(buff.duration);
	if (buff.duration <= buff.interval):
		await duration_timer.timeout;
		_end_buff(buff);
		return;
	
	var interval_timer = tree.create_timer(buff.interval);
	while(duration_timer.time_left > 0):
		await interval_timer.timeout;
		## buff触发
		_execute_buff(buff);
	await duration_timer.timeout;
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
