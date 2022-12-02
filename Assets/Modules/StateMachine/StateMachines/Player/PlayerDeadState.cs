using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    private readonly int deathHash = Animator.StringToHash("death");
    private const float CrossFadeDuration = 0.1f;
    public PlayerDeadState(PlayerStateMachine stateMachine) : base(stateMachine) { }
    
    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(deathHash, CrossFadeDuration);
        stateMachine.Weapon.gameObject.SetActive(false);
        GameObject.Destroy(stateMachine);
    }

    public override void Tick(float deltaTime) { }

    public override void Exit() { }
}
