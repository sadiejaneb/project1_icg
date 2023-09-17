using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool rotate;

    public float rotationSpeed;
    void Update()
    {

        if (rotate)
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.AddCoins();
            gameObject.SetActive(false);
        }
    }
}
