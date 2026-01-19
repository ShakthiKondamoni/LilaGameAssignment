# Unity Networked Movement Compression (Delta-Based)

## Overview
This repository contains plain C# scripts designed to demonstrate **movement delta
compression** for multiplayer games in Unity.

Instead of sending full `Vector3` position data every frame, the system compresses
**per-tick movement deltas** into fixed-size integers to reduce network bandwidth
while maintaining acceptable accuracy.
-----------
## Approach 1: 3-Axis Movement Compression (X, Y, Z)

### Description
This approach compresses movement deltas on **all three axes**: horizontal (`X`),
vertical (`Y`), and depth (`Z`). It ensures that the remote character receives a
complete representation of the player’s movement.
This approach is suitable for:
- Jumping
- Gravity-based motion
- Slopes and uneven terrain
- Flying or vertical traversal

### Implementation
```csharp
public struct CompressedMovement
{
    public short dx;
    public short dy;
    public short dz;
}
```
A fixed-point precision factor is applied
const float Precision = 100f;

dx → 16 bits

dy → 16 bits

dz → 16 bits

Total = 48 bits (6 bytes)


## Approach 1: 2-Axis Movement Compression (X, Z)

This alternative approach compresses only the horizontal movement axes
(X and Z) and ignores vertical movement (Y).

This method assumes:

Characters are always grounded

Gravity and jumping are handled locally

Vertical displacement is negligible or deterministic
```csharp
public struct CompressedMovement
{
    public short dx;
    public short dz;
}
```
dx → 16 bits

dz → 16 bits
Total = 32 bits (4 bytes)
