using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class SafeAreaFitter : MonoBehaviour
{
    [SerializeField] bool logging = true;

    RectTransform panel;
    Rect lastSafeArea;

    void Awake()
    {
        panel = GetComponent<RectTransform>();
        Refresh();
    }

    void Update()
    {
        Refresh();
    }

    void Refresh()
    {
        if (Screen.safeArea == lastSafeArea) return;

        lastSafeArea = Screen.safeArea;
        ApplySafeArea(Screen.safeArea);
    }

    void ApplySafeArea(Rect safeArea)
    {
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        panel.anchorMin = anchorMin;
        panel.anchorMax = anchorMax;

        panel.offsetMin = Vector2.zero;
        panel.offsetMax = Vector2.zero;

        if (logging)
            Debug.Log($"[SafeArea] {name}: x={safeArea.x}, y={safeArea.y}, " +
                      $"w={safeArea.width}, h={safeArea.height} | Screen: {Screen.width}x{Screen.height}");
    }
}