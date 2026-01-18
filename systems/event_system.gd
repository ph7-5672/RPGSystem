extends BaseSystem
class_name EventSystem

# 订阅事件
func subscribe_event(event_name: String, callable: Callable, oneshot: bool = false) -> void:
	var handler = EventHandler.new();
	handler.event_name = event_name;
	handler.callable = callable;
	handler.oneshot = oneshot;
	add_child(handler);

# 取消订阅事件
func unsubscribe_event(event_name: String, callable: Callable) -> void:
	var children = get_children();
	for node in children:
		var handler = node as EventHandler;
		if (handler and handler.event_name == event_name and handler.callable == callable):
			handler.queue_free();

# 发送事件
func raise_event(event_name: String, ...event_args: Array) -> void:
	var children = get_children();
	for node in children:
		var handler = node as EventHandler;
		if (handler and handler.event_name == event_name):
			var callable = handler.callable;
			for i in range(event_args.size()):
				var index = event_args.size() - 1 - i;
				var arg = event_args[index];
				callable = callable.bind(arg);
			callable.call_deferred();
