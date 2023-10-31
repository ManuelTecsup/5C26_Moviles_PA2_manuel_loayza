using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Results_manager : MonoBehaviour
{
    public PlayerData playerData;
    public TextMeshProUGUI score_text;

    private void Start()
    {
        score_text.text = playerData.score + "";
        playerData.score = 0;
    }
}
