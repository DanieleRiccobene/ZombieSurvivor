using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    int coins = 0;
    [SerializeField] public TMP_Text pointText;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pointText.text = "POINTS: " + coins.ToString();
    }

    public void AddCoins(int coinsToAdd)
    {
        coins += coinsToAdd;
        pointText.text = "POINTS: " + coins.ToString();
    }

    public void ShowCoins()
    {
        Debug.Log(coins);
    }
}
