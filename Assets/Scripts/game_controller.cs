using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class game_controller : MonoBehaviour
{
    static public int current_score = 0;

    static public int reward_blowup_enemy = 20;
    static public int penalty_wrong_letter = 2;
    static public float seconds_between_enemy_creation = 3f;
    static public float speed_falling_along_y = 1.2f;
    static public float chance_word_is_long = 0.4f;

    static public int max_score = 0;
    static public bool score_needs_update = false;

    static public float player_pos_y = -4.4f;
    static public float enemy_creation_position_y = 5.6f;

    public GameObject game_canvas;
    public GameObject game_over_canvas;
    public GameObject level_up_canvas;
    public GameObject word_manager;

    public word_manager word_manager_script;

    public Button play_button;
    public Button start_over_button;
    public Button quit_button;
    public Button credit_button;

    public TMPro.TMP_Text current_score_dis;
    public TMPro.TMP_Text max_score_dis;
    public TMPro.TMP_Text your_score_game_over;
    public TMPro.TMP_Text max_score_game_over;


    public bool level1_achieved = false;
    public bool level2_achieved = false;
    public bool level3_achieved = false;
    public bool level4_achieved = false;
    public bool level5_achieved = false;
    public bool level6_achieved = false;
    public bool level7_achieved = false;
    public bool level8_achieved = false;
    public bool level9_achieved = false;
    public bool level10_achieved = false;




    public void game_over()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {

        yield return new WaitForSecondsRealtime(0.5f);
        word_manager.SetActive(false);
        GameObject[] residuals = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject residual_enemy in residuals)
        {
            Destroy(residual_enemy);
        }

        int temp_current_score = current_score;

        if (game_controller.current_score > game_controller.max_score)
        {
            game_controller.max_score = game_controller.current_score;
            max_score_dis.SetText(max_score.ToString());
        }
        game_controller.current_score = 0;
        score_needs_update = true;

        game_canvas.SetActive(false);
        word_manager.SetActive(false);
        game_over_canvas.SetActive(true);

        max_score_game_over.SetText(max_score.ToString());
        your_score_game_over.SetText(temp_current_score.ToString());
    }

    private void Awake()
    {

        reward_blowup_enemy = 20;
        penalty_wrong_letter = 2;
        seconds_between_enemy_creation = 3f;
        speed_falling_along_y = 1.2f;
        chance_word_is_long = 0.4f;


        start_over_button = GameObject.Find("play_again").GetComponent<Button>();
        start_over_button.onClick.AddListener(start_over_button_clicked);

        quit_button = GameObject.Find("quit_game").GetComponent<Button>();
        quit_button.onClick.AddListener(quit_button_clicked);

        current_score_dis = GameObject.Find("current_score_dis").GetComponent<TMPro.TMP_Text>();
        max_score_dis = GameObject.Find("max_score_dis").GetComponent<TMPro.TMP_Text>();
        max_score_dis.SetText(max_score.ToString());


        your_score_game_over = GameObject.Find("your_score").GetComponent<TMPro.TMP_Text>();

        max_score_game_over = GameObject.Find("max_score").GetComponent<TMPro.TMP_Text>();


        credit_button = GameObject.Find("credit_button").GetComponent<Button>();
        credit_button.onClick.AddListener(credit_button_clicked);
        

        game_canvas.SetActive(true);
        word_manager.SetActive(true);
        game_over_canvas.SetActive(false);
        level_up_canvas.SetActive(false);
    }

    public void credit_button_clicked()
    {
        SceneManager.LoadScene(2);
    }

    private void start_over_button_clicked()
    {
        SceneManager.LoadScene(1);
        game_canvas.SetActive(true);
        word_manager.SetActive(true);
        game_over_canvas.SetActive(false);
    }

    private void quit_button_clicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = (false);
#else
                Application.Quit();
#endif
    }

    public void update_current_score_onScreen()
    {
        current_score_dis.SetText(current_score.ToString());
    }


    private void Update()
    {
        if (score_needs_update)
        {
            update_current_score_onScreen();
            score_needs_update = false;
        }

        if (current_score >= 4000)
        {
            increase_difficulty(level10_achieved);
            level10_achieved = true;
        }
        else if (current_score >= 3000)
        {
            increase_difficulty(level9_achieved);
            level9_achieved = true;
        }
        else if (current_score >= 2500)
        {
            increase_difficulty(level8_achieved);
            level8_achieved = true;
        }
        else if (current_score >= 2000)
        {
            increase_difficulty(level7_achieved);
            level7_achieved = true;
        }
        else if (current_score >= 1600)
        {
            increase_difficulty(level6_achieved);
            level6_achieved = true;
        }
        else if (current_score >= 1200)
        {
            increase_difficulty(level5_achieved);
            level5_achieved = true;
        }
        else if (current_score >= 800)
        {
            increase_difficulty(level4_achieved);
            level4_achieved = true;
        }
        else if (current_score >= 400)
        {
            increase_difficulty(level3_achieved);
            level3_achieved = true;
        }
        else if (current_score >= 200) //level 2
        {
            increase_difficulty(level2_achieved);
            level2_achieved = true;
        }
        else if (current_score >= 80) //level 1
        {
            increase_difficulty(level1_achieved);
            level1_achieved = true;
        }

    }

    public void increase_difficulty(bool level_achieved)
    {
        if (level_achieved == false)
        {
            level_up();
            speed_falling_along_y *= 1.15f;
            seconds_between_enemy_creation *= 0.9f;
            penalty_wrong_letter += 2;
            reward_blowup_enemy += 5;
            chance_word_is_long *= 0.85f;
        }
    }

    public void level_up()
    {
        StartCoroutine(waiter2());
    }

    IEnumerator waiter2()
    {
        level_up_canvas.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        level_up_canvas.SetActive(false);
    }

}

