using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _camOffset;

    void Update()
    {
        transform.position = _camOffset + _player.position;
    }
}
