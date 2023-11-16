using System;
using Godot;
using Godot.Collections;
using Array = Godot.Collections.Array;

namespace RPGSystem;

public partial class GameEntry : Node
{
    // 单例------------------------------

    public static GameEntry Instance;

    public override void _EnterTree()
    {
        Instance = this;
    }

    // 单例------------------------------


    public override void _Ready()
    {
        LoadDatatable("res://src/datatable/attributes.txt");
        LoadDatatable("res://src/datatable/buffs.txt");

        /* 测试读表，输出 "string"
         TryGetData("attributes", 1, out var attr);
        GD.Print(attr["值类型"]);*/
    }


    // 数据表------------------------------
    private Dictionary<string, Array> datatables = new();
    
    /// <summary>
    /// 加载数据表。
    /// </summary>
    /// <param name="path">指定路径</param>
    public void LoadDatatable(string path)
    {
        var fileAccess = FileAccess.Open(path, FileAccess.ModeFlags.Read);
        // 第一行为表头
        var title = fileAccess.GetCsvLine();
        var array = new Array();
        while (!fileAccess.EofReached())
        {
            var dict = new Dictionary<string, Variant>();
            var line = fileAccess.GetCsvLine();
            for (var i = 0; i < line.Length; ++i)
            {
                var key = title[i];
                var property = line[i];
                dict.Add(key, property);
            }
            array.Add(dict);
        }

        var startIndex = path.LastIndexOf("/", StringComparison.Ordinal) + 1;
        var length = path.Length - startIndex - 4; // ".txt"
        var name = path.Substring(startIndex, length);
        datatables.Add(name, array);
    }


    public bool TryGetDatatable(string name, out Array table)
    {
        return datatables.TryGetValue(name, out table);
    }


    public bool TryGetData(string name, int index, out Dictionary<string, Variant> data)
    {
        if (datatables.TryGetValue(name, out var table) && index >= 0 && index < table.Count)
        {
            data = table[index].As<Dictionary<string, Variant>>();
            return true;
        }

        data = default;
        return false;

    }

    // 数据表------------------------------
    
}