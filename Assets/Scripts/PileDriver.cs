﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileDriver : AttackController
{
    public GameObject[] piledriverProjectiles; //Pipe driver game object
    [SerializeField]
    private float projectileForce = 10f;
    [SerializeField]
    private float projDisplacement = 10f;
    [SerializeField]
    private float projFloor = 68f;
    [SerializeField]
    private float deleteAfter = 1.5f;
    private float delay;
    private float[] delaytimes = new float[] {3f,3.5f,4f,4.5f,5f,5.5f,6f};
    private bool delayed = false;

    void Start()
    {
        base.SetDamage(1);
    }

    void ShootShockwave()
    {
        GameObject shockwaveLeft = Instantiate(piledriverProjectiles[0], new Vector2(transform.position.x - projDisplacement, -1*projFloor), Quaternion.identity) as GameObject;
        shockwaveLeft.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileForce * -1, 0, 0);
        GameObject shockwaveRight = Instantiate(piledriverProjectiles[1], new Vector2(transform.position.x + projDisplacement, -1*projFloor), Quaternion.identity) as GameObject;
        shockwaveRight.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileForce, 0, 0);
        Destroy(shockwaveLeft, deleteAfter);
        Destroy(shockwaveRight, deleteAfter);
    }

    void Update()
    {
        // if ('nail is hit')
        // {
            if (!delayed)
            {
                StartCoroutine(DelayAttack());
            }
        // }
        
    }

    void Attack()
    {
        //play attack animation
        ShootShockwave();
    }

    IEnumerator DelayAttack()
    {
        delayed = true;
        delay = delaytimes[Random.Range(0, delaytimes.Length)];
        yield return new WaitForSeconds(delay);
        Attack();
        delayed = false;
    }

}
