using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    public Transform orbitedObect;
    public Transform orbitingObject;
    public Ellipse orbitPath;

    [Range(0f, 1f)]
    public float orbitProgress = 0f;
    public float orbitPeriod = 3f;

    public bool orbitActive = true;
    private float orbitSpeed = 0f;
    private float speedUpManip = 2f;
    private float speedDownManip = 0.5f;

    public float maxSpeed;
    public float minSpeed;
     
    void Start()
    {
        if (orbitingObject == null)
        {
            orbitActive = false;
            return;
        }
        SetOrbitingObectPosition();
        StartCoroutine(AnimateOrbit());
    }

    void SetOrbitingObectPosition()
    {
        Vector3 orbitedObject = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitedObject.x, 0, orbitedObject.y);
    }

    IEnumerator AnimateOrbit()
    {
        if (orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }
        orbitSpeed = 1f / orbitPeriod;
        while (orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            SetOrbitingObectPosition();
            yield return null;
        }
    }
   
    void Update()
    {
        //Debug.Log(orbitSpeed);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            speedDown();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            speedUp();
    }

    public void speedDown()
    {
        if(orbitSpeed >= minSpeed)
            orbitSpeed *= speedDownManip;
    }
    public void speedUp()
    {
        if(orbitSpeed <= maxSpeed)
            orbitSpeed *= speedUpManip;
    }
}
