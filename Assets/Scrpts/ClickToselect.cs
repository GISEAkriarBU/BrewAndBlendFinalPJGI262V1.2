using UnityEngine;

public class ClickToSelect : MonoBehaviour
{
    private Renderer objRenderer;
    private Color originalColor;
    public Color selectedColor = Color.yellow; // สีเมื่อถูกเลือก

    private static GameObject selectedObject; // วัตถุที่ถูกเลือกอยู่ตอนนี้

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        if (objRenderer != null)
        {
            originalColor = objRenderer.material.color;
        }
    }

    void OnMouseDown()
    {
        // ถ้ามีวัตถุอื่นถูกเลือกอยู่ -> ยกเลิกการเลือก
        if (selectedObject != null && selectedObject != gameObject)
        {
            selectedObject.GetComponent<ClickToSelect>().Deselect();
        }

        // ถ้าเรายังไม่ถูกเลือก -> เลือกตัวเอง
        if (selectedObject != gameObject)
        {
            Select();
        }
        else
        {
            Deselect();
        }
    }

    void Select()
    {
        selectedObject = gameObject;
        if (objRenderer != null)
            objRenderer.material.color = selectedColor;
    }

    void Deselect()
    {
        if (objRenderer != null)
            objRenderer.material.color = originalColor;

        if (selectedObject == gameObject)
            selectedObject = null;
    }
}