using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float timeToDestroy;

    public Transform[] moveSpots;
    private int randomSpot;
    private void Awake()
    {
        if (gameObject.transform.localPosition.x > 0)
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f ,0f));
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f ,0f));
        }
    }

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        Destroy(gameObject,timeToDestroy);
    }
    
    void Update()
    {
        
        Move();
        //Debug.Log(Time);

    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, Random.Range(minSpeed,maxSpeed) * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
            bool flipped = gameObject.transform.position.x > 0;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f,flipped ? 180f :0f,0f));
        }
    }
}
