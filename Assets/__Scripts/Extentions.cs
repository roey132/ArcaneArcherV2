using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void RemoveAllChildObjects(this GameObject parent)
    {
        int childCount = parent.transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            GameObject.DestroyImmediate(parent.transform.GetChild(i).gameObject);
        }
    }

}