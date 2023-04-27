using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class DataService : IDataService
{
    public bool SaveData<T>(string relativePath, T data, bool encrypted)
    {
        string path = Application.persistentDataPath + relativePath;

        if (File.Exists(path))
        {
            try
            {
                File.Delete(path);
                using FileStream stream = File.Create(path);
                stream.Close();
                File.WriteAllText(path, JsonConvert.SerializeObject(data));
                return true;
            }
            catch(Exception e)
            {
                Debug.LogError(e.Message);
                return false;
            }
                
        }
        else
        {
            try
            {
                using FileStream stream = File.Create(path);
                stream.Close();
                File.WriteAllText(path, JsonConvert.SerializeObject(data));
                return true;
            }
            catch (Exception e)
            {

                Debug.LogError(e.Message);
                return false;
            }
        }

    }


    public T LoadData<T>(string relativePath, bool encrypted)
    {
        string path = Application.persistentDataPath + relativePath;

        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }

        try
        {
            T data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return data;
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            throw (e);

        }


    }
}
