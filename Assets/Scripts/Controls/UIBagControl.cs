using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBagControl : UIControl
{

    private Button closeBtn;
    private Button item1Btn;
    private Button item2Btn;

    private UIMessageBox msg;

    public UIBagControl()
    {
    }

    public override void Create(GameObject go)
    {
        base.Create(go);
        closeBtn = FindChild(go.transform, "CloseBtn").GetComponent<Button>();
        item1Btn = FindChild(go.transform, "Item1Btn").GetComponent<Button>();
        item2Btn = FindChild(go.transform, "Item2Btn").GetComponent<Button>();

        //控件之间不应该调用的，应该在Plane层调用
        msg = ControlResources.Find<UIMessageBox>("UIMessageBox");

        closeBtn.onClick.AddListener(Close);
        item1Btn.onClick.AddListener(OnItem1);
        item2Btn.onClick.AddListener(OnItem2);
    }

    public override void Dispose()
    {
        base.Dispose();
        closeBtn.onClick.RemoveListener(Close);
        item1Btn.onClick.RemoveListener(OnItem1);
        item2Btn.onClick.RemoveListener(OnItem2);
    }


    void OnItem1()
    {
        msg.Title = "物体a";
        msg.Message = "武器谢谢谢谢谢谢谢谢谢";
        msg.Show();
    }
    void OnItem2()
    {
        msg.Title = "物体b";
        msg.Message = "衣服谢谢谢谢谢谢谢谢谢";
        msg.Show();
    }

    void Close()
    {
        Hide();
    }
}
