using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public Score score;
    int maxPlatform = 0;
    public void GameOver()
    {
        score.SetUp(maxPlatform);
    }
  
}
