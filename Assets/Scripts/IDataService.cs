using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataService 
{
    bool SaveData<T>(string relativePath, T data, bool encrypted);

    T LoadData<T>(string relativePath, bool encrypted);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
