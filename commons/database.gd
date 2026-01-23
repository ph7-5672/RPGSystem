extends Node
class_name Database

const DB_PATH = "user://database.db";

static var db: SQLite;

func _enter_tree() -> void:
	db = SQLite.new();
	db.path = DB_PATH;
	db.open_db();
	
func _exit_tree() -> void:
	db.close_db();
