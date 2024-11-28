using System;
using UnityEngine;

public class DragonEgg : MonoBehaviour
{
    public GameObject explosion;
    
    private Score scoreText;
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Score>();
    }
    void Update()
    {
    }

    void OnCollisionEnter(Collision other)
    {
        if (CompareTagRecursive(other.transform, "Ground"))
        {
            scoreText.ResetMultipler();
            Invoke("DestroyWithFire", 2);
        }
    }

    private static bool CompareTagRecursive(Transform gameObject, string tag)
    {
        return gameObject.CompareTag(tag) || 
               (gameObject.transform.parent != null && CompareTagRecursive(gameObject.transform.parent, tag));
    }

    public void DestroyWithFire()
    {
        CancelInvoke();
        explosion = Instantiate(explosion, transform.position, Quaternion.identity, transform);
        GetComponent<Renderer>().enabled = false;
        Destroy(transform.gameObject, 5);
        Camera.main.GetComponent<DragonPicker>().DestroyShield();
    }

}
