using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText = GetComponent<TextMeshProUGUI>();
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        playerInventory.OnAllCoinsCollected.AddListener(() => FindObjectOfType<GameManager>().WinGame());
    }

    public void UpdateCoinText(PlayerInventory playerInventory)
    {
        coinText.text = "" + playerInventory.NumberOfCoins.ToString();
    }
}