using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInput : MonoBehaviour
{
    // Start is called before the first frame update
    private ThirdPersonController controller;
    private void Awake()
    {
        controller = GetComponent<ThirdPersonController>();
    }
    public void changeToWASD()
    {
        controller._playerInput.defaultActionMap = "PlayerWASD";
    }

    public void changeToArrow()
    {
        controller._playerInput.defaultActionMap = "PlayerArrow";
    }
}
