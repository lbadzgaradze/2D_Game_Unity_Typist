using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int type_index;
    private word_display display;

    public Word(string _word, word_display _dislay)
    {
        this.word = _word;
        this.type_index = 0;
        this.display = _dislay;
        this.display.set_word(_word); 
    }

    public char get_next_letter()
    {
        return word[type_index];
    }

    public void typed_letter()
    {
        type_index++;
        display.remove_letter();
    }

    public bool word_typed()
    {
        bool word_typed = (type_index >= word.Length);
        if(word_typed)
        {
            display.remove_word();
            game_controller.current_score += game_controller.reward_blowup_enemy;
            game_controller.score_needs_update = true;
        }
        return word_typed;
    }


}
