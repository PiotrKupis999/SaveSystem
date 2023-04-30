using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour, IDataService
{

    public void LoadData(PlayerStatsScript playerStats)
    {
        GetComponent<Slider>().value = playerStats.sliderValue;
    }

    public void SaveData(ref PlayerStatsScript playerStats)
    {
        playerStats.sliderValue = GetComponent<Slider>().value;
    }

}
