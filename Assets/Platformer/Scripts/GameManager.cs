using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    

    // Update is called once per frame
    void Update()
    {
        int intTime = 360 - (int)Time.realtimeSinceStartup;
        string timeStr = $"Time: {intTime}";
        timeText.text = timeStr;
    }
}
