using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Bullet")
        {
            CoinManager.instance.AddCoins(10);
        }
    }
}
