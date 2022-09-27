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

    // [0] : ���� ����, [1] : ö ����, [2] : ���� å��, [3] : ö �ݰ�
    public Dictionary<string, List<int>> itemRecipe_dic = new Dictionary<string, List<int>>();

    // ����Ʈ ������ ����
    // [0] = Priority  : �켱 ����
    // [1] = Priority  : ����
    // [2] = Priority  : �ܴ��� ����
    // [3] = Priority  : ��
    // [4] = Priority  : ���̾Ƹ��

    // ���� ����
    public List<int> woodBox = new List<int>();

    // ö ����
    public List<int> ironBox = new List<int>();

    // ���� å��
    public List<int> woodenBookshelf = new List<int>();

    // ö �ݰ�
    public List<int> ironSafe = new List<int>();


    private void Start()
    {
        AddRecipeLIst();
        AddRecipe();
        //Debug.Log(itemRecipe_dic.Keys.ElementAt(0));
        //Debug.Log(itemRecipe_dic["���� ����"][0]);
        //Debug.Log(itemRecipe_dic["���� ����"][1]);
        //Debug.Log(itemRecipe_dic["���� ����"][2]);
        //Debug.Log(itemRecipe_dic["���� ����"][3]);
        //Debug.Log(itemRecipe_dic["���� ����"][4]);
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

    //private string[] itemRecipeStr = { "���� ����", " ö ����", "���� å��", "ö �ݰ�" };
    void AddRecipe()
    {
        itemRecipe_dic.Add("���� ����", woodBox);
        itemRecipe_dic.Add("ö ����", ironBox);
        itemRecipe_dic.Add("���� å��", woodenBookshelf);
        itemRecipe_dic.Add("ö �ݰ�", ironSafe);
    }

}
