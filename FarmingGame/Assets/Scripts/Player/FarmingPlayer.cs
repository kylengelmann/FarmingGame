using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(CharacterController))]
public class FarmingPlayer : MonoBehaviour
{
    // The player's character controller
    CharacterController characterController;

    // Struct that holds the parameters that determine how the player moves
    [Serializable]
    public struct PlayerMovementParams
    {
        public float Speed;

        public float Acceleration;

        public float BrakingAcceleration;
    }

    // The current movement parameters for this player
    public PlayerMovementParams movementParams = new PlayerMovementParams() {Speed=6f, Acceleration = 10f, BrakingAcceleration = 15f};

    // The value of the movement input axes
    [NonSerialized]
    public Vector3 moveInput = Vector2.zero;

    // The minimum vertical component of the ground normal vector, any surfaces with a lower vertical normal will not be considered ground
    public float minVerticalGroundNormal = .7f;

    // The player's current velocity
    Vector3 velocity = Vector3.zero;

    Vector3 groundNormal = Vector3.up;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        UpdateMovement(Time.deltaTime);
    }

    void UpdateMovement(float deltaTime)
    {
        float moveAxisMagnitude = moveInput.magnitude;

        Vector3 moveAxisDirection = Mathf.Approximately(moveAxisMagnitude, 0f) ? velocity.normalized : moveInput / moveAxisMagnitude;

        moveAxisMagnitude = Mathf.Min(moveAxisMagnitude, 1f);

        Vector3 perpendicularDirection = Vector3.Cross(moveAxisDirection,Vector3.up);

        Vector3 moveDirection = Vector3.Cross(groundNormal, perpendicularDirection);

        float goalSpeed = moveAxisMagnitude * movementParams.Speed;

        float parallelSpeed = Vector3.Dot(moveDirection, velocity);

        float perpendicularSpeed = Vector3.Dot(perpendicularDirection, velocity);

        float parallelAcceleration = 0f;
        if (goalSpeed * parallelSpeed < -Mathf.Epsilon)
        {
            Debug.Log("Pivot");
            // pivoting
            parallelAcceleration = movementParams.BrakingAcceleration;
        }
        else if (goalSpeed < Mathf.Abs(parallelSpeed))
        {
            Debug.Log("Brake");
            // braking
            parallelAcceleration = -Mathf.Sign(parallelSpeed) * movementParams.BrakingAcceleration;
        }
        else if (goalSpeed > Mathf.Abs(parallelSpeed))
        {
            Debug.Log("Go");
            // speeding up
            parallelAcceleration = movementParams.Acceleration;
        }
        else
        {
            Debug.Log("Nothing");
        }

        if (!Mathf.Approximately(parallelAcceleration, 0f))
        {
            float maxDeltaParallelSpeed = goalSpeed - parallelSpeed;

            float deltaParallelSpeed = parallelAcceleration * deltaTime;

            // prevent overshoot
            if (Mathf.Approximately(Mathf.Sign(maxDeltaParallelSpeed), Mathf.Sign(deltaParallelSpeed)) &&
                Mathf.Abs(deltaParallelSpeed) > Mathf.Abs(maxDeltaParallelSpeed))
            {
                deltaParallelSpeed = maxDeltaParallelSpeed;
            }

            parallelSpeed += deltaParallelSpeed;
        }

        float perpendicularAcceleration = -Mathf.Sign(perpendicularSpeed) * movementParams.BrakingAcceleration;
        if (!Mathf.Approximately(perpendicularAcceleration, 0f))
        {
            float maxDeltaPerpendicularSpeed = -perpendicularSpeed;
            float deltaPerpendicularSpeed = perpendicularAcceleration * deltaTime;

            // prevent overshoot
            if (Mathf.Abs(maxDeltaPerpendicularSpeed) < Mathf.Abs(deltaPerpendicularSpeed))
            {
                deltaPerpendicularSpeed = maxDeltaPerpendicularSpeed;
            }

            perpendicularSpeed += deltaPerpendicularSpeed;
        }

        float gravity = Vector3.Dot(Physics.gravity, groundNormal);
        float fallingSpeed = Vector3.Dot(groundNormal, velocity);

        fallingSpeed += gravity * deltaTime;

        velocity = parallelSpeed * moveDirection + perpendicularSpeed * perpendicularDirection + fallingSpeed * groundNormal;

        groundNormal = Vector3.up;

        characterController.Move(velocity * deltaTime);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider)
        {
            velocity -= Vector3.Dot(velocity, hit.normal) * hit.normal;

            if (Vector3.Dot(Vector3.up, hit.normal) >= minVerticalGroundNormal)
            {
                groundNormal = hit.normal;
            }
        }
    }
}
