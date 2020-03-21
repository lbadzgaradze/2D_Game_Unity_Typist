using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_controller : MonoBehaviour
{
    public GameObject start_game_cavas;
    public GameObject instruc_n_credit_cavnas;
    public Button play_button;
    public Button quit_from_menu;
    public Button instructions_button;
    public Button play_button_int;
    public Button back_ints;

    private void Awake()
    {
        play_button = GameObject.Find("play_button").GetComponent<Button>();
        quit_from_menu = GameObject.Find("quit_from_menu").GetComponent<Button>();
        instructions_button = GameObject.Find("instructions_button").GetComponent<Button>();
        play_button_int = GameObject.Find("play_button_int").GetComponent<Button>();
        back_ints = GameObject.Find("back_ints").GetComponent<Button>();

        quit_from_menu.onClick.AddListener(quit_clicked);
        play_button.onClick.AddListener(play_button_clicked);
        play_button_int.onClick.AddListener(play_button_clicked);
        instructions_button.onClick.AddListener(instructions_button_clicked);
        back_ints.onClick.AddListener(back_ints_clicked);
    }

    private void play_button_clicked()
    {
        SceneManager.LoadScene(1);
    }
    private void instructions_button_clicked()
    {
        start_game_cavas.SetActive(false);
        instruc_n_credit_cavnas.SetActive(true);
     
}
    private void back_ints_clicked()
    {
        instruc_n_credit_cavnas.SetActive(false);
        start_game_cavas.SetActive(true);
        
    }

    private void quit_clicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = (false);
#else
                Application.Quit();
#endif
    }


    private void Start()
    {
        instruc_n_credit_cavnas.SetActive(false);
        start_game_cavas.SetActive(true);
    }
}

