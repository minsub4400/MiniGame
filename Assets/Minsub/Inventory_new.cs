using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory_new : MonoBehaviour
{
    private ItemRecipeDataBase recipe;

    // 아이템의 인덱스를 저장할 리스트
    public List<int> itemsIndex = new List<int>();
    // 아이템의 갯수를 저장할 리스트
    public List<int> itemsCount = new List<int>();
    // 아이템의 이미지를 저장할 리스트
    public List<Sprite> itemsImage = new List<Sprite>();

    public static Inventory_new inventory_new;


    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    private void Awake()
    {
        inventory_new = this;
    }

    void Start()
    {
        recipe = ItemRecipeDataBase.itemRecipeDataBase;
        slotCnt = 4;
        /*Debug.Log("레시피 정보");
        Debug.Log(recipe.itemRecipe_dic.Keys.ElementAt(0));
        Debug.Log(recipe.itemRecipe_dic["나무 상자"][0]);
        Debug.Log(recipe.itemRecipe_dic["나무 상자"][1]);
        Debug.Log(recipe.itemRecipe_dic["나무 상자"][2]);
        Debug.Log(recipe.itemRecipe_dic["나무 상자"][3]);
        Debug.Log(recipe.itemRecipe_dic["나무 상자"][4]);*/
    }

    // 재료 부족인지 확인 하는 변수
    public bool lackOfMaterial = false;
    public void HaveARecipeItemWood()
    {
        // 이건 레시피 인덱스
        //0 : 우선순위
        //1 : 목재
        //2 : 단단한 목재
        //3 : 돌
        //4 : 다이아몬드

        // 아이템의 인덱스
        //0 : 다이아몬드 
        //1 : 목재
        //2 : 돌
        //3 : 단단한 목재

        for (int i = 0; i < itemsIndex.Count; i++) // 리스트의 갯수 만큼 반복한다
        {   // 1. 인덱스에서 목재를 찾는다.
            if (itemsIndex[i] == 1)
            {
                // 목재가 있으면 갯수가 1이상 있는지 확인한다.
                if (itemsCount[i] >= 1)
                {
                    // 있다면 1를 차감해준다.
                    HaveARecipeItemHardWood();
                    //itemsCount[i] -= 1;
                    //Debug.Log(itemsCount[i]);
                }
            }
            else
            {
                lackOfMaterial = true;
            }
        }
    }

    public void HaveARecipeItemHardWood()
    {
        for (int i = 0; i < itemsIndex.Count; i++) // 리스트의 갯수 만큼 반복한다
        {
            if (itemsIndex[i] == 3)
            {    // 있으면 갯수가 1이상 있는지 확인한다.
                if (itemsCount[i] >= 1)
                {
                    // 있다면 1를 차감해준다.
                    HaveARecipeItemRock();
                    //itemsCount[i] -= 1;
                }
            }
            else
            {
                lackOfMaterial = true;
            }
        }
    }

    public void HaveARecipeItemRock()
    {
        for (int i = 0; i < itemsIndex.Count; i++) // 리스트의 갯수 만큼 반복한다
        {
            if (itemsIndex[i] == 2)
            {    //있으면 갯수를 찾는다. 갯수가 1이상인지 확인한다.
                if (itemsCount[i] >= 1)
                {
                    // 있다면 1를 차감해준다.
                    HaveARecipeItems();
                    //itemsCount[i] -= 1;
                    //Debug.Log("제작 가능 합니다.");
                }
            }
            else
            {
                lackOfMaterial = true;
            }
        }
    }

    public void HaveARecipeItems()
    {
        for (int i = 0; i < itemsIndex.Count; i++) // 리스트의 갯수 만큼 반복한다
        {   // 1. 인덱스에서 목재를 찾는다.
            if (itemsIndex[i] == 1)
            {
                // 목재가 있으면 갯수가 1이상 있는지 확인한다.
                if (itemsCount[i] >= 1)
                {
                    // 있다면 1를 차감해준다.
                    itemsCount[i] -= 1;
                    //Debug.Log(itemsCount[i]);
                }
            }
            else if (itemsIndex[i] == 3)
            {    // 있으면 갯수가 1이상 있는지 확인한다.
                if (itemsCount[i] >= 1)
                {
                    // 있다면 1를 차감해준다.
                    itemsCount[i] -= 1;
                }
            }
            else if (itemsIndex[i] == 2)
            {    //있으면 갯수를 찾는다. 갯수가 1이상인지 확인한다.
                if (itemsCount[i] >= 1)
                {
                    // 있다면 1를 차감해준다.
                    itemsCount[i] -= 1;
                }
            }
        }

        MakeAIRecipeItems();
        if (onChangeItem != null)
            onChangeItem.Invoke();
    }

    private void Decrease()
    {
        for (int i = 0; i < itemsIndex.Count; i++)
        {    // 카운트가 0인 인덱스를 찾고
            if (itemsCount[i] == 0)
            {
                itemsIndex.RemoveAt(i); //인덱스를 비워준다.
                itemsImage.RemoveAt(i); //이미지도 비워준다.
            }
        }
    }

    public GameObject woodBoxPrefab;
    // 아이템 제작 함수
    private void MakeAIRecipeItems()
    {
        Instantiate(woodBoxPrefab, transform.position, transform.rotation);
    }

    public bool AddItem(int _itemIndex, int _itemCount, Sprite _itemImage)
    {
        // itemsIndex 리스트 내, 같은 인덱스가 존재하고 0이 아니고 99이하인 인덱스가 존재하면 
        // 이미지를 넣지 않고 해당 인덱스에 카운트가 +한다.
        for (int i = 0; i < itemsIndex.Count; i++)
        {
            // 아이템의 인덱스가 같은 것이 있고
            if (itemsIndex[i] == _itemIndex)
            {
                // 아이템의 수량이 0이 아니고
                if (itemsCount[i] != 0)
                {
                    // 아이템의 수량이 99보다 작으면
                    if (itemsCount[i] < 99)
                    {
                        // 해당 인덱스의 카운트를 더해준다.
                        itemsCount[i] +=_itemCount;
                        Debug.Log(itemsCount[i]);
                        if (onChangeItem != null)
                            onChangeItem.Invoke();
                        return true;
                    }
                }
            }
        }


        if (itemsIndex.Count < SlotCnt)
        {
            itemsIndex.Add(_itemIndex);
            itemsCount.Add(_itemCount);
            itemsImage.Add(_itemImage);
            if (onChangeItem != null)
            onChangeItem.Invoke();
            return true;
        }
        return false;
    }
}
