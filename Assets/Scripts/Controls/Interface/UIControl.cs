using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 所有UI控件的基类
/// </summary>
public abstract class UIControl : ObjectControl {

    protected RectTransform rectTrans;

    public Vector2 Size {
        get {
            return rectTrans.sizeDelta;
        }
    }
    public int Depth { get; set; }

    public RectTransform RectTransform {
        get {
            return rectTrans;
        }
        set {
            rectTrans = value;
        }
    }

    public override Transform Parent
    {
        get
        {
            return parent;
        }
        set
        {
            //记录
            Debug.Log("get rect trans " + rectTrans);
            Vector2 pos = rectTrans.anchoredPosition;
            Vector2 size = rectTrans.sizeDelta;
            Vector3 angle = this.gameObject.transform.eulerAngles;
            Vector3 scale = this.gameObject.transform.localScale;
            //设置
            this.gameObject.transform.parent = value;
            //复原
            this.rectTrans.anchoredPosition = pos;
            this.gameObject.transform.eulerAngles = angle;
            this.gameObject.transform.localScale = scale;
            this.rectTrans.sizeDelta = size;
        }
    }

    public override void Create(GameObject go)
    {
        base.Create(go);
        rectTrans = go.GetComponent<RectTransform>();
    }
}
