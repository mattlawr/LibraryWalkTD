using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text text_health;
    public Text text_time;
    public Text text_currency;
    public Text text_level;

    private int hp = 5;
    private int staff = 20;

    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        LoseHealth(0);
        AddStaff(0);
        UpdateLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (text_time)
        {
            float timer = Time.time;
            string minutes = Mathf.Floor(timer / 60).ToString("00");
            string seconds = Mathf.Floor(timer % 60).ToString("00");

            text_time.text = minutes + ":" + seconds;
        }
    }

    /// <summary>
    /// Damages player health score and updates the text field.
    /// </summary>
    /// <param name="damage">Amount to decrease player health.</param>
    public void LoseHealth(int damage)
    {
        hp -= damage;

        text_health.text = "HP: " + hp;

        if (hp <= 0)
        {
            // LOSE
            print("GAME OVER");
        }
    }
    // TODO: use this method!

    /// <summary>
    /// Updates text object from spawn manager.
    /// </summary>
    /// <param name="lvl">The level to display</param>
    public void UpdateLevel(int lvl)
    {
        text_level.text = "LVL: " + lvl;
    }

    /// <summary>
    /// Increases staff resources for player to "buy" towers.
    /// </summary>
    /// <param name="amt">Amount to increase.</param>
    public void AddStaff(int amt)
    {
        staff += amt;

        text_currency.text = "Staff: " + staff;
    }
    public int GetStaff()
    {
        return staff;
    }
}
