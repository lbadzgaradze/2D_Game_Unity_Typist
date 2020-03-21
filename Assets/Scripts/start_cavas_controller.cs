using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start_cavas_controller : MonoBehaviour
{
    public Button play_button;
    public Button quit_from_menu;

    private void Awake()
    {
        play_button = GameObject.Find("play_button").GetComponent<Button>();
        quit_from_menu = GameObject.Find("quit_from_menu").GetComponent<Button>();

        quit_from_menu.onClick.AddListener(quit_clicked);
        play_button.onClick.AddListener(play_button_clicked);
    }

    private void quit_clicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = (false);
#else
                Application.Quit();
#endif
    }
    private void play_button_clicked()
    {
        SceneManager.LoadScene(1);
    }
}
