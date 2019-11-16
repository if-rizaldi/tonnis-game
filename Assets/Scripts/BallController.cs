using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    private Vector3 initialVelocity;

    //[SerializeField]
    private Transform playerTransform;

    [SerializeField]
    //private float bounceVelocity = 10f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;
    private AudioSource audioSource;
    int bounces;
    private List<AudioClip> sounds = new List<AudioClip>();
    System.Random rnd = new System.Random();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
        audioSource = gameObject.GetComponent<AudioSource>();
        playerTransform = GameObject.Find("ShotingTargetReference").transform;
        sounds.Add((AudioClip)Resources.Load("Sound/hit1"));
        sounds.Add((AudioClip)Resources.Load("Sound/hit2"));
        sounds.Add((AudioClip)Resources.Load("Sound/hit3"));
        sounds.Add((AudioClip)Resources.Load("Sound/hit4"));
        Destroy(this.gameObject, 15);
    }

    private void FixedUpdate()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.name == "PlayerBat")
        {
            if(Mathf.Abs(lastFrameVelocity.z) < 10)
            {
                Vector3 directionToPlayer = playerTransform.position - transform.position;
                Vector3 direction = Vector3.Lerp(other.contacts[0].normal, directionToPlayer, 0.1f);
                rb.AddForce(direction * 600);
            }
            else
            {
                Bounce(other.contacts[0].normal, 10f, 0.1f);
            }
            
            bounces = 0;
            audioSource.PlayOneShot(sounds[rnd.Next(0, 3)]);
        }
        

        if(other.gameObject.tag == "Field")
        {   
           if(bounces == 0)
                GameState.oppenentScore++;
           Bounce(other.contacts[0].normal, 15f - bounces * 3f, 0f);
           bounces++;
           audioSource.PlayOneShot(sounds[3]);
        }
        
       

        if(other.gameObject.name == "Net")
        {
            if(bounces == 0)
                GameState.oppenentScore++;
            Bounce(other.contacts[0].normal, 0.1f, 0f);
            bounces = 7;
            audioSource.PlayOneShot(sounds[3]);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PointArea" && bounces == 0)
        {
            GameState.playerScore++;
            bounces++;
        }
    }
    
    ///<summary> Bounce the ball with some velocitiy and direction </summary>
    ///<param name="bias"> 0 = regular bounce ignoring player | 1 = direct to the player </param>
    private void Bounce(Vector3 collisionNormal, float bounceVelocity, float bias)
    {
        float speed = lastFrameVelocity.magnitude;
        Vector3 bounceDirection = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        Vector3 directionToPlayer = playerTransform.position - transform.position;

        Vector3 direction = Vector3.Lerp(bounceDirection, directionToPlayer, bias);

        rb.velocity = direction * bounceVelocity;
    }

}
