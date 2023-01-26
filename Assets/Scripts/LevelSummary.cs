using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSummary : MonoBehaviour
{
    [SerializeField] private Text CollectedItems;
    [SerializeField] private int expectedNumOfItems;

    private void Update()
    {
        if (PlayerManager.isLevelCompleted && ItemCollector.items < expectedNumOfItems)
        {
            CollectedItems.text = "Collected oranges: " + ItemCollector.items + " out of " + expectedNumOfItems;
        }
        else
        {
            CollectedItems.text = "Congratulations, you have collected all oranges";
        }
    }
}
