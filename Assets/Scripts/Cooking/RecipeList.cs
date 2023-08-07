using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public class RecipeList : ScriptableObject
{
    public Recipe[] Recipes;
}
