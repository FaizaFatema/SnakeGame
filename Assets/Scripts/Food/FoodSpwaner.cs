    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpwaner : MonoBehaviour
{
    public BoxCollider2D foodSpawn;
    public FoodScore foodscore;
    // Start is called before the first frame update
    void Start()
    {
        RandomPose();
    }

    private void RandomPose()
    {
        Bounds bounds = this.foodSpawn.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RandomPose();
            foodscore.IncraseScore();
        }
    }
}
