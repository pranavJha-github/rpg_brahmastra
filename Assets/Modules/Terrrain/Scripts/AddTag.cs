/*
using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
public class AddTag
{
    // Start is called before the first frame update
    public enum TagType { Tag = 0, Layer = 1 }

    static public int Initialize(GameObject gameObject)
    {
        int terrainLayer = -1;
        SerializedObject tagManager = new SerializedObject(
                      AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);

        SerializedProperty tagsProp = tagManager.FindProperty("tags");
        Add_Tag(tagsProp, "Terrain", TagType.Tag);
        Add_Tag(tagsProp, "Cloud", TagType.Tag);
        Add_Tag(tagsProp, "Shore", TagType.Tag);
        tagManager.ApplyModifiedProperties();

        SerializedProperty layerProp = tagManager.FindProperty("layers");
        terrainLayer = Add_Tag(layerProp, "Terrain", TagType.Layer);
        tagManager.ApplyModifiedProperties();

        //take this object
        gameObject.tag = "Terrain";
        gameObject.layer = terrainLayer;
        return terrainLayer;

    }
    static public int Add_Tag(SerializedProperty tagsProp, string newTag, TagType tType)
    {
        bool found = false;
        //ensure the tag doesn't already exist
        for (int i = 0; i < tagsProp.arraySize; i++)
        {
            SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
            if (t.stringValue.Equals(newTag)) { found = true; return i; }
        }
        //add your new tag
        if (!found && tType == TagType.Tag)
        {
            tagsProp.InsertArrayElementAtIndex(0);
            SerializedProperty newTagProp = tagsProp.GetArrayElementAtIndex(0);
            newTagProp.stringValue = newTag;
        }
        //add new layer
        else if (!found && tType == TagType.Layer)
        {
            for (int j = 8; j < tagsProp.arraySize; j++)
            {
                SerializedProperty newLayer = tagsProp.GetArrayElementAtIndex(j);
                //add layer in next empty slot
                if (newLayer.stringValue == "")
                {
                    newLayer.stringValue = newTag;
                    return j;
                }
            }
        }
        return -1;
    }
}

*/
