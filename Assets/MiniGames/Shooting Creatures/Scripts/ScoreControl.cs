using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI puntoText;

    private int score = 0;
    // Start is called before the first frame update


    public void SetScore()
    {
        score++;
        puntoText.text = "Puntos: " + score.ToString();
    }
    public void SetScore_Up2()
    {
        score+=2;
        puntoText.text = "Puntos: " + score.ToString();
    }

    public void SetScore_Up5()
    {
        score+=5;
        puntoText.text = "Puntos: " + score.ToString();
    }
}
