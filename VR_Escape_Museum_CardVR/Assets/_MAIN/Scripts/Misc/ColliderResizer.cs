using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderResizer : MonoBehaviour
{
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private float sizeDecrease = 0.1f;

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(boxCollider.size.x - sizeDecrease, boxCollider.size.y, boxCollider.size.z - sizeDecrease);
    }
}
