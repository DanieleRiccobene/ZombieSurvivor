using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ShooterController: MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask;
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform projectilePrefab;
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private Canvas cross;
    public AudioClip gunFire;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInput;
    private Animator animator;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInput = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        cross.gameObject.SetActive(false);
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }


        if (starterAssetsInput.aim){
            aimVirtualCamera.gameObject.SetActive(true);
            cross.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(false);
            starterAssetsInput.sprint = false;
            if (starterAssetsInput.move != Vector2.zero)
            {
                animator.SetBool("WalkPistol", true);
            }
            else
            {
                animator.SetBool("WalkPistol", false);
            }
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));// per un'animazione più morbida

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            if (starterAssetsInput.aim && starterAssetsInput.shoot)
            {
                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                Instantiate(projectilePrefab, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                starterAssetsInput.shoot = false;
                SoundManager.Instance.Play(gunFire);
            }
        }
        else
        {   
            aimVirtualCamera.gameObject.SetActive(false);
            cross.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(true);
            animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }       
    }
}
