using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullettController : MonoBehaviour {
    [SerializeField]
    float MovementSpeed = 10.0f;

    private void Update()
    {
        transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
    }
}
