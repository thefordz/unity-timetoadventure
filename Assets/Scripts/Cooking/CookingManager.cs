
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CookingManager : Singleton<CookingManager>
{
    [Header("Config")]
    [SerializeField] private RecipeCard _recipeCardPrefab;
    [SerializeField] private Transform recipeContainer;

    [Header("Recipe Info")] 
    [SerializeField] private Image FirstMaterialIcon;
    [SerializeField] private Image SecondMaterialIcon;
    [SerializeField] private TextMeshProUGUI FirstMaterialName;
    [SerializeField] private TextMeshProUGUI SecondMaterialName;
    [SerializeField] private TextMeshProUGUI FirstMaterialAmount;
    [SerializeField] private TextMeshProUGUI SecondMaterialAmount;
    [SerializeField] private TextMeshProUGUI recipeMassage;
    [SerializeField] private Button buttonCooking;

    [Header("Item Result")] 
    [SerializeField] private Image itemResultIcon;
    [SerializeField] private TextMeshProUGUI itemResultName;

    [Header("Recipes")] 
    [SerializeField] private RecipeList recipes;

    public Recipe RecipeSelection { get; set; }

    private void Start()
    {
        CardRecipes();
    }

    private void CardRecipes()
    {
        for (int i = 0; i < recipes.Recipes.Length; i++)
        {
            RecipeCard recipe = Instantiate(_recipeCardPrefab, recipeContainer);
            recipe.ConfigRecipeCard(recipes.Recipes[i]);
        }
    }

    public void ShowRecipes(Recipe recipe)
    {
        RecipeSelection = recipe;
        FirstMaterialIcon.sprite = recipe.Item1.Icon;
        SecondMaterialIcon.sprite = recipe.Item2.Icon;
        FirstMaterialName.text = recipe.Item1.name;
        SecondMaterialName.text = recipe.Item2.name;

        FirstMaterialAmount.text = $"{Inventory.Instance.GetAmountItem(recipe.Item1.ID)}/{recipe.Item1AmountRequire}";
        SecondMaterialAmount.text = $"{Inventory.Instance.GetAmountItem(recipe.Item2.ID)}/{recipe.Item2AmountRequire}";

        if (CanCooking(recipe))
        {
            recipeMassage.text = "Recipe Available";
            buttonCooking.interactable = true;
        }
        else
        {
            recipeMassage.text = "Need more materials";
            buttonCooking.interactable = false;
        }

        itemResultIcon.sprite = recipe.ItemResult.Icon;
        itemResultName.text = recipe.ItemResult.Number;
    }

    public bool CanCooking(Recipe recipe)
    {
        if (Inventory.Instance.GetAmountItem(recipe.Item1.ID) >= recipe.Item1AmountRequire 
            && Inventory.Instance.GetAmountItem(recipe.Item2.ID) >= recipe.Item2AmountRequire )
        {
            return true;
        }

        return false;
    }

    public void Cooking()
    {
        for (int i = 0; i < RecipeSelection.Item1AmountRequire; i++)
        {
            Inventory.Instance.ConsumeItem(RecipeSelection.Item1.ID);
        }
        
        for (int i = 0; i < RecipeSelection.Item2AmountRequire; i++)
        {
            Inventory.Instance.ConsumeItem(RecipeSelection.Item2.ID);
        }
        
        Inventory.Instance.AddItem(RecipeSelection.ItemResult, RecipeSelection.ItemResultAmount);
        ShowRecipes(RecipeSelection);
    }
}
