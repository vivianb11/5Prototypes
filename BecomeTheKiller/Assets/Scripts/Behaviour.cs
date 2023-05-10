using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviour : MonoBehaviour
{
    [SerializeField] EnemyData myData;

    GameObject player;

    List<Collider2D> results;
    List<GameObject> resultsGo;

    Rigidbody2D rb;

    bool playerFound = false;

    private void Awake()
    {
        FindPlayer();
        resultsGo = new();
        results = new();
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!playerFound)
        {
            Movement();
        }
        else
        {
            AttackPlayer();
        }
    }

    private void Movement()
    {
        Physics2D.OverlapCircle(this.transform.position, myData.detectionZone, new ContactFilter2D(), results);

        resultsGo.Clear();

        foreach (var item in results)
        {
            resultsGo.Add(item.gameObject);
        }

        if (resultsGo.Contains(player))
        {
            playerFound = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, myData.detectionZone);
    }

    void AttackPlayer()
    {
        Physics2D.OverlapCircle(this.transform.position, myData.detectionZone, new ContactFilter2D(), results);
        

        resultsGo.Clear();

        foreach (var item in results)
        {
            resultsGo.Add(item.gameObject);
        }

        if (!resultsGo.Contains(player))
        {
            playerFound = false;
        }

        Vector2 direction = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (Vector2.Distance(player.transform.position,this.transform.position) > 0.5)
        {
            this.transform.position = Vector3.LerpUnclamped(this.transform.position, player.transform.position, myData.playerSpeed * Time.fixedDeltaTime);
        }
        else
        {
            MeleeAttack();
        }
    }

    void MeleeAttack()
    {

    }

    public void FindPlayer() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetNewPlayer(GameObject newPlayer)
    {
        player = newPlayer;
    }
}
