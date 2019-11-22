using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    //for all towers
    public float radius;

    private List<Enemy> current_enemy_list = new List<Enemy>(); // assuming its of type Enemy

    private Vector3 position; // this will be the center
    private CircleCollider2D towerRange; 



    private void OnCollisionEnter2D(CircleCollider2D enemy) {
        //add enemy to the target list; create bullet with enemy ref and damage value and fire rate
        current_enemy_list.Add(enemy.gameObject);
    }
    private void OnCollisionExit2D(Collision2D enemy)
    {
        current_enemy_list.Remove(enemy.gameObject);
    }

    private void shoot_enemies(){
        Enemy enemy = current_enemy_list[0];

        /*subject to change; placeholders*/
        int damage_val = 30;
        float fire_rate = 2.0F;


        Bullet bullet = new Bullet(enemy, fire_rate, damage_val);
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
       
    }
}
