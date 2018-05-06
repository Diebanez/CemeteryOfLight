using UnityEngine;

[RequireComponent(typeof(PlayerLight))]
public class PlayerWax : MonoBehaviour {
    [SerializeField]
    float WaxLossRate = 0.5f;    
    [SerializeField]
    Sprite FirstSprite;
    [SerializeField]
    Sprite SecondSprite;
    [SerializeField]
    Sprite ThirdSprite;
    [SerializeField]
    SpriteRenderer m_SpriteRenderer;


    PlayerLight m_PlayerLight;
    public int Wax = 100;
    float WaxLoss = 0;
    float timer = 0;

    private void Start()
    {
        m_PlayerLight = GetComponent<PlayerLight>();
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
            if(Wax <= 20)
            {
                m_SpriteRenderer.sprite = FirstSprite;
            }else if( Wax<= 50)
            {
                m_SpriteRenderer.sprite = SecondSprite;
            }
            else
            {
                m_SpriteRenderer.sprite = ThirdSprite;
            }
        }
    }    
}
