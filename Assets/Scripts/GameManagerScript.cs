using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour, IDataService
{
    public int collectedCoins = 0;
    [SerializeField]
    private TextMeshProUGUI m1_TextMeshProUGUI;
    [SerializeField]
    private TextMeshProUGUI m2_TextMeshProUGUI;
    [SerializeField]
    private TextMeshProUGUI m3_TextMeshProUGUI;
    private GameObject player;
    private float distance = 0;
    private float bestScore = 0;


    public void LoadData(PlayerStatsScript playerStats)
    {
        this.collectedCoins = playerStats.collectedCoins;
        this.bestScore = playerStats.bestScore;
    }

    public void SaveData(ref PlayerStatsScript playerStats)
    {

        playerStats.collectedCoins = this.collectedCoins;
        playerStats.bestScore = this.bestScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (distance < player.transform.position.z)
        {
            distance = player.transform.position.z;
            if (bestScore<distance)
            {
                bestScore = distance;
            }
        }
        m1_TextMeshProUGUI.text = "distance: " + Mathf.RoundToInt(distance);
        m2_TextMeshProUGUI.text = "coins: " + collectedCoins;
        m3_TextMeshProUGUI.text = "best score: " + Mathf.RoundToInt(bestScore);
    }
    /*
    public void SerializeJson()
    {
        if (dataService.SaveData("/plater-stats.json", Plate)
        {

        }
    }
    */
}
