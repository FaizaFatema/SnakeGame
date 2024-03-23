using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoretext;

    public void SetUp(int score)
    {
        gameObject.SetActive(true);
        scoretext.text = score.ToString() + "Score";
    }
    
}
