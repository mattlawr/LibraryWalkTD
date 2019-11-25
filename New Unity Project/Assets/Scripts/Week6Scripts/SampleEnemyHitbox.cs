using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemyHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision With:" + collision.gameObject.tag);
    }
}
