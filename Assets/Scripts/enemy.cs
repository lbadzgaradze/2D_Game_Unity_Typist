using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //[Header("Set in Inspector")]

    // Speed at which the enemy moves
    public float speed_x = 0.2f;
    public float speed_y;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.position;
        float proportional_speed = (Mathf.Abs(game_controller.player_pos_y) + Mathf.Abs(game_controller.enemy_creation_position_y)) * speed_x / Mathf.Abs(position.x);
        speed_y = (Mathf.Abs(position.x) > 2) ? proportional_speed : speed_x * 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        //case when it lands exactly on 0
        if (Mathf.Abs(pos.x) > 0.01)
        {
            speed_x = (pos.x > 0) ? -Mathf.Abs(speed_x) : Mathf.Abs(speed_x);
            pos.x += speed_x * Time.deltaTime;
            
        }
        
        pos.y -= speed_y * Time.deltaTime;
        transform.position = pos;




    }
}
