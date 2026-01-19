using UnityEngine;

public class Player1 : MonoBehaviour
{
    public PlayerRemote remotePlayer;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
        if (remotePlayer == null){}
    
    }

    void Update()
    {
        Move();
        SendMovementDelta();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 5f);
    }

    void SendMovementDelta()
    {
        Vector3 delta = transform.position - lastPosition;

        if (delta.sqrMagnitude < 0.0001f)
            return;

        lastPosition = transform.position;

        var compressed = MovementCompressor.Compress(delta);

        Debug.Log($"[SEND] Delta: {delta} | Size: {MovementCompressor.GetSizeInBits()} bits");

        remotePlayer.ReceiveMovement(compressed);
    }
}
