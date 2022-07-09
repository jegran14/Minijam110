using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseCharacterState : CharacterStateBase
{
    private float _elapsedTime;
    private Vector3 _initialPosition;
    private Vector3 _targetPosition;
    
    public override void Enter(PlayerController playerController)
    {
        Vector3 direction = (playerController.GetMovement == Vector3.zero)
            ? playerController.transform.forward
            : playerController.GetMovement;
        direction.y = 0;
        
        playerController.Rotate(direction, playerController.GetRotationSpeed);
        
        _initialPosition = playerController.transform.position;
        _targetPosition = _initialPosition + (direction * playerController.GetImpulseDistance);

        _elapsedTime = 0.0f;
    }

    public override CharacterStateBase Update(PlayerController playerController)
    {
        if (_elapsedTime > playerController.GetImpulseTime)
            return new CharacterDefaultState();

        Vector3 newPosition = Vector3.Lerp(_initialPosition, _targetPosition,
            _elapsedTime / playerController.GetImpulseTime);
        Vector3 direction = newPosition - playerController.transform.position;
        
        playerController.Move(direction, playerController.GetMovementSpeed);
        playerController.Rotate(direction, playerController.GetRotationSpeed);

        _elapsedTime += Time.deltaTime;
        return this;
    }

    public override CharacterStateBase OnMovement(PlayerController playerController)
    {
        return this;
    }

    public override CharacterStateBase OnMovementEnd(PlayerController playerController)
    {
        return this;
    }

    public override CharacterStateBase OnImpulse(PlayerController playerController)
    {
        return this;
    }

    public override CharacterStateBase OnInteraction(PlayerController playerController)
    {
        return this;
    }
}
