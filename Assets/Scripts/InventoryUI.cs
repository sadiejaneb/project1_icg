using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI coinText;
  
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