﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerWax))]
public class PlayerLight : MonoBehaviour {
    [SerializeField]
    Light m_Light;
    [SerializeField]
    LightController m_LightController;
    [SerializeField]
    LightRange FirstLightRange;
    [SerializeField]
    LightRange SecondLightRange;
    [SerializeField]
    LightRange ThirdLightRange;
    [SerializeField]
    float LightLossRate = .5f;

    PlayerWax m_PlayerWax;
    public bool IsLightOn = true;
    int LightPoints = 100;
    float LightLoss = 0;
    float timer = 0;

    private void Start()
    {
        m_PlayerWax = GetComponent<PlayerWax>();
    }

    private void Update()
    {
        if (m_PlayerWax.Wax > 0 && IsLightOn)
        {
            OnChangeLight(true);
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                if (IsLightOn)
                {
                    LightLoss += LightLossRate;
                    while (LightLoss >= 1.0f)
                    {
                        LightPoints--;
                        LightLoss -= 1.0f;
                    }
                }
                timer = 0;
                if(LightPoints <= 0)
                {
                    OnChangeLight(false);
                }else if (LightPoints <= 20)
                {
                    m_LightController.Ranges = FirstLightRange;
                }
                else if (LightPoints <= 50)
                {
                    m_LightController.Ranges = SecondLightRange;
                }
                else
                {
                    m_LightController.Ranges = ThirdLightRange;
                }
            }
        }
        else
        {
            OnChangeLight(false);
        }
    }

    public void OnChangeLight(bool on)
    {
        if (on)
        {
            m_Light.enabled = true;
            IsLightOn = true;
        }
        else
        {
            m_Light.enabled = false;
            IsLightOn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Candle")
        {
            LightPoints = 100;
            OnChangeLight(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Candle")
        {
            LightPoints = 100;
            OnChangeLight(true);
        }
    }
}