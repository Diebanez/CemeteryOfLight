using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {
    [SerializeField]
    GameObject Bullet;

    private void Start()
    {
        InputHandler.instance.Shoot += OnShoot;
    }

    private void OnDestroy()
    {
        InputHandler.instance.Shoot -= OnShoot;
    }

    void OnShoot(Vector3 target)
    {
        Quaternion spawnRotation = Quaternion.LookRotation(transform.position - target);
        Instantiate(Bullet, transform.position, spawnRotation);
    }
}
