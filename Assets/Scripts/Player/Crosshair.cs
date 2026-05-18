using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Color color = Color.white;
    [SerializeField] private float lineLength = 10f;
    [SerializeField] private float lineWidth = 2f;
    [SerializeField] private float centerGap = 4f;

    void Start()
    {
        CreateLine(new Vector2(centerGap, 0), new Vector2(centerGap + lineLength, 0), lineWidth);
        CreateLine(new Vector2(-centerGap, 0), new Vector2(-(centerGap + lineLength), 0), lineWidth);
        CreateLine(new Vector2(0, centerGap), new Vector2(0, centerGap + lineLength), lineWidth);
        CreateLine(new Vector2(0, -centerGap), new Vector2(0, -(centerGap + lineLength)), lineWidth);
    }

    private void CreateLine(Vector2 posA, Vector2 posB, float width)
    {
        GameObject obj = new GameObject("CrosshairLine", typeof(RectTransform), typeof(Image));
        obj.transform.SetParent(transform, false);

        Image img = obj.GetComponent<Image>();
        img.color = color;

        RectTransform rt = obj.GetComponent<RectTransform>();
        Vector2 dir = (posB - posA).normalized;
        float length = Vector2.Distance(posA, posB);

        rt.sizeDelta = new Vector2(length, width);
        rt.anchoredPosition = (posA + posB) / 2f;
        rt.localRotation = Quaternion.FromToRotation(Vector2.right, dir);
    }
}
