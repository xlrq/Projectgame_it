using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int items = 0;

    [SerializeField] private Text counterOfItemsText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orange"))
        {
            Destroy(collision.gameObject);
            items++;
            counterOfItemsText.text = "Oranges: " + items;
        }
    }

    private void Update()
    {
        if (PlayerManager.isGameOver)
        {
            items = 0;
        }
    }
}
