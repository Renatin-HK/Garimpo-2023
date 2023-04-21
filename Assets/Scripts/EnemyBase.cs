using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected Transform initalPos;
    protected float distanceToPlayer;
    protected float distanceFromInitalPos;
    protected bool aggro, chasing;
    [SerializeField]protected GameObject player;
    [Header("Enemy Status")]
    [SerializeField][Range(5, 50)] protected int healthPoints;
    [SerializeField][Range(2, 10)] protected int moveSpeed;
    [SerializeField][Range(1, 20)] protected int aggroRange;
    [SerializeField][Range(1, 20)] protected int maxFollowRange;
    [SerializeField][Range(1, 5)] protected int refreshRate;

    public abstract void Chase();

    public abstract void Return();

    public abstract void Attack();

    public abstract void CheckDistances();
}
