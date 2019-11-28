using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ListGenerator
{
    public static void AddFieldsToList(GameObject container, List<GameObject> fields)
    {
        foreach (var i in fields)
        {
            GameObject el = AddElementToContainer(i, container);
        }
    }

    public static GameObject AddElementToContainer(GameObject element, GameObject con)
    {
        GameObject gg = UnityEngine.Object.Instantiate(element);
        gg.transform.SetParent(con.transform);
        return gg;
    }
}