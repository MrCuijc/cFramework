using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 页面
/// </summary>
public class UIPlane : UIControl {

    List<UIControl> list = new List<UIControl>();


    public override void Create(GameObject go)
    {
        base.Create(go);

    }

    public override void Dispose()
    {
        base.Dispose();
    }

    public override void Show()
    {
        base.Show();
        foreach (var control in list)
        {
            if(control.DefaultEnable)
                control.Show();
        }
    }

    public override void Hide()
    {
        base.Hide();
        foreach (var control in list)
        {
            if (control.DefaultEnable)
                control.Hide();
        }
    }

    public void AddControl(UIControl control)
    {
        control.Parent = this.gameObject.transform;
        list.Add(control);
    }


}
