using UnityEngine;

public class PlayerWallGrabState : PlayerTouchingWallState
{
    public PlayerWallGrabState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

  

    //public override void LogicUpdate()
    //{
    //    base.LogicUpdate();
    //    player.SetVelocityX(0f);
    //    player.SetVelocityY(0f);

    //    if(yInput>0)
    //    {
    //        stateMachine.ChangeState(player.WallClimbState);
    //    }
    //    else if(yInput<0 || !grabInput)
    //    {
    //        stateMachine.ChangeState(player.WallSlideState);
    //    }
    //}

   
}
