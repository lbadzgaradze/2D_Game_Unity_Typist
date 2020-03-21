using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject explosionPrefab;
    public void animate_explosion()
    {
        GameObject expl = (GameObject)Instantiate(explosionPrefab);
        expl.transform.position = transform.position;
    }



    public void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.tag == "enemy")
        {
            animate_explosion();
            Destroy(gameObject);

            //game over or one lives taken away
//#if UNITY_EDITOR
//            UnityEditor.EditorApplication.isPlaying = (false);
//#else
//        Application.Quit();
//#endif
        }

        //load score and play again (game over) screen

    }
}
