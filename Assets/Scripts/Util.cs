using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public static class Util
{
    public static Transform Find(Scene rootScene, string objName)
    {
        Transform t = null;
        if (rootScene.rootCount > 0)
        {
            GameObject[] gObjs = rootScene.GetRootGameObjects();
            for (int i = 0; i < gObjs.Length; i++)
            {
                if (gObjs[i].name.CompareTo(objName) == 0)
                {
                    t = gObjs[i].transform;
                    break;
                }
                else if(gObjs[i].transform.childCount > 0){
                    
                    t = FindChild(gObjs[i].transform,objName);
                }
            }
        }
        return t;
    }

    public static Transform FindChild(Transform root, string objName)
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
                    t = FindChild(child,objName);
                }
            }
        }
        return t;
    }


    public static Transform FindWithTag(Transform root, string objTag)
    {
        Transform t = null;
        if (root.childCount > 0)
        {
            for (int i = 0; i < root.childCount; i++)
            {
                Transform child = root.GetChild(i);
                if (child.CompareTag(objTag))
                {
                    t = child;
                    break;
                }
                if (child.childCount > 0)
                {
                    t = FindWithTag(child, objTag);
                }
            }
        }
        return t;
    }

    public static bool IsPointerUI()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        return EventSystem.current.IsPointerOverGameObject();
#else
        if (Input.touchCount > 0)
        {
            return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
        }
        else
        {
            return false;
        }
#endif
    }

    public static Vector3 Clamp(Vector3 v, Vector3 min, Vector3 max)
    {
        v.x = Mathf.Clamp(v.x, min.x, max.x);
        v.y = Mathf.Clamp(v.y, min.y, max.y);
        v.z = Mathf.Clamp(v.z, min.z, max.z);
        return v;
    }

    public static Vector2 Clamp(Vector2 v, Vector2 min, Vector2 max)
    {
        v.x = Mathf.Clamp(v.x, min.x, max.x);
        v.y = Mathf.Clamp(v.y, min.y, max.y);
        return v;
    }

}
