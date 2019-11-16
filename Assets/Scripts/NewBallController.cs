using UnityEngine;

public class NewBallController : MonoBehaviour
{
    private float ball_target_x;
    private float ball_target_z;
    public float gravity;
    


    
    void start_move_ball(float target_x, float target_z, float max_speed)
    {
        //float _l1; 
        ball_target_x = target_x;
        ball_target_z = target_z;

        float delta_x = target_x - this.gameObject.transform.position.x;
        float delta_z = target_z - this.gameObject.transform.position.z;
        float position_magnitude = Mathf.Sqrt(target_x * target_x + target_z * target_z);
        
        float _l5 = position_magnitude/ max_speed;
        float _l7 = _l5 *(_l5 - 1) * gravity/2;

        transform.position = new Vector3(delta_x/_l5, (_l7 -transform.position.y)/_l5 ,delta_z/_l5); 
    }

    void check_hit_net()
    {
        
    }

}