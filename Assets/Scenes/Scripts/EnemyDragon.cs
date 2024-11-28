using UnityEngine;
using UnityEngine.Serialization;

public class EnemyDragon : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject dragonEggPrefab;
    public float speed = 1f;
    public float timeBetweenEggDrops = 1f;
    public float leftRightDistance = 10f;
    [FormerlySerializedAs("chanceDirections")] public float changeDirections = 0.1f;
    void Start()
    {
    }
    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x += speed * Time.deltaTime;
        transform.position = currentPosition;
        
        if (currentPosition.x < -leftRightDistance)
        {
            speed = Mathf.Abs(speed);
        }
        else if (currentPosition.x > leftRightDistance)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    private void FixedUpdate()
    {
        if (Random.value < changeDirections)
        {
            speed *= -1;
        }

        if (Random.value < 1 / timeBetweenEggDrops / 50)
        {
            DropEgg();
        }
    }
    void DropEgg()
    {
        var eggStartPoint = new 
            Vector3(0.0f, 6.0f, 0.0f);
        var egg = Instantiate(dragonEggPrefab);
        egg.transform.position = 
            transform.position + eggStartPoint;
        egg.GetComponent<Rigidbody>().linearVelocity = new Vector3(Random.value * 2 * speed - speed, Random.value * 2 * speed - speed, 0);
    }
}
