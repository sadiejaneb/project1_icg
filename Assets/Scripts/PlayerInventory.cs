using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
   public int NumberofCoins { get; private set;}

   public UnityEvent<PlayerInventory> OnCoinCollected;

    public void AddCoins()
    {
         NumberofCoins++;
         OnCoinCollected.Invoke(this);
    }

}
