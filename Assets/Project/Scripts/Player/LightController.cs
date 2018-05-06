using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LightRange
{
    public float MinRange;
    public float MaxRange;
    public Color FirstColor;
    public Color SecondColor;
    public float MinIntensity;
    public float MaxIntensity;
}

[RequireComponent(typeof(Light))]
public class LightController : MonoBehaviour {
    public LightRange Ranges;

    [SerializeField]
    float timeBetweenChange;

    Light MyLight;
    float timer = 0;

    private void Start()
    {
        MyLight = GetComponent<Light>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenChange)
        {
            timer = 0;
            if (MyLight.type == LightType.Spot)
            {
                MyLight.spotAngle = Random.Range(Ranges.MinRange, Ranges.MaxRange);
            }else if(MyLight.type == LightType.Point)
            {
                MyLight.range = Random.Range(Ranges.MinRange, Ranges.MaxRange);
            }
            MyLight.intensity = Random.Range(Ranges.MinIntensity, Ranges.MaxIntensity);

            float hFirstColor;
            float sFirstColor;
            float vFirstColor;

            Color.RGBToHSV(Ranges.FirstColor, out hFirstColor, out sFirstColor, out vFirstColor);

            float hSecondColor;
            float sSecondColor;
            float vSecondColor;

            Color.RGBToHSV(Ranges.SecondColor, out hSecondColor, out sSecondColor, out vSecondColor);


            MyLight.color = Random.ColorHSV(hFirstColor, hSecondColor, sFirstColor, sSecondColor, vFirstColor, vSecondColor);
        }
    }
}
