using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    public bool active;
    private Score scoreText;

    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Score>();
    }

    void Update()
    {
        if (!active)
        {
            return;
        }

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }
    private void OnCollisionEnter(Collision coll)
    {
        GameObject collided = coll.gameObject;
        if (collided.tag == "DragonEgg")
        {
            Destroy(collided);
            scoreText.AddMultipler(1);
            scoreText.AddScore(1);
        }
    }

    public void Activate()
    {
        active = true;
    }
}