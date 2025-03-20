using UnityEngine;

[CreateAssetMenu(fileName ="new PlayerData", menuName ="Data/Player Data/Base Datas")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 1;

    [Header("In Air State")]
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultipler = 0.5f;

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;

    [Header("Wall Climb State")]
    public float wallClimbVelocity = 3f;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public float wallCheckDistance = 0.5f;
    
}
