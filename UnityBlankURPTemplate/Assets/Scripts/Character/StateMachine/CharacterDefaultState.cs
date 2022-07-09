using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDefaultState : CharacterStateBase
{
    public CharacterDefaultState()
    {
        
    }

    public override void Enter(PlayerController playerController)
    {
        
    }

    public override CharacterStateBase Update(PlayerController playerController)
    {
        if (playerController.GetMovement.Equals(Vector3.zero)) return this;
        
        playerController.Move(playerController.GetMovement, playerController.GetMovementSpeed);
        playerController.Rotate(playerController.GetMovement, playerController.GetRotationSpeed);

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
        return new ImpulseCharacterState();
    }

    public override CharacterStateBase OnInteraction(PlayerController playerController)
    {
        return this;
        //Should check if it can interact and change or no the
    }
}
