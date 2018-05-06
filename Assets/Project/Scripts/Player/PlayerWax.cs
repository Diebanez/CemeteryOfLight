using UnityEngine;

[RequireComponent(typeof(PlayerLight))]
public class PlayerWax : MonoBehaviour {
    [SerializeField]
    float WaxLossRate = 0.5f;    


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
        }
    }    
}
