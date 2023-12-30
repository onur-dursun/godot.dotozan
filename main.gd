extends Control

var click_pos = Vector2i.ZERO
func _ready():
	#var pool = PackedVector2Array([Vector2(0,0), Vector2(1,0), Vector2(0,1)])
	#get_viewport().get_window().mouse_passthrough = true
	get_tree().get_root().set_transparent_background(true)

