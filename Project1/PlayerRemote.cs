using UnityEngine;

public class PlayerRemote : MonoBehaviour
{
    private Vector3 pendingDelta;

    void Update()
    {
        transform.position += pendingDelta;
        pendingDelta = Vector3.zero;
    }

    public void ReceiveMovement(CompressedMovement data)
    {
        Vector3 delta = MovementCompressor.Decompress(data);
        pendingDelta += delta;

        Debug.Log($"[RECEIVE] Delta: {delta}");
    }
}
