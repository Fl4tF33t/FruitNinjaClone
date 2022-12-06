using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerController playerControllerInfo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            transform.position = playerControllerInfo.playerPosition;
        }
        
    }
}
