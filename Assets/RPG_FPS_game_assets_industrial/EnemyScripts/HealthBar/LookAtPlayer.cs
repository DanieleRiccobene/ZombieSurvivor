using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Camera mainCamera;
    private Transform cam;
    
    private void Start()
    {
        mainCamera = Camera.main;
        cam = mainCamera.transform;
    }
    
    void LateUpdate()
    {
        transform.LookAt(cam);
    }
}
