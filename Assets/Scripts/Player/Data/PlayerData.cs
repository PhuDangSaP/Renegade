using UnityEngine;

[CreateAssetMenu(fileName ="new PlayerData", menuName ="Data/Player Data/Base Datas")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    
}
