using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earth_controller : MonoBehaviour
{

    public word_display word_display_script;
    public game_controller game_controller_script;
    public GameObject game_canvas;

    public void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.tag == "enemy")
        {
            explode_earth(collidedWith);
            Destroy(collidedWith);
            //does earth have lives
            game_controller_script.game_over();            
        }

    }

    public void explode_earth(GameObject collidedWith)
    {
        Vector3 explode_here = collidedWith.transform.position;
        word_display_script.animate_explosion(explode_here);
        explode_here.y -= 0.5f;
        word_display_script.animate_explosion(explode_here);
        explode_here.x -= 0.5f;
        word_display_script.animate_explosion(explode_here);
        explode_here.x += 1f;
        word_display_script.animate_explosion(explode_here);
        explode_here.y -= 0.5f;
        word_display_script.animate_explosion(explode_here);
        explode_here.x -= 1f;
        word_display_script.animate_explosion(explode_here);
    }

    private void Start()
    {
        game_canvas = GameObject.Find("game_canvas");
    }
}
