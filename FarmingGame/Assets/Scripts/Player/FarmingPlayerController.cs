using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FarmingPlayerController : MonoBehaviour
{
    // The input handler that this player controller will be using
    FarmingGameControls farmingGameControls;

    // The player this controller is controlling
    FarmingPlayer playerControlling;

    void Start()
    {
        farmingGameControls = new FarmingGameControls();

        farmingGameControls.GameplayActionMap.MovementVector.performed += OnMoveVectorChanged;
        farmingGameControls.GameplayActionMap.MovementVector.canceled += OnMoveVectorChanged;

        if(isActiveAndEnabled) farmingGameControls.Enable();

        playerControlling = GetComponent<FarmingPlayer>();
    }

    void OnEnable()
    {
        if (farmingGameControls != null)
        {
            farmingGameControls.Enable();
        }
    }

    void OnDisable()
    {
        if (farmingGameControls != null)
        {
            farmingGameControls.Disable();
        }
    }

    void Update()
    {
        
    }

    void OnMoveVectorChanged(InputAction.CallbackContext context)
    {
        if (playerControlling)
        {
            Vector2 moveInput2D = playerControlling.moveInput = context.ReadValue<Vector2>();

            Vector3 cameraRight = Camera.main.transform.right;
            Vector3 cameraForward = Vector3.Cross(cameraRight, Vector3.up);

            playerControlling.moveInput = moveInput2D.x * cameraRight + moveInput2D.y * cameraForward;
        }
    }
}
