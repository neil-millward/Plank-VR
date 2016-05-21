using UnityEngine;
using System.Collections;

public class AxeMovement : MonoBehaviour
{
    public int maxSpeed;

    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        

        startPosition = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MoveHorizontal();
       // transform.Rotate(1, 1, 1);
    }

    void MoveHorizontal()
    {
        transform.position = new Vector3(startPosition.x, startPosition.y + Mathf.Sin(Time.time * maxSpeed), startPosition.z);

    }
}