using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
     public int totalNumberOfCoins;
     public int NumberOfCoins { get; private set; }
     public UnityEvent<PlayerInventory> OnCoinCollected;
     public UnityEvent OnAllCoinsCollected;

     private void Start()
     {
          // Initialize the total number of coins at the beginning
          totalNumberOfCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
     }

     public void AddCoins()
     {
          NumberOfCoins++;
          Debug.Log("Coins collected: " + NumberOfCoins);
          OnCoinCollected.Invoke(this);
          if (NumberOfCoins >= totalNumberOfCoins)
          {
               OnAllCoinsCollected.Invoke();
          }
     }
     
}