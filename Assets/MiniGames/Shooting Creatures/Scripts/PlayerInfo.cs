using System.Collections;
using System.Collections.Generic;
using Mirror;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerInfo : NetworkBehaviour
{
   [SyncVar (hook = nameof(SetScore))]
    public int score;
   
    [SerializeField] private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
      scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;  Debug.Log(score);
        }   
    }

    private void SetScore(int oldScore, int newScore)
    {
        score = newScore;
        scoreText.text = 
            "JJ " + score.ToString();
    }
}
