using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCard : MonoBehaviour
{
    [SerializeField] private Image recipeIcon;
    [SerializeField] private TextMeshProUGUI recipeName;

    public Recipe RecipeCards { get; private set; }
    
    public void ConfigRecipeCard(Recipe recipe)
    {
        RecipeCards = recipe;
        recipeIcon.sprite = recipe.ItemResult.Icon;
        recipeName.text = recipe.ItemResult.Number;
    }

    public void SelectionRecipe()
    {
        UIManager.Instance.OpenColsePanelCookingInfo(true);
        CookingManager.Instance.ShowRecipes(RecipeCards);
    }
}
