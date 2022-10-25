using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;
    public GameObject panel;

    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Score :" + ScoreNum;
    }

    private void OnTriggerEnter2D(Collider2D coin)
    {
        if (coin.tag == "MyCoin")
        {
            SoundManagerScript.PlaySound("collect");
            ScoreNum++;
            Destroy(coin.gameObject);
            MyscoreText.text = "Score :" + ScoreNum;

            if (ScoreNum>4)
            {
                panel.SetActive(true);
            }
        }
    }
   
}
