using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotation;
    void Update()
    {
        GetComponent<Transform>().Rotate(rotation);
    }
}
