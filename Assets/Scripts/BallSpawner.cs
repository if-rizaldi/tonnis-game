using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public float delay = 3f;
    private List<GameObject> balls = new List<GameObject>();
    System.Random rnd = new System.Random();
    private IEnumerator coroutine;

    void Start()
    {
        balls.Add((GameObject)Resources.Load("Ball/Ball0"));
        balls.Add((GameObject)Resources.Load("Ball/Ball1"));
        balls.Add((GameObject)Resources.Load("Ball/Ball2"));
        balls.Add((GameObject)Resources.Load("Ball/Ball3"));
        balls.Add((GameObject)Resources.Load("Ball/Ball4"));
        balls.Add((GameObject)Resources.Load("Ball/Ball5"));
        balls.Add((GameObject)Resources.Load("Ball/Ball6"));
        balls.Add((GameObject)Resources.Load("Ball/Ball7"));
        
        coroutine = BallRandomSpawning(delay);
        StartCoroutine(coroutine);
    } 

    private IEnumerator BallRandomSpawning(float waitingTime)
    {
        Instantiate(balls[rnd.Next(0,8)], this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(waitingTime);
        ResetEnumerator();
    }

    void ResetEnumerator()
    {
        coroutine = BallRandomSpawning(delay);
        StartCoroutine(coroutine);
    }
}