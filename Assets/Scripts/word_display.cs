using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class word_display : MonoBehaviour
{
    public Text text;
    public float fall_speed = game_controller.speed_falling_along_y;
    public GameObject explosionPrefab;
    public float x_speed;

    public void set_word(string word)
    {
        this.text.text = word;
    }

    public void remove_letter()
    {
        this.text.text = this.text.text.Remove(0, 1);
        this.text.color = Color.red;
    }

    public void remove_word()
    {
        animate_explosion();
        Destroy(gameObject);
    }

    public void animate_explosion()
    {
        GameObject expl = (GameObject)Instantiate(explosionPrefab);
        expl.transform.position = transform.position;
    }

    public void animate_explosion(Vector3 position)
    {
        GameObject expl = (GameObject)Instantiate(explosionPrefab);
        expl.transform.position = position;
    }

    private void Start()
    {
        float y_distance = Mathf.Abs(game_controller.enemy_creation_position_y) + Mathf.Abs(game_controller.player_pos_y);
        float y_speed = fall_speed;
        float x_ditance = Mathf.Abs(this.transform.position.x);
        x_speed = x_ditance * y_speed / y_distance;
    }

    public void Update()
    {
        Vector3 pos = this.transform.position;
        x_speed = (pos.x > 0) ? -Mathf.Abs(x_speed) : Mathf.Abs(x_speed);
        this.transform.Translate(x_speed * Time.deltaTime, -fall_speed * Time.deltaTime, 0f);
    }


}
