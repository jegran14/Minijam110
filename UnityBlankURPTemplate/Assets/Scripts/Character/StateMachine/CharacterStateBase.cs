using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStateBase
{
    public abstract void Enter(PlayerController playerController);
    public abstract CharacterStateBase Update(PlayerController playerController);
    public abstract CharacterStateBase OnMovement(PlayerController playerController);
    public abstract CharacterStateBase OnMovementEnd(PlayerController playerController);
    public abstract CharacterStateBase OnImpulse(PlayerController playerController);
    public abstract CharacterStateBase OnInteraction(PlayerController playerController);
}
