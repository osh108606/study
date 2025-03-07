using UnityEngine;

public class Hand : MonoBehaviour
{
    public Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.right = (worldPoint - (Vector2)transform.position).normalized;
        if (transform.right.x < 0)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
