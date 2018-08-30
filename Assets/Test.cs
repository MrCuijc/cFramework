using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public Transform _2dRoot;
    public Transform _3dRoot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IControl control = null;

    private void OnGUI()
    {
        if (GUILayout.Button("CreateUIMessage"))
        {

            control = ControlResources.CreateControl<UIPlane>();
            control.Parent = _2dRoot;

            UIMessageBox box = ControlResources.CreateControl<UIMessageBox>();
            box.DefaultEnable = false;

            UIBagControl bag = ControlResources.CreateControl<UIBagControl>();
           
            if (control is UIPlane)
            {
                UIPlane plane = control as UIPlane;
                plane.AddControl(box);
                plane.AddControl(bag);
            }

            //control.Show();
        }

        if (GUILayout.Button("Show"))
        {
            if (control != null)
            {
                control.Show();
            }
        }
        if (GUILayout.Button("Hide"))
        {
            if (control != null)
                control.Hide();
        }
        if (GUILayout.Button("Dispose"))
        {
            ControlResources.Destroy(control);
            control = null;
        }

    }
}
