using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullettController : MonoBehaviour {
    [SerializeField]
    float MovementSpeed = 10.0f;
    [SerializeField]
    float LifeTime = 5.0f;

    float timer = 0.0f;

    protected virtual void Update()
    {
        if (timer >= LifeTime)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
        timer += Time.deltaTime;
    }
}
