using System;
using Godot;
using Godot.Collections;
using Array = Godot.Collections.Array;

namespace RPGSystem;

public partial class GameEntry : Node
{
    // 单例------------------------------begin

    public static GameEntry Instance;

    public override void _EnterTree()
    {
        Instance = this;
    }

    // 单例--------------------------------end


    public override void _Ready()
    {

        EnterStage += s =>
        {
            if (string.Equals("Preload", s))
            {
                LoadDatatable("res://src/datatable/attributes.txt");
                LoadDatatable("res://src/datatable/buffs.txt");
            }
        };

        ChangeStage("Preload");
        

        /* 测试读表，输出 "string"
         TryGetData("attributes", 1, out var attr);
        GD.Print(attr["值类型"]);*/
        
        
        
    }
    
    
    


    // 数据表------------------------------begin
    private Dictionary<string, Array> datatables = new();
    
    /// <summary>
    /// 加载数据表。
    /// </summary>
    /// <param name="path">指定路径</param>
    public void LoadDatatable(string path)
    {
        GD.Print($"Loading Datatable {path} ...");
        
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
        
        GD.PrintRich($"[color=green]Loaded Datatable {path}.[/color]");
    }

    /// <summary>
    /// 获取数据表。
    /// </summary>
    /// <param name="name">文件名（无后缀）</param>
    /// <param name="table">返回数据表</param>
    /// <returns>是否成功</returns>
    public bool TryGetDatatable(string name, out Array table)
    {
        return datatables.TryGetValue(name, out table);
    }


    /// <summary>
    /// 获取配表数据。
    /// </summary>
    /// <param name="name">文件名（无后缀）</param>
    /// <param name="index">数据索引（所在行）</param>
    /// <param name="data">返回数据</param>
    /// <returns>是否成功</returns>
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

    // 数据表--------------------------------end
    
    
    // 阶段-------------------------------begin
    public Action<string> EnterStage = delegate{};
    public Action<string> LeaveStage = delegate{};

    /// <summary>
    /// 当前阶段。初始化为Preload。
    /// </summary>
    public string CurrentStage { get; private set; } = "Start";

    /// <summary>
    /// 切换阶段。
    /// 触发上个阶段的离开和下个阶段的进入事件。
    /// </summary>
    /// <param name="stage"></param>
    public void ChangeStage(string stage)
    {
        // 必须切换不同阶段。
        if (string.Equals(stage, CurrentStage))
        {
            return;
        }

        LeaveStage(CurrentStage);
        EnterStage(stage);
        CurrentStage = stage;
    }

    // 阶段---------------------------------end
}