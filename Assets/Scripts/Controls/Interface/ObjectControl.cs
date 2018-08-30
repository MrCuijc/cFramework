using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有存在世界的控件基类
/// </summary>
public abstract class ObjectControl : IControl
{
    protected GameObject gameObject;
    protected Transform parent;
    /// <summary>
    /// 持久化Id，第一次创建后不再修改，需要跟数据库关联
    /// </summary>
    public string Id { get; set; }
    /// <summary>
    /// 随机id，每次创建都会重新赋值
    /// </summary>
    public string InstanceId { get; set; }
    /// <summary>
    /// 控件名字
    /// </summary>
    public string Name { get; private set; }

    //控制默认是否显示
    public bool DefaultEnable { get; set; }


    public GameObject GameObject
    {
        get
        {
            return gameObject;
        }
    }

    public Vector3 Position { get; set; }

    public Vector3 Angle { get; set; }

    public Vector3 Scale { get; set; }

    public virtual Transform Parent
    {
        get
        {
            return parent;
        }
        set
        {
            Vector3 pos = this.gameObject.transform.position;
            Vector3 angle = this.gameObject.transform.eulerAngles;
            Vector3 scale = this.gameObject.transform.localScale;
            this.gameObject.transform.parent = value;
            this.gameObject.transform.position = pos;
            this.gameObject.transform.eulerAngles = angle;
            this.gameObject.transform.localScale = scale;
        }
    }


    public ObjectControl()
    {
        this.Name = GetType().Name;
        this.DefaultEnable = true;
    }
    /// <summary>
    /// 在Unity的Awake之后，Start之前调用一次
    /// </summary>
    /// <param name="go"></param>
    public virtual void Create(GameObject go)
    {
        this.gameObject = go;
        this.gameObject.SetActive(DefaultEnable);
    }
    /// <summary>
    /// 在Unity的Destroy之前调用一次
    /// </summary>
    /// <param name="go"></param>
    public virtual void Dispose()
    {
    }

    public virtual void Show()
    {
        try
        {
            gameObject.SetActive(true);
        }
        catch
        {
            if(gameObject == null)
                throw new System.Exception("game is null");
        }
    }

    public virtual void Hide()
    {
        try
        {
            gameObject.SetActive(false);
        }
        catch
        {
            if (gameObject == null)
                throw new System.Exception("game is null");
        }
    }


    public Transform FindChild(string name)
    {
        return FindChild(this.gameObject.transform,name);
    }

    public Transform FindChild(Transform root, string objName)
    {
        Transform t = null;
        if (root.childCount > 0)
        {
            for (int i = 0; i < root.childCount; i++)
            {
                Transform child = root.GetChild(i);
                if (child.name.CompareTo(objName) == 0)
                {
                    t = child;
                    break;
                }
                if (child.childCount > 0)
                {
                    t = FindChild(child, objName);
                }
            }
        }
        return t;
    }

}
