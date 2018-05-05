using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightController : MonoBehaviour {
    [SerializeField]
    float MinRange;
    [SerializeField]
    float MaxRange;
    [SerializeField]
    Color FirstColor;
    [SerializeField]
    Color SecondColor;
    [SerializeField]
    float MinIntensity;
    [SerializeField]
    float MaxIntensity;    
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
            MyLight.range = Random.Range(MinRange, MaxRange);
            MyLight.intensity = Random.Range(MinIntensity, MaxIntensity);

            float hFirstColor;
            float sFirstColor;
            float vFirstColor;

            Color.RGBToHSV(FirstColor, out hFirstColor, out sFirstColor, out vFirstColor);

            float hSecondColor;
            float sSecondColor;
            float vSecondColor;

            Color.RGBToHSV(SecondColor, out hSecondColor, out sSecondColor, out vSecondColor);


            MyLight.color = Random.ColorHSV(hFirstColor, hSecondColor, sFirstColor, sSecondColor, vFirstColor, vSecondColor);
        }
    }
}
