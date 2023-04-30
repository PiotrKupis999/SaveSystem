using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataService 
{
    void LoadData(PlayerStatsScript playerStats);
    void SaveData(ref PlayerStatsScript playerStats);

}
