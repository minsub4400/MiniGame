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

    void Start()
    {
        //lackofmaterialUIObj = GameObject.Find("Canvas").transform.Find("lackofmaterialUI").GetComponent<GameObject>();
        whiteImageSprite = whiteImage.sprite;
        recipe = ItemRecipeDataBase.itemRecipeDataBase;
        inventory_ui = Inventory_UI.instance;
        slotCnt = 20;
        /*Debug.Log("레시피 정보");
        Debug.Log(recipe.itemRecipe_dic.Keys.ElementAt(0));
        Debug.Log(recipe.itemRecipe_dic["나무 상자"][0]);
        Debug.Log(recipe.itemRecipe_dic["나무 상자"][1]);
        Debug.Log(recipe.itemRecipe_dic["나무 상자"][2]);
        Debug.Log(recipe.itemRecipe_dic["나무 상자"][3]);
        Debug.Log(recipe.itemRecipe_dic["나무 상자"][4]);*/

        // 슬롯 수만큼 -1로 itemIndex List 초기화
        /*for (int i = 0; i < slotCnt; i++)
        {
            itemsIndex.Add(-1);
            Debug.Log($"{i} : {itemsIndex[i]}");
        }*/
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
            }
        }

        // 아이템이 하나도 없을 때, 재료가 부족하다를 띄워주는 곳
        if (itemsIndex.Count == 0)
        {
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

    // 제작아이템이 있는지 확인할 배열
    private bool[] haveACraftItem = new bool[4];
    // 0 : diamond
    // 1 : wood
    // 2 : rock
    // 3 : hardwood

    public void CraftButton()
    {
        // 여기서는 제작 레시피 데이터를 가져와서 사용할거임
        int _diamond = -1;
        int _wood = 1;
        int _rock = 1;
        int _hardwood = 1;
        HaveACraftItem(_diamond, _wood, _rock, _hardwood);
    }

    // 제작 아이템이 있는지 확인하는 함수
    public void HaveACraftItem(int _diamond, int _wood, int _rock, int _hardwood) // 제작 버튼에서 사용
    {
        // 호출 되면 haveACraftItem 배열을 false로 초기화 한다.
        for (int i = 0; i < haveACraftItem.Length; i++)
        {
            haveACraftItem[i] = false;
        }

        // -1인 데이터가 있으면 모두 트루로 바꾼다.
        // 이 재료는 실제로 감소하지는 않는다.
        if (_diamond == -1)
        {
            haveACraftItem[0] = true;
        }
        if (_wood == -1)
        {
            haveACraftItem[1] = true;
        }
        if (_rock == -1)
        {
            haveACraftItem[2] = true;
        }
        if (_hardwood == -1)
        {
            haveACraftItem[3] = true;
        }

        // 1. 목재 : 1, 단단한 목재 : 1, 돌 : 1 이 있는지 확인한다
        // 제작 레시피 데이터를 가져와서 사용할건데 지금은 임시로 하드코딩한다.
        // 인덱스가 나무면
        for (int i = 0; i < itemsIndex.Count; i++)
        {
            if (itemsIndex[i] == 0 && _diamond != -1)
            {
                // 수량이 1 이상 있는지 확인한다.
                if (itemsCount[i] >= _diamond)
                {
                    haveACraftItem[0] = true;
                }
                else
                {
                    haveACraftItem[0] = false;
                }
            }
            if (itemsIndex[i] == 1 && _wood != -1)
            {
                // 수량이 1 이상 있는지 확인한다.
                if (itemsCount[i] >= _wood)
                {
                    haveACraftItem[1] = true;
                }
                else
                {
                    haveACraftItem[1] = false;
                }
            }
            if (itemsIndex[i] == 2 && _rock != -1)
            {
                // 수량이 1 이상 있는지 확인한다.
                if (itemsCount[i] >= _rock)
                {
                    haveACraftItem[2] = true;
                }
                else
                {
                    haveACraftItem[2] = false;
                }
            }
            if (itemsIndex[i] == 3 && _hardwood != -1)
            {
                // 수량이 1 이상 있는지 확인한다.
                if (itemsCount[i] >= _hardwood)
                {
                    haveACraftItem[3] = true;
                }
                else
                {
                    haveACraftItem[3] = false;
                }
            }
        }
        // 2. 재료가 모두 있으면 HaveARecipeItemWood()를 실행한다.
        if (haveACraftItem[0] == true
            && haveACraftItem[1] == true
            && haveACraftItem[2] == true
            && haveACraftItem[3] == true)
        {
            HaveARecipeItemWood();
        }

        // 3. 재료가 하나라도 없으면 없다는 문구를 띄워준다.
        for (int i = 0; i < haveACraftItem.Length; i++)
        {
            if (haveACraftItem[i] == false)
            {
                lackOfMaterial = true;
                lackOfMaterials();
            }
        }
    }

    public bool AddItem(int _itemIndex, int _itemCount, Sprite _itemImage)
    {
        // 아이템의 수량을 추가하는 곳
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
                    // 수량이 99이상이 되면 수량을 99로 만들고 비어있는 슬롯에 99이상인 값 - 99를 해서 다른 빈 슬롯에 넣어준다.
                    /*if (itemsCount[i] > 99)
                    {
                        int _overCount = itemsCount[i] - 99;
                        itemsCount[i] = 99;
                        itemsIndex.Add(_itemIndex);
                        itemsCount.Add(_overCount);
                        itemsImage.Add(_itemImage);
                        if (onChangeItem != null)
                            onChangeItem.Invoke();
                        return true;
                    }*/
                    if (itemsCount[i] < 99)
                    {
                        // 해당 인덱스의 카운트를 더해준다.
                        itemsCount[i] += _itemCount;
                        //Debug.Log(itemsCount[i]);

                        if (itemsCount[i] > 99)
                        {
                            int _overCount = itemsCount[i] - 99;
                            itemsCount[i] = 99;
                            itemsIndex.Add(_itemIndex);
                            itemsCount.Add(_overCount);
                            itemsImage.Add(_itemImage);
                            if (onChangeItem != null)
                                onChangeItem.Invoke();
                            return true;
                        }
                        inventory_ui.RedrawCountSlotUI(i);
                        return true;
                    }
                    else if (itemsCount[i] == 99)
                    {
                        // 처음 만나는 -1(빈 슬롯)에 아이템의 정보를 넣는다.
                        for (int j = 0; j < itemsIndex.Count; j++)
                        {
                            if (itemsIndex[j] == -1 || itemsCount[j] == 0) // 빈 슬롯
                            {
                                itemsIndex.Add(_itemIndex);
                                itemsCount.Add(_itemCount);
                                itemsImage.Add(_itemImage);
                                if (onChangeItem != null)
                                    onChangeItem.Invoke();
                                return true;
                            }
                        }

                    }
                }
            }
        }

        // 제작 후 빈 슬롯으로 만드는 곳
        // 인덱스가 -1인 곳을 먼저 아이템을 넣는다.
        for (int i = 0; i < itemsIndex.Count; i++)
        {
            // -1이면
            if (itemsIndex[i] == -1)
            {
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

        // 새로운 아이템이 들어왔을 경우 추가하는 곳
        if (itemsIndex.Count <= SlotCnt)
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

