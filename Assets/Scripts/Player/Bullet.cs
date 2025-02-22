﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private int bulletDmg = 1;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collide");
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("tag enemy");
            IEnemy enemy = collision.GetComponent<IEnemy>();

            if (enemy != null)
            {
                Debug.Log("minus");
                enemy.MinusEnemyHP(bulletDmg);
            }
        }
        Destroy(gameObject);
    }
}
