using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System.Linq;

public class DataService : MonoBehaviour
{

    [SerializeField] private string fileName;
    public static DataService instance { get; private set; }

    private PlayerStatsScript playerStats;
    private List<IDataService> playerStatsList;
    private FileDataHandler dataHandler;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one DataService");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.playerStatsList = FindAllPlayerStats();
        LoadGame();
    }

    public void NewGame()
    {
        this.playerStats = new PlayerStatsScript();
    }

    public void LoadGame()
    {
        this.playerStats = dataHandler.Load();

        if (this.playerStats == null)
        {
            Debug.Log("no data");
            NewGame();
        }
        foreach (IDataService playerStats1 in playerStatsList)
        {
            playerStats1.LoadData(playerStats);
        }
    }

    public void SaveGame()
    {
        foreach (IDataService playerStats1 in playerStatsList)
        {
            playerStats1.SaveData(ref playerStats);
        }
        dataHandler.Save(playerStats);
    }

    private void OnApplicationQuit()
    {
        SaveGame(); 
    }


    private List<IDataService> FindAllPlayerStats()
    {
        
        IEnumerable<IDataService> playerStatsList = GameObject.FindObjectsOfType<MonoBehaviour>().
            OfType<IDataService>();
        return new List<IDataService>(playerStatsList);
    }


    //---------------------------------------------


}
