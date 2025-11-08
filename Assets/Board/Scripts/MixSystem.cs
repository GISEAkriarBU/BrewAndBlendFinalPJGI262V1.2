using UnityEngine;

public class MixSystem : MonoBehaviour
{
    public static MixSystem Instance;

    private Cell selectedA;
    private Cell selectedB;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SelectCell(Cell cell)
    {
        if (cell == null) return;
        if (selectedA == null)
        {
            selectedA = cell;
            // optional: highlight selectedA
            return;
        }

        if (selectedB == null)
        {
            selectedB = cell;
            TryMix();
        }
    }

    void TryMix()
    {
        if (selectedA == null || selectedB == null) return;

        // ตัวอย่าง: ตรวจ ingredient ไม่ว่างทั้งคู่
        if (!selectedA.IsEmpty() && !selectedB.IsEmpty())
        {
            Debug.Log($"Mixing {selectedA.ingredient.GetName()} + {selectedB.ingredient.GetName()}");
            // ตรวจสูตรใน RecipeDatabase
        }
        else
        {
            Debug.Log("One or both cells empty.");
        }

        // รีเซ็ต selections
        selectedA = null;
        selectedB = null;
        // ลบ highlight ถ้ามี
    }
}
