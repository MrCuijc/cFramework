using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控件资源管理
/// </summary>
public class ControlResources
{
    static List<ObjectControl> list = new List<ObjectControl>();

    public static T CreateControl<T>() where T : ObjectControl,new()
    {
        GameObject go = GameObject.Instantiate(Resources.Load(typeof(T).Name)) as GameObject;
        T t = new T();
        t.Create(go);
        list.Add(t);
        return t;
    }

    public static void Destroy(IControl control)
    {
        ObjectControl objControl = control as ObjectControl;
        objControl.Dispose();
        GameObject.Destroy(objControl.GameObject);
        list.Remove(objControl);
    }

    public static T Find<T>(string name) where T : ObjectControl
    {
        return list.Find(control=>control.Name == name) as T;
    }

 
}
