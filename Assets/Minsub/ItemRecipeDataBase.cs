using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemRecipeDataBase : MonoBehaviour
{
    public static ItemRecipeDataBase itemRecipeDataBase;
    private void Awake()
    {
        itemRecipeDataBase = this;
    }

    // [0] : 나무 상자, [1] : 철 상자, [2] : 나무 책장, [3] : 철 금고
    public Dictionary<string, List<int>> itemRecipe_dic = new Dictionary<string, List<int>>();

    // 리스트 데이터 순서
    // [0] = Priority  : 우선 순위
    // [1] = Priority  : 목재
    // [2] = Priority  : 단단한 목재
    // [3] = Priority  : 돌
    // [4] = Priority  : 다이아몬드

    // 나무 상자
    public List<int> woodBox = new List<int>();

    // 철 상자
    public List<int> ironBox = new List<int>();

    // 나무 책장
    public List<int> woodenBookshelf = new List<int>();

    // 철 금고
    public List<int> ironSafe = new List<int>();


    private void Start()
    {
        AddRecipeLIst();
        AddRecipe();
        //Debug.Log(itemRecipe_dic.Keys.ElementAt(0));
        //Debug.Log(itemRecipe_dic["나무 상자"][0]);
        //Debug.Log(itemRecipe_dic["나무 상자"][1]);
        //Debug.Log(itemRecipe_dic["나무 상자"][2]);
        //Debug.Log(itemRecipe_dic["나무 상자"][3]);
        //Debug.Log(itemRecipe_dic["나무 상자"][4]);
    }

    private void AddRecipeLIst()
    {
        /*woodBox.Add(1); // 0
        woodBox.Add(5); // 1
        woodBox.Add(2); // 2
        woodBox.Add(1); // 3
        woodBox.Add(0); // 4*/

        woodBox.Add(1); // 0
        woodBox.Add(1); // 1
        woodBox.Add(1); // 2
        woodBox.Add(1); // 3
        woodBox.Add(0); // 4
    }

    //private string[] itemRecipeStr = { "나무 상자", " 철 상자", "나무 책장", "철 금고" };
    void AddRecipe()
    {
        itemRecipe_dic.Add("나무 상자", woodBox);
        itemRecipe_dic.Add("철 상자", ironBox);
        itemRecipe_dic.Add("나무 책장", woodenBookshelf);
        itemRecipe_dic.Add("철 금고", ironSafe);
    }

}
