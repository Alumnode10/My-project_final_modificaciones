using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //RED
    [Header("Elements to handle the synchronization")]
    [SerializeField] private GameManager _globalGameManager;
    // Live table to view the all players scores
    [SerializeField] private GameObject rankingOnlineRowPrefab;
    [SerializeField] private GameObject rankingOnlineContainer;
    // Chronometer
    [SerializeField] private ClockController clockController;
    // End game panel and Prefab row to complete the ranking
    [SerializeField] private TextMeshProUGUI rankingTitleText;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private GameObject rankingContainer;
    [SerializeField] private GameObject rankingMiniGameRowPrefab;

    // Private variables RED
    public bool _isEndGame;
    public int score;
    private readonly float _startTime = 5.0f;  // [You can customize this value] Start time to start the live players points
    private readonly float _repeatRate = 1.0f; // [You can customize this value] The list is updating every one second

    [SerializeField] private TextMeshProUGUI puntoText;


    // Start is called before the first frame update
    void Start()
    {
        // *** [Important] Get the global game manager instance and your prefab variant Chronometer
        //_globalGameManager = GameObject.FindGameObjectWithTag("GameManagerGlobal").GetComponent<GameManager>();
        clockController = FindObjectOfType<ClockController>();
        
        // *** [Important] This Invoke it is necessary to get the current ranking list of the global game manager.
        //InvokeRepeating("UpdateOnliveRanking",_startTime,_repeatRate);
    }

    void FixedUpdate()
    {
        // *** [Optional] This only handle the end time to call EndGame method.
        if ((clockController && clockController.IsEnd()) && !_isEndGame)
        {
            EndGame();  //DESARROLLAR
        }
    }

    public void EndGame()
    {
        // Set end game flag 
        _isEndGame = true;
        
        // *** Handle the chronometer and Deactivate
        // [Optional] var playerTime = clockController.GetElapsedTime();
        clockController.gameObject.SetActive(false);
        //scoreText.text = $"Minijuego resuelto en : {playerTime} segundos";
        //scoreText.gameObject.SetActive(true);
        
        // [Important] Send command to Global Game Manager with the player score 
        //_globalGameManager.CmdSetEndMiniGame(score);
        
        // [Optional] Set a custom title for your minigame ranking
        //rankingTitleText.text = $"Ranking Shooting Creatures";
        
        // [Maybe Important] Calling to get the final Ranking. If all players finish at the same time, it is not necessary
        // to make repeated invocations of the method and it will be enough to call it only once. 
        //InvokeRepeating("GetScores",0,_repeatRate); // You can customize this
        
    }

    /// <summary>
    /// Method GetScores [Important]
    /// This method clear the container and call to the Global Game Manager to get the updated ranking list to set into
    /// the ranking End game container
    /// </summary>
    /*private void GetScores()
    {
        // Clear container
        ClearRankingContainer(rankingContainer);
        // Call the method to set the new values into the  container
        UpdateContainer(rankingMiniGameRowPrefab,rankingContainer);
        // Active the gameObject
        if(!endGamePanel.gameObject.activeSelf) endGamePanel.gameObject.SetActive(true);
    }
    
    /// <summary>
    /// Method UpdateContainer
    /// This method get the updated list fron the global game manager and set the each row prefab into the container to
    /// show the players ranking info.
    /// </summary>
    /// <param name="prefabRow">Prefab row to set into the container</param>
    /// <param name="container">GameObject parent</param>
    private void UpdateContainer(GameObject prefabRow, GameObject container)
    {
        // Get the latest results
        var results = _globalGameManager.MiniGameResults;
        
        // Read results and instatiate a prefab row for each new player score
        for (int i = 0; i < results.Count; i++)
        {
            // Instantiate a Ranking live row prefab into the container
            var scoreRow = Instantiate(prefabRow, container.transform);
            // Get all TextMeshProUGUI components of the prefab
            var prefabTexts = scoreRow.GetComponentsInChildren<TextMeshProUGUI>();
            
            // Set the current result into the TextMeshProUGUI elements
            prefabTexts[0].text = (i + 1).ToString(); // Player position
            prefabTexts[1].text = results[i].Playername;    // Player name
            prefabTexts[2].text = $"{results[i].Points} ptos"; // Player total points 
            
            // [Optional- To handle time] prefabTexts[2].text = results[i].elapsedTime.ToString("F3") + "s";
        }
    }

    /// <summary>
    /// Method UpdateOnliveRanking
    /// This method get the list of points of all the players and mapping it to the live ranking table
    /// </summary>
    private void UpdateOnliveRanking()
    {
        // Calling to clear method to destroy old gameObject in container
        ClearRankingContainer(rankingOnlineContainer);
        
        // Handle results
        UpdateContainer(rankingOnlineRowPrefab, rankingOnlineContainer);
    }
    
    
    /// <summary>
    /// Method ClearRankingContainer [Important]
    /// This method clean the container to set the new information 
    /// </summary>
    /// <param name="container"></param>
    private void ClearRankingContainer(GameObject container)
    {
        foreach (Transform child in container.transform)
            Destroy(child.gameObject);
    }*/

    //mi logica

    private void UpdateScoreRPC(){
        // **** [Important]
        //_globalGameManager.CmdUpdatePlayerScore(score, GameType.Minigame); // This is very important, When your player get any points in the
                                                        // game, you need call the command to synchronize with the Global
                                                        // Game Manager
    }

    public void SetScore()
    {
        score++;
        puntoText.text = "Puntos: " + score.ToString();
        UpdateScoreRPC();
    }
    public void SetScore_Up2()
    {
        score+=2;
        puntoText.text = "Puntos: " + score.ToString();
        UpdateScoreRPC();

    }

    public void SetScore_Up5()
    {
        score+=5;
        puntoText.text = "Puntos: " + score.ToString();
        UpdateScoreRPC();

    }
}
