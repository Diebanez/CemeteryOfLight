using System.Collections.Generic;
using UnityEngine;
using TMPro;
    
[RequireComponent(typeof(PlayerLight))]
public class PlayerWax : MonoBehaviour {
    [SerializeField]
    float WaxLossRate = 0.5f;
    [SerializeField]
    TextMeshProUGUI WaxText;

    PlayerLight m_PlayerLight;
    public int Wax = 100;
    float WaxLoss = 0;
    float timer = 0;

    List<GameObject> candles = new List<GameObject>();

    private void Start()
    {
        m_PlayerLight = GetComponent<PlayerLight>();
        InputHandler.instance.ConsumeCandle += OnConsumeCandle;
    }

    private void OnDestroy()
    {
        InputHandler.instance.ConsumeCandle -= OnConsumeCandle;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            if (m_PlayerLight.IsLightOn)
            {
                WaxLoss += WaxLossRate;
                while (WaxLoss >= 1.0f)
                {
                    Wax--;
                    WaxLoss -= 1.0f;
                }
            }
            timer = 0;
        }
        WaxText.text = "Wax " + Wax;
    }    

    void OnConsumeCandle()
    {
        if(candles.Count >= 0)
        {
            Queue<GameObject> CandlesToDestroy = new Queue<GameObject>();
            foreach(GameObject Candle in candles)
            {
                Wax = 100;
                CandlesToDestroy.Enqueue(Candle);
            }

            while(CandlesToDestroy.Count > 0)
            {
                GameObject DestroyingCandle = CandlesToDestroy.Dequeue();
                candles.Remove(DestroyingCandle);
                Destroy(DestroyingCandle.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Candle" && !candles.Contains(collision.gameObject))
        {
            candles.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (candles.Contains(collision.gameObject))
        {
            candles.Remove(collision.gameObject);
        }
    }
}
