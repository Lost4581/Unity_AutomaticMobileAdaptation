using UnityEngine;

public class SafeAreaLogger : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"Screen.safeArea: {Screen.safeArea} | Screen: {Screen.width}x{Screen.height} | Orientation: {Screen.orientation}");
    }

    void Update()
    {
        if (Screen.orientation != lastOrientation)
        {
            lastOrientation = Screen.orientation;
            Debug.Log($"Orientation changed: {Screen.orientation}, safeArea: {Screen.safeArea}");
        }
    }

    ScreenOrientation lastOrientation;
}