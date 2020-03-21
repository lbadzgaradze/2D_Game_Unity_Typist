using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class credits_controller : MonoBehaviour
{
    public Button back_credit;


    private void Awake()
    {
        back_credit = GameObject.Find("back_credit").GetComponent<Button>();
        back_credit.onClick.AddListener(back_credit_clicked);
    }
    
    public void back_credit_clicked()
    {
        SceneManager.LoadScene(0);
    }
}
