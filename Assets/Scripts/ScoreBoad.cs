using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoad : MonoBehaviour
{
    int score;
    
    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        Debug.Log($"Score Is Now: {score}");
    }
    
}
