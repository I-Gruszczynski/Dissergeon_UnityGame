using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFollowScript : MonoBehaviour
{

    [Header("Minimap rotation")]
    public Transform playerReference;
    public float playerOffset = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerReference != null)
        {
            transform.position = new Vector3(playerReference.position.x, playerReference.position.y, playerReference.position.z - playerOffset);
        }
        
    }
}
