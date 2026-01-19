using UnityEngine;

public struct CompressedMovement
{
    public short dx;
    public short dy;
    public short dz;
}

public static class MovementCompressor
{
    private const float Precision = 100f;

    public static CompressedMovement Compress(Vector3 delta)
    {
        return new CompressedMovement
        {
            dx = (short)(delta.x * Precision),
            dy = (short)(delta.y * Precision),
            dz = (short)(delta.z * Precision)
        };
    }

    public static Vector3 Decompress(CompressedMovement data)
    {
        return new Vector3(
            data.dx / Precision,
            data.dy / Precision,
            data.dz / Precision
        );
    }

    public static int GetSizeInBits()
    {
        return 16 * 3; // 48 bits
    }
}
