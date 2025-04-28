using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private void Update()
    {
        transform.position = Player.Instance.transform.position;
    }
}
