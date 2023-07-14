using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.VFX;

public class RebindScript : MonoBehaviour
{
    [SerializeField] private InputActionReference actionToRemap;
    [SerializeField] private Text buttonText;
    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    public void StartRebinding()
    {
        EventSystem.current.SetSelectedGameObject(null);

        buttonText.text = "Press any button";

        actionToRemap.action.Disable();

        rebindingOperation = actionToRemap.action.PerformInteractiveRebinding()
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(
                operation =>
                {
                    buttonText.text = InputControlPath.ToHumanReadableString(actionToRemap.action.bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice);
                    rebindingOperation.Dispose();
                    actionToRemap.action.Enable();
                }
            )
            .Start();
    }
}
