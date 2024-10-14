using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    // ... (other properties)
    public Transform transform;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }
    public void Select()
    {
        // Visualize the selected state (e.g., change color)
    }

    public void Deselect()
    {
        // Restore the default appearance
    }
}
