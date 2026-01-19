# Project 1:Unity Networked Movement Compression (Delta-Based)

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


# Project 2: Unity  Weapon System

## Project Overview

This project implements a basic  Shooter weapon system in Unity using C#.  
The focus of the project is to create a modular, reusable, and functional weapon framework rather than a full game.

The system allows a player to:

- Move around the environment  
- Pick up weapons  
- Switch between multiple weapons  
- Fire weapons with different modes  
- Reload weapons  
- Drop weapons  
- View weapon and ammo information on a HUD  

---

## What We Want to Do

The main objective of this project is to build a working  gameplay prototype with the following features:

### Core Functionalities

1. **Player Movement System**
   - Character movement using Unity CharacterController  
   - Keyboard input-based navigation  
   - Basic gravity simulation  

2. **Weapon System**
   - Configurable weapons using ScriptableObjects  
   - Support for Primary and Secondary weapon types  
   - Adjustable weapon properties such as:
     - Damage  
     - Fire rate  
     - Magazine size  
     - Reload time  
     - Range  
     - Fire mode (Auto / Semi-Auto)

3. **Inventory Management**
   - Store up to:
     - Two primary weapons  
     - One secondary weapon  
   - Switch between weapons  
   - Equip and drop weapons dynamically  

4. **Shooting Mechanics**
   - Raycast-based shooting  
   - Ammo tracking  
   - Reloading functionality  
   - Support for automatic and semi-automatic firing  

5. **Weapon Interaction**
   - Pick up weapons from the world  
   - Drop currently equipped weapons  
   - Equip new weapons  

6. **User Interface (HUD)**
   - Display weapon name  
   - Show current ammo and reserve ammo  
   - Highlight currently equipped weapon  

---

## Our Approach

To implement this system, we followed a structured and modular design where each part of the system is handled by a separate script.

### 1. Data-Driven Weapon Design

We used a ScriptableObject class called `WeaponData` to define weapon properties.

Each weapon contains:

- Name  
- Type  
- Fire mode  
- Ammo capacity  
- Damage  
- Range  
- Reload time  

This allows easy creation of new weapons directly in the Unity Editor without changing code.

---

### 2. Player Movement

The `PlayerC.cs` script is responsible for:

- Handling player movement  
- Processing keyboard input  
- Applying gravity  
- Moving the character using Unity’s CharacterController  

This keeps movement logic independent from combat logic.

---

### 3. Weapon Class

The `Weapon.cs` script represents individual weapons in the scene.

Responsibilities include:

- Storing ammo values  
- Managing weapon states (Equipped, Dropped, Reloading)  
- Attaching weapon to player hand  
- Using Rigidbody physics when dropped  

Each weapon acts as an independent interactive object.

---

### 4. Inventory System

The `PlayerInventory.cs` script manages:

- Storing weapons in inventory slots  
- Equipping selected weapons  
- Dropping weapons  
- Tracking currently active weapon  

Inventory Rules:

- Maximum 2 primary weapons  
- Maximum 1 secondary weapon  
- Auto-switch after dropping a weapon  

---

### 5. Weapon Controller

The `PlayerWeaponController.cs` script handles all combat-related input:

- Shooting logic  
- Reloading  
- Weapon switching  
- Dropping weapons  

It acts as the main connection between:

Player input → Inventory → Weapon behavior  

---

### 6. Weapon Pickup

The `WeaponPickup.cs` script allows weapons placed in the scene to be collected by the player using trigger colliders.

---

### 7. HUD System

The `WeaponHUD.cs` script updates the UI in real time:

- Displays current weapon  
- Shows ammo count  
- Displays available weapon slots  
- Highlights active weapon  

---

## System Architecture


Each module is independent and reusable.

---

## Controls

| Action            | Key |
|------------------|-----|
| Move Forward     | W   |
| Move Backward    | S   |
| Move Left        | A   |
| Move Right       | D   |
| Shoot            | Left Mouse Button |
| Reload           | R |
| Switch to Primary 1 | 1 |
| Switch to Primary 2 | 2 |
| Switch to Secondary | 3 |
| Drop Weapon      | G |

---

## How to Use

1. Attach the following scripts to the Player object:
   - PlayerC  
   - PlayerInventory  
   - PlayerWeaponController  

2. Create WeaponData assets for different weapons.

3. Attach WeaponData to Weapon prefabs.

4. Place Weapon objects in the scene with the `WeaponPickup` component.

5. Set up the HUD Canvas and link UI elements.

6. Run the scene and test gameplay.

---

## Technologies Used

- Unity Engine  
- C# Scripting  
- Unity Input System  
- Physics Raycasting  
- ScriptableObjects  

---

## Future Improvements

Possible enhancements:

- Add recoil mechanics  
- Add weapon animations   
- Add sound effects   
- Add weapon attachments  

---

## Conclusion

This project successfully demonstrates a modular  weapon system in Unity.






