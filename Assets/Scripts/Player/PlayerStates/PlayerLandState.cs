using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(xInput != 0)
        {
            Debug.Log("Change to move");
            stateMachine.ChangeState(player.MoveState);
        }
        else if(isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
            Debug.Log("Change to idle");
        }
    }
}
