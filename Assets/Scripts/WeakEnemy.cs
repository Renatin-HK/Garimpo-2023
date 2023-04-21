using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakEnemy : EnemyBase
{
    private void Start()
    {
        initalPos = this.transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void CheckDistances()
    {
        //checks the actual distance from the inital position
        distanceFromInitalPos = Vector2.Distance(initalPos.position, this.transform.position);
        //checks the actual position from the player distance
        distanceToPlayer = Vector2.Distance(this.transform.position, player.transform.position);
    }

    public override void Chase()
    {
        //TODO FAZER ELE PERSEGUIR
    }

    public override void Return()
    {
        //TODO FAZER VOLTAR PRA ONDE SPAWNOU
    }

    public override void Attack()
    {
        //TODO TRATAR ATAQUE
    }

    void Check()
    {
        StartCoroutine(Refresh());

        if (distanceToPlayer < aggroRange)
        {
            aggro = true;
        }
        else if (distanceToPlayer > (aggroRange * 1.75f)) aggro = false;
    }

    IEnumerator Refresh()
    {
        CheckDistances();
        yield return new WaitForSeconds(refreshRate);
    }

    private void FixedUpdate()
    {
        Check();
    }
}

