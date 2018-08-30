using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthControl : ObjectControl
{
    CubeRotate rotate;

    public EarthControl()
    {
    }

    public override void Dispose()
    {
    }

    public override void Show()
    {
        base.Show();
        rotate.IsCanRotate = true;
    }

    public override void Hide()
    {
        base.Hide();
        rotate.IsCanRotate = false;
    }

    public override void Create(GameObject go)
    {
        base.Create(go);
        rotate = this.gameObject.GetComponent<CubeRotate>();
    }
}
