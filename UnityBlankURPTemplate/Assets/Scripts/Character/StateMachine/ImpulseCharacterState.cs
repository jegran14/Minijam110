using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseCharacterState : CharacterStateBase
{
    private float _elapsedTime;
    private Vector3 _direction;
    private float _speed;
    
    public override void Enter(PlayerController playerController)
    {
        _direction = (playerController.GetMovement == Vector3.zero)
            ? playerController.transform.forward
            : playerController.GetMovement;

        playerController.Rotate(_direction, playerController.GetRotationSpeed);
        
        Vector3 initialPosition = playerController.transform.position;
        Vector3 targetPosition = initialPosition + (_direction * playerController.GetImpulseDistance);
        _speed = (initialPosition - targetPosition).magnitude / playerController.GetImpulseTime;

        _elapsedTime = 0.0f;
    }

    public override CharacterStateBase Update(PlayerController playerController)
    {
        _elapsedTime += Time.deltaTime;

        playerController.Move(_direction, _speed);
        playerController.Rotate(_direction, playerController.GetRotationSpeed);

        if (_elapsedTime > playerController.GetImpulseTime)
            return new CharacterDefaultState();
        else
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
