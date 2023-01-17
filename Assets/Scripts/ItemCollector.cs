using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int items = 0;

    [SerializeField] private Text counterOfItemsText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectible item"))
        {
            Destroy(collision.gameObject);
            items++;
            counterOfItemsText.text = "Collected items: " + items;
        }
    }
}
