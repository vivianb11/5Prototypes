using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableKnightAttack : MonoBehaviour
{
    public GameObject attackIndicator;
    public PolygonCollider2D isInRange;

    public float attackDuration = 1;
    public float attackCountdown = 1;

    bool attackCoroutinActive = false;

    // Start is called before the first frame update
    void Start()
    {
        ActivateAttack(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !attackCoroutinActive)
        {
            attackCoroutinActive = true;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        ActivateAttack(true);
        yield return new WaitForSeconds(attackDuration);
        ActivateAttack(false);

        yield return new WaitForSeconds(attackCountdown);

        attackCoroutinActive = false;
    }

    void ActivateAttack(bool state)
    {
        attackIndicator.SetActive(state);
        isInRange.enabled = state;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
