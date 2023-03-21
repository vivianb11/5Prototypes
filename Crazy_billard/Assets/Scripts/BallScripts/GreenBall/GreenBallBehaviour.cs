using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBallBehaviour : MonoBehaviour
{
    private GameObject player;

    private float distPlayer;
    public float maxDistance;

    private SpriteRenderer spriteRenderer;

    public float opacity = 1;
    public float minOpacity = 0.1f;
    public float maxOpacity = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distPlayer = Vector2.Distance(this.transform.position, player.transform.position);

        float opacity = Mathf.Lerp(minOpacity, maxOpacity, 1 - Mathf.InverseLerp(0, maxDistance, distPlayer));

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, opacity);

        //if (distPlayer > maxDistance)
        //{
        //    Vector2 placeToSpawnEffect = Random.insideUnitCircle;
        //}
    }
}
