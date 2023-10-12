using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new text", menuName = "PlanetInformation")]
public class PlanetInfo : ScriptableObject
{
    public string description;
    public Sprite image;
}
