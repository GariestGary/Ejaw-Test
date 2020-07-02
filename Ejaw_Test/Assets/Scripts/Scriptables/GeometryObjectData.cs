using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Geometry Data", menuName = "ScriptableObjects/Geometry Object Data")]
public class GeometryObjectData : ScriptableObject
{
    public List<TypeData> GeometryData = new List<TypeData>();
}

[System.Serializable]
public struct TypeData
{
    public string ObjectType;
    public List<ClickColorData> ClickColors;
}

[System.Serializable]
public struct ClickColorData
{
    public int MinClicksCount;
    public int MaxClicksCount;
    public Color Color;
}
