using UnityEngine;

public class NewBallController : MonoBehaviour
{
    private float ball_target_x;
    private float ball_target_z;
    public float gravity;
    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Bat")
        {
            set_ball_destination();
            start_move_ball();
        }

        if(other.gameObject.tag == "Field")
        {
            //Reflect dan tambah bounce
            //Kurangi reflect effect
            /*
            if(di dalam field player && bounce == 0)
            {
                poin untuk musuh
            }
            else if(di dalam field musuh && bounce == 0)
            {
                point untuk player
            }
            else
            {
                if(turn player)
                    poin musuh
                else
                    poin player
            }
            */
        }

        if(other.gameObject.name == "Net")
        {
            //Reflect sedikit
            //Kurangi reflect effect secara signifikan
            /*
                if(turn player)
                    poin musuh
                else
                    poin player
            */
        }
    }
    
    void start_move_ball()
    {
        
    }

    void set_ball_destination()
    {

    }

}