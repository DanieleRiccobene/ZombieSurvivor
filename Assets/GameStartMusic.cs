using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartMusic : MonoBehaviour
{
    public AudioSource BattleMusic;
    public MenuManager menu;

    void Start()
    { 
        SoundManager.Instance.PlayMusic(BattleMusic.clip);
    }
}
