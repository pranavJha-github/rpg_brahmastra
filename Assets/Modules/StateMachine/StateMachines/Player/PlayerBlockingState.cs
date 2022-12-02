using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockingState : PlayerBaseState
{
    private readonly int BlockHash = Animator.StringToHash("Block_Hold");

    private const float CrossFadeDuration = 0.1f;
    private State returnToState;
    public PlayerBlockingState(PlayerStateMachine stateMachine, State returnToState) : base(stateMachine) {
        this.returnToState = returnToState;
    }

    public override void Enter()
    {
        stateMachine.Health.SetInvunerable(true);
        stateMachine.Animator.CrossFadeInFixedTime(BlockHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        if (!stateMachine.InputReader.IsBlocking)
        {
            stateMachine.SwitchState(returnToState);
            //stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
            return;
        }
        //if (stateMachine.Targeter.CurrentTarget == null)
        //{
        //    stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        //    return;
        //}
    }

    public override void Exit()
    {
        stateMachine.Health.SetInvunerable(false);
    }
}
