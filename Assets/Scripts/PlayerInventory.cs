using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   public int NumberofCoins { get; private set;}

    public void AddCoins()
    {
         NumberofCoins++;
    }

}
