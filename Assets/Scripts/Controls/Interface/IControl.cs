

using UnityEngine;

public interface IControl
{
    string Name { get; }

    GameObject GameObject { get; }
    Transform Parent { get; set; }

    //显示的时候调用一次
    void Show();
    //隐藏的时候调用一次
    void Hide();
}
