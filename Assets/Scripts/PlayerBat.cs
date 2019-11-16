using UnityEngine;
using System.Collections;
 
public class PlayerBat : MonoBehaviour {
 
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
 
    void Start () {
   
    }

    void Update () {
        mousePosition = Input.mousePosition;
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, 5);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
    }
}
 