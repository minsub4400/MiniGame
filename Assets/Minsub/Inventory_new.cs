using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_new : MonoBehaviour
{
    private ItemRecipeDataBase recipe;
    private Inventory_UI inventory_ui;

    // 아이템의 인덱스를 저장할 리스트
    public List<int> itemsIndex = new List<int>();
    // 아이템의 갯수를 저장할 리스트
    public List<int> itemsCount = new List<int>();
    // 아이템의 이미지를 저장할 리스트
    public List<Sprite> itemsImage = new List<Sprite>();

    public static Inventory_new inventory_new;

    public Image whiteImage;
    public Sprite whiteImageSprite;
    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    // 제작 재료 부족 알림 팝업 창 오브젝트
    [SerializeField]
    private GameObject lackofmaterialUIObj;

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

    private void Update()
    {
        Debug.Log(lackOfMaterial);
    }

    void Start()
    {
        //lackofmaterialUIObj = GameObject.Find("Canvas").transform.Find("lackofmaterialUI").GetComponent<GameObject>();
        whiteImageSprite = whiteImage.sprite;
        recipe = ItemRecipeDataBase.itemRecipeDataBase;
        inventory_ui = Inventory_UI.instance;
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

        // 목재 1, 단단한 목재 1, 돌 1이 아닐떄, 실행.
        

        for (int i = 0; i < itemsIndex.Count; i++) // 리스트의 갯수 만큼 반복한다
        {   // 1. 인덱스에서 목재를 찾는다.
            if (itemsIndex[i] == 1)
            {
                // 목재가 있으면 갯수가 1이상 있는지 확인한다.
                if (itemsCount[i] >= 1)
                {
                    // 있다면 1를 차감해준다.
                    HaveARecipeItemHardWood();
                    return;
                }
            } // 해당 아이템의 갯수가 부족하면 true로 만드러 준다.
            
            if (itemsCount[i] < 2)
            {
                Debug.Log("1");
                lackOfMaterial = true;
                lackOfMaterials();
            }
        }

        if (itemsIndex.Count == 0)
        {
            Debug.Log("2");
            lackOfMaterial = true;
            lackOfMaterials();
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
                    return;
                }
            }  // 인덱스가 비워있거나 -1이고 카운트가 재료 이하 일떄,
            if (itemsCount[i] < 2)
            {
                Debug.Log("3");
                lackOfMaterial = true;
                lackOfMaterials();
            }
        }
    }

    // 재료 부족 시 띄워줄 메시지
    private void lackOfMaterials()
    {
        // 재료가 부족한데 제작 버튼을 눌렀다면
        if (inventory_new.lackOfMaterial)
        {
            lackofmaterialUIObj.SetActive(true);
        }
        lackOfMaterial = false;
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
                    return;
                    //itemsCount[i] -= 1;
                    //Debug.Log("제작 가능 합니다.");
                }
            }
            if (itemsCount[i] < 2)
            {
                Debug.Log("4");
                lackOfMaterial = true;
                lackOfMaterials();
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

                // 만약 카운트가 0이면
                if (itemsCount[i] == 0)
                {
                    Debug.Log("카운트가 0임");
                    itemsIndex[i] = -1;
                }
            }
            else if (itemsIndex[i] == 3)
            {    // 있으면 갯수가 1이상 있는지 확인한다.
                if (itemsCount[i] >= 1)
                {
                    // 있다면 1를 차감해준다.
                    itemsCount[i] -= 1;
                }

                // 만약 카운트가 0이면
                if (itemsCount[i] == 0)
                {
                    Debug.Log("카운트가 0임");
                    itemsIndex[i] = -1;
                }
            }
            else if (itemsIndex[i] == 2)
            {    //있으면 갯수를 찾는다. 갯수가 1이상인지 확인한다.
                if (itemsCount[i] >= 1)
                {
                    // 있다면 1를 차감해준다.
                    itemsCount[i] -= 1;

                }

                // 만약 카운트가 0이면
                if (itemsCount[i] == 0)
                {
                    Debug.Log("카운트가 0임");
                    itemsIndex[i] = -1;
                }
            }
        }

        MakeAIRecipeItems();
        Decrease();
        if (onChangeItem != null)
            onChangeItem.Invoke();
    }


    // 아이템 갯수가 0이면 인덱스를 -1로 바꿔주고 이미지도 지워준다.
    private void Decrease()
    {
        for (int i = 0; i < itemsIndex.Count; i++)
        {    // 인덱스가 -1이면 갯수가 0인 슬롯임
            if (itemsIndex[i] == -1)
            {
                //itemsIndex.RemoveAt(i); //인덱스를 비워준다.
                // 해당 인덱스의 이미지를 비워주고
                //itemsImage.RemoveAt(i);
                onChangeItem.Invoke();
                //Debug.Log($"인덱스 {i} : {itemsIndex[i]}");
                //Debug.Log($"이미지 {i} : {itemsImage[i]}");
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
            if (itemsIndex[i] == _itemIndex && itemsIndex[i] != -1)
            {
                // 아이템의 수량이 0이 아니고
                if (itemsCount[i] != 0)
                {
                    // 아이템의 수량이 99보다 작으면
                    if (itemsCount[i] < 99)
                    {
                        // 해당 인덱스의 카운트를 더해준다.
                        itemsCount[i] += _itemCount;
                        Debug.Log("돌고 있다2");
                        Debug.Log(itemsCount[i]);
                        inventory_ui.RedrawCountSlotUI(i);
                        return true;
                    }
                }
            }
        }

        // 인덱스가 -1인 곳을 먼저 아이템을 넣는다.
        for (int i = 0; i < itemsIndex.Count; i++)
        {
            // -1이면
            if (itemsIndex[i] == -1)
            {
                Debug.Log("돌고 있다1");
                itemsIndex[i] = _itemIndex;
                itemsCount[i] = _itemCount;
                itemsImage[i] = _itemImage;
                //itemsIndex.Add(_itemIndex);
                //itemsCount.Add(_itemCount);
                //itemsImage.Add(_itemImage);
                if (onChangeItem != null)
                    onChangeItem.Invoke();
                return true;
                /*if (itemsIndex.Count < SlotCnt)
                {
                    // 인덱스를 받은 인덱스로 바꿔주고
                    // 카운트도 바꿔주고
                    // 이미지도 바꿔준다.
                }*/

            }
        }

        if (itemsIndex.Count < SlotCnt)
        {
            Debug.Log("돌고 있다3");
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

