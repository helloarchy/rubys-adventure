using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float movementUnits = 3.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Debug.Log(horizontal);
        Debug.Log(vertical);
        
        Vector2 position = transform.position;
        position.x += movementUnits * horizontal * Time.deltaTime;
        position.y += movementUnits * vertical * Time.deltaTime;
        
        transform.position = position;
    }
}
