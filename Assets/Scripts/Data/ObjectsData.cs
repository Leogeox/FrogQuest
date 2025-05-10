using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using static UnityEngine.Rendering.DebugUI;
using System.Drawing;

[Serializable]
public struct ObjectsData
{
    public string label;
    public int value;
    public Sprite sprite;

    public ObjectsData(string label, int value, Sprite sprite)
    {
        this.label = label;
        this.value = value;
        this.sprite = sprite;
    }
}


