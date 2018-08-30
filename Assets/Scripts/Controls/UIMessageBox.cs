using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMessageBox : UIControl
{
    private Button okBtn;
    private Button cancleBtn;
    private Text titleText;
    private Text contentText;

    private string msg = null;
    private string title = null;


    public string Title
    {
        get {
            return title;
        }
        set {
            title = value;
            if (titleText != null)
                titleText.text = title;
        }
    }

    public string Message
    {
        get {
            return msg;
        }
        set {
            msg = value;
            if (contentText != null)
                contentText.text = msg;
        }
    }


    public override void Create(GameObject go)
    {
        base.Create(go);

        titleText = FindChild("TextTitle").GetComponent<Text>();
        contentText = FindChild("TextContent").GetComponent<Text>();
        okBtn = FindChild("OKBtn").GetComponent<Button>();
        cancleBtn = FindChild("CancleBtn").GetComponent<Button>();
        Debug.Log("game " + gameObject + " create");

        okBtn.onClick.AddListener(OnOKClick);
        cancleBtn.onClick.AddListener(OnCancleClick);
    }

    public override void Dispose()
    {
        Debug.Log("game " + gameObject + " dispose");
        okBtn.onClick.RemoveListener(OnOKClick);
        cancleBtn.onClick.RemoveListener(OnCancleClick);
    }

   


    void OnOKClick()
    {
        Debug.Log("game " + gameObject + "  ok");
        Hide();
    }

    void OnCancleClick()
    {
        Debug.Log("game " + gameObject + "  cancle");
        Hide();
    }

    public override void Show()
    {
        base.Show();
        Debug.Log("game " + gameObject + "  show");
        this.gameObject.transform.SetAsLastSibling();

    }

    public override void Hide()
    {
        base.Hide();
        Debug.Log("game " + gameObject + "  hide");
    }

   
}
