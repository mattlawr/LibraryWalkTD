using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text text_health;
    public Text text_time;

    private int hp = 100;

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
            // Die
        }
    }
    // TODO: use this method!

    public void ScoreIncrease(int amt)
    {
        // ???????
    }
}
