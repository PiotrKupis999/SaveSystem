using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDataHandler : MonoBehaviour
{
    private string dataDirPath = string.Empty;
    private string dataFileName = string.Empty;

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public PlayerStatsScript Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        PlayerStatsScript loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<PlayerStatsScript>(dataToLoad);
            }
            catch (Exception e)
            {

                Debug.LogError("couldn't load data" + e);
            }
        }
        return loadedData;

    }

    public void Save(PlayerStatsScript playerStats1)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(playerStats1);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {

            Debug.LogError("couldn't save data" + e);
        }
    }
}
