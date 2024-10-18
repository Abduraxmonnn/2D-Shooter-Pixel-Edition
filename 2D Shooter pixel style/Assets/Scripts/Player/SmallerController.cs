using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallerController : MonoBehaviour
{
    public Controller originalPlayer; // Reference to the original player
    public Vector3 offset = new Vector3(1f, 0f, 0f); // Offset position relative to the original player

    void Update()
    {
        // Ensure the smaller player follows the original player
        if (originalPlayer != null)
        {
            transform.position = originalPlayer.transform.position + offset;
        }
    }
}
