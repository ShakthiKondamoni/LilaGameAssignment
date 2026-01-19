using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Camera")]
    public Camera playerCamera;

    [Header("Input Components")]
    public MonoBehaviour[] inputComponents;

    void Awake()
    {
        UnPossess(); 
    }

    public void Possess()
    {
        foreach (var c in inputComponents)
            c.enabled = true;

        if (playerCamera != null)
            playerCamera.gameObject.SetActive(true);
    }

    public void UnPossess()
    {
        foreach (var c in inputComponents)
            c.enabled = false;

        if (playerCamera != null)
            playerCamera.gameObject.SetActive(false);
    }
}
