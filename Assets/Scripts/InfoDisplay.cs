using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    public Text descText;
    public Image image;
    public CameraMovement camMovement;
    private PlanetInfo currInfo;
    public PlanetInfo[] infoArray;

    void Update()
    {
            for (int i = 0; i < 10; i++)
            {
                if (infoArray[i].name == camMovement.currPlanet.name)
                {
                    currInfo = infoArray[i];
                }
            }
        descText.text = currInfo.description;
        image.sprite = currInfo.image;
    }
}
