using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int collectedCoins = 0;
    [SerializeField]
    private TextMeshProUGUI m1_TextMeshProUGUI;
    [SerializeField]
    private TextMeshProUGUI m2_TextMeshProUGUI;
    private GameObject player;
    private float distance = 0;

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
        }
        m1_TextMeshProUGUI.text = "distance: " + Mathf.RoundToInt(distance);
        m2_TextMeshProUGUI.text = "coins: " + collectedCoins;
    }
}
