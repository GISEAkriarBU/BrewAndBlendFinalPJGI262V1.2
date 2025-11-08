using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string ingredientName;
    public Sprite icon;
  

    public string GetName() => ingredientName;
}
