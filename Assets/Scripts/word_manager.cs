using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class word_manager : MonoBehaviour
{
    public List<Word> words;
    public bool has_active_word = false;
    private Word active_word;
    public word_spawner _word_spawner;
    private bool is_long = false;

    //public float word_delay = game_controller.seconds_between_enemy_creation;
    private float time_next_word = 0f;

    public void add_word(float chance_of_long)
    {
        is_long = (Random.value < chance_of_long);
        word_display dis = _word_spawner.spawn_word(is_long);
        Word word = (is_long) ? new Word(word_generator.get_random_word_long(), dis) : new Word(word_generator.get_random_word_short(), dis);  
        words.Add(word);
    }

    public void type_letter(char letter)
    {
        //define an active word
        if(has_active_word)
        {
            //check if letter is next 
            if(active_word.get_next_letter() == letter) //remove it from the word
            {
                active_word.typed_letter();
            }
            else
            {
                if (game_controller.current_score > 0)
                {
                    game_controller.current_score -= game_controller.penalty_wrong_letter;
                }
                game_controller.score_needs_update = true;
            }
            
        }
        else
        {
            foreach (Word word in words)
            {
                if (word.get_next_letter() == letter)
                {
                    active_word = word;
                    has_active_word = true;
                    word.typed_letter();
                    break;
                }
            }
        }

        if(has_active_word && active_word.word_typed())
        {
            has_active_word = false;
            words.Remove(active_word);
        }
    }

    private void Update()
    {
        if (Time.time >= time_next_word)
        {
            add_word(game_controller.chance_word_is_long);
            time_next_word = Time.time + game_controller.seconds_between_enemy_creation;
        }
    }

}
