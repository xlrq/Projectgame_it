using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSummary : MonoBehaviour
{
    [SerializeField] private Text CollectedItems;

    private void Update()
    {
        if (PlayerManager.isLevelCompleted)
        {
            CollectedItems.text = "Collected items: " + ItemCollector.items + " out of 8";
        }
    }
}
