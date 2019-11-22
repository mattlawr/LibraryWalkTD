using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    //for all towers
    public float radius;

    private List<Enemy> current_enemy_list = new List<Enemy>(); // assuming its of type Enemy

    private Vector3 position; // this will be the center
    private int damage = 30;
    float fire_rate = 2.0F;
    private CircleCollider2D towerRange; 
    private int attackDelay;
    private int timer = 0;

    private void OnCollisionEnter2D(CircleCollider2D enemy) {
        //add enemy to the target list; create bullet with enemy ref and damage value and fire rate
        current_enemy_list.Add(enemy.gameObject);
    }
    private void OnCollisionExit2D(Collision2D enemy)
    {
        current_enemy_list.Remove(enemy.gameObject);
    }

    /* Basic tower */
    private void attack_enemy(){
        Enemy enemy = current_enemy_list[0];
        Bullet bullet = new Bullet(enemy, fire_rate, damage);
    }

    //----------------------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        towerRange = GetComponent<CircleCollider2D>();
        towerRange.radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
       if ((current_enemy_list.Count != 0) && (attackDelay <= timer)) {
           attack_enemy();
           timer = 0;
       }

       timer++;
    }
}
