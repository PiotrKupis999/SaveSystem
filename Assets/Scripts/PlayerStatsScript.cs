using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PlayerStatsScript
{
    public int collectedCoins;
    public float bestScore;
    public float sliderValue;

    public PlayerStatsScript()
    {
        this.collectedCoins = 0;
        this.bestScore = 0;
        this.sliderValue = 0;
    }
}
