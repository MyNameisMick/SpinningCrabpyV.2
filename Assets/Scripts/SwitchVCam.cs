using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField]
    PlayerInput playerInput;
    [SerializeField]
    int priorityBoostAmount = 10;

    CinemachineVirtualCamera virtualCamera;
    InputAction aimAction;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
    }

    private void OnEnable()
    {
        aimAction.performed += _ => StartAim();
        aimAction.canceled += _ => CancelAim(); 
    }

    private void OnDisable()
    {
        aimAction.performed -= _ => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    void StartAim()
    {
        virtualCamera.Priority += priorityBoostAmount;
    }

    void CancelAim()
    {
        virtualCamera.Priority -= priorityBoostAmount;
    }
}
