using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 3; // The number of lives the player has.
    public Image[] hearts; // An array of Image components representing the hearts in the UI.

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube") // Replace "Cube" with the tag you set for the cube GameObject.
        {
            LoseLife();
        }
    }

    void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            hearts[lives].enabled = false; // Hide the heart.

            if (lives <= 0)
            {
                // Game Over logic here.
                Debug.Log("Game Over");
            }
        }
    }
}