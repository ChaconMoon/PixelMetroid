using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemies : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float positionXAnterior;
    // Start is called before the first frame update
    void Start()
    {
        positionXAnterior = transform.parent.position.x;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.flipX = positionXAnterior < transform.parent.position.x ;
        positionXAnterior = transform.position.x;
        /*
         if(posicionXAnterio < transform.position.x)
        {
        sprite.flipX = true

        } else {
        sprite.flipX = false
        }
         */
    }
}
