using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word_spawner : MonoBehaviour
{

    public GameObject wordPrefab;
    public GameObject ienemyPrefeb;
    public GameObject ienemyPrefeb2;
    public GameObject ienemybossPrefeb;
    public Transform word_canvas; 

    public word_display spawn_word(bool is_long)
    {
        Vector3 random_position = new Vector3(Random.Range(-8f, 8f), game_controller.enemy_creation_position_y);

        GameObject word_object = Instantiate(wordPrefab, random_position, Quaternion.identity, word_canvas);

        //randomly assign which small spaceship to use for small word
        GameObject small_spaceship = (Random.value < 0.5) ? ienemyPrefeb : ienemyPrefeb2;


        GameObject word_image = (is_long) ? Instantiate(ienemybossPrefeb, random_position, Quaternion.identity, word_object.transform) :
            Instantiate(small_spaceship, random_position, Quaternion.identity, word_object.transform);

        RectTransform react_transform = word_image.GetComponent<RectTransform>();
        react_transform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 20f, react_transform.rect.height);


        Debug.Log(small_spaceship.GetComponent<Collider2D>().bounds.size);

        return word_object.GetComponent<word_display>();
    }
}
