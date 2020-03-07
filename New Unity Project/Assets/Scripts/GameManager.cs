using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text text_health;
    public Text text_time;
    public Text text_currency;
    public Text text_level;
    public GameObject ui_gameOver;

    private int hp = 5;
    private int staff = 20;
    private bool gameover = false;

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

        //DontDestroyOnLoad(gameObject);
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
            hp = 0;

            // LOSE
            GameOver();
        }
    }
    // TODO: use this method!

    void GameOver()
    {
        gameover = true;

        ui_gameOver.SetActive(true);    // Show the game over screen (over the map)
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Updates text object from spawn manager.
    /// </summary>
    /// <param name="lvl">The level to display</param>
    public void UpdateLevel(int lvl)
    {
        if (gameover) { return; }

        text_level.text = "LVL: " + lvl;
    }

    /// <summary>
    /// Increases staff resources for player to "buy" towers.
    /// </summary>
    /// <param name="amt">Amount to increase.</param>
    public void AddStaff(int amt)
    {
        if(gameover) { return; }

        staff += amt;

        text_currency.text = "Staff: " + staff;
    }
    public int GetStaff()
    {
        return staff;
    }
}
