using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    bool dead = false;
    [SerializeField] AudioSource deathSound;
    private void Update()
    {

        //player should die when falls off
        if (transform.position.y < -1f && !dead)
        {
            Die();
        }
    }

    //unity function to handle collisions
    private void OnCollisionEnter(Collision collision)
    {
        //when collision occurs with game object
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            //stop the player movement
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

    void Die()
    {
        //reload the scene
        Invoke(nameof(ReloadLevel), 1.3f) ;
        dead = true;
        deathSound.Play();
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
