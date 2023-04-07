using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCollector : MonoBehaviour
{
    private int _bananas = 0;

    [SerializeField] private TextMeshProUGUI _bananaText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            _bananas++;
            _bananaText.text = "Fruits: "+ _bananas+"/80";
        }
    }
}
