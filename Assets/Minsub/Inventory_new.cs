using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_new : MonoBehaviour
{
    private ItemRecipeDataBase recipe;
    private Inventory_UI inventory_ui;

    // �������� �ε����� ������ ����Ʈ
    public List<int> itemsIndex = new List<int>();
    // �������� ������ ������ ����Ʈ
    public List<int> itemsCount = new List<int>();
    // �������� �̹����� ������ ����Ʈ
    public List<Sprite> itemsImage = new List<Sprite>();

    public static Inventory_new inventory_new;

    public Image whiteImage;
    public Sprite whiteImageSprite;
    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountChange;

    // ���� ��� ���� �˸� �˾� â ������Ʈ
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
        /*Debug.Log("������ ����");
        Debug.Log(recipe.itemRecipe_dic.Keys.ElementAt(0));
        Debug.Log(recipe.itemRecipe_dic["���� ����"][0]);
        Debug.Log(recipe.itemRecipe_dic["���� ����"][1]);
        Debug.Log(recipe.itemRecipe_dic["���� ����"][2]);
        Debug.Log(recipe.itemRecipe_dic["���� ����"][3]);
        Debug.Log(recipe.itemRecipe_dic["���� ����"][4]);*/

        // ���� ����ŭ -1�� itemIndex List �ʱ�ȭ
        /*for (int i = 0; i < slotCnt; i++)
        {
            itemsIndex.Add(-1);
            Debug.Log($"{i} : {itemsIndex[i]}");
        }*/
    }

    // ��� �������� Ȯ�� �ϴ� ����
    public bool lackOfMaterial = false;

    public void HaveARecipeItemWood()
    {
        // �̰� ������ �ε���
        //0 : �켱����
        //1 : ����
        //2 : �ܴ��� ����
        //3 : ��
        //4 : ���̾Ƹ��

        // �������� �ε���
        //0 : ���̾Ƹ�� 
        //1 : ����
        //2 : ��
        //3 : �ܴ��� ����

        // ���� 1, �ܴ��� ���� 1, �� 1�� �ƴҋ�, ����.
        

        for (int i = 0; i < itemsIndex.Count; i++) // ����Ʈ�� ���� ��ŭ �ݺ��Ѵ�
        {   // 1. �ε������� ���縦 ã�´�.
            if (itemsIndex[i] == 1)
            {
                // ���簡 ������ ������ 1�̻� �ִ��� Ȯ���Ѵ�.
                if (itemsCount[i] >= 1)
                {
                    // �ִٸ� 1�� �������ش�.
                    HaveARecipeItemHardWood();
                    return;
                }
            }
        }

        // �������� �ϳ��� ���� ��, ��ᰡ �����ϴٸ� ����ִ� ��
        if (itemsIndex.Count == 0)
        {
            lackOfMaterial = true;
            lackOfMaterials();
        }
    }

    public void HaveARecipeItemHardWood()
    {
        for (int i = 0; i < itemsIndex.Count; i++) // ����Ʈ�� ���� ��ŭ �ݺ��Ѵ�
        {
            if (itemsIndex[i] == 3)
            {    // ������ ������ 1�̻� �ִ��� Ȯ���Ѵ�.
                if (itemsCount[i] >= 1)
                {
                    // �ִٸ� 1�� �������ش�.
                    HaveARecipeItemRock();
                    //itemsCount[i] -= 1;
                    return;
                }
            }
        }
    }

    // ��� ���� �� ����� �޽���
    private void lackOfMaterials()
    {
        // ��ᰡ �����ѵ� ���� ��ư�� �����ٸ�
        if (inventory_new.lackOfMaterial)
        {
            lackofmaterialUIObj.SetActive(true);
        }
        lackOfMaterial = false;
    }

    public void HaveARecipeItemRock()
    {
        for (int i = 0; i < itemsIndex.Count; i++) // ����Ʈ�� ���� ��ŭ �ݺ��Ѵ�
        {
            if (itemsIndex[i] == 2)
            {    //������ ������ ã�´�. ������ 1�̻����� Ȯ���Ѵ�.
                if (itemsCount[i] >= 1)
                {
                    // �ִٸ� 1�� �������ش�.
                    HaveARecipeItems();
                    return;
                    //itemsCount[i] -= 1;
                    //Debug.Log("���� ���� �մϴ�.");
                }
            }
        }
    }

    public void HaveARecipeItems()
    {
        for (int i = 0; i < itemsIndex.Count; i++) // ����Ʈ�� ���� ��ŭ �ݺ��Ѵ�
        {   // 1. �ε������� ���縦 ã�´�.
            if (itemsIndex[i] == 1)
            {
                // ���簡 ������ ������ 1�̻� �ִ��� Ȯ���Ѵ�.
                if (itemsCount[i] >= 1)
                {
                    // �ִٸ� 1�� �������ش�.
                    itemsCount[i] -= 1;
                    //Debug.Log(itemsCount[i]);
                }

                // ���� ī��Ʈ�� 0�̸�
                if (itemsCount[i] == 0)
                {
                    itemsIndex[i] = -1;
                }
            }
            else if (itemsIndex[i] == 3)
            {    // ������ ������ 1�̻� �ִ��� Ȯ���Ѵ�.
                if (itemsCount[i] >= 1)
                {
                    // �ִٸ� 1�� �������ش�.
                    itemsCount[i] -= 1;
                }

                // ���� ī��Ʈ�� 0�̸�
                if (itemsCount[i] == 0)
                {
                    itemsIndex[i] = -1;
                }
            }
            else if (itemsIndex[i] == 2)
            {    //������ ������ ã�´�. ������ 1�̻����� Ȯ���Ѵ�.
                if (itemsCount[i] >= 1)
                {
                    // �ִٸ� 1�� �������ش�.
                    itemsCount[i] -= 1;

                }

                // ���� ī��Ʈ�� 0�̸�
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


    // ������ ������ 0�̸� �ε����� -1�� �ٲ��ְ� �̹����� �����ش�.
    private void Decrease()
    {
        for (int i = 0; i < itemsIndex.Count; i++)
        {    // �ε����� -1�̸� ������ 0�� ������
            if (itemsIndex[i] == -1)
            {
                //itemsIndex.RemoveAt(i); //�ε����� ����ش�.
                // �ش� �ε����� �̹����� ����ְ�
                //itemsImage.RemoveAt(i);
                onChangeItem.Invoke();
                //Debug.Log($"�ε��� {i} : {itemsIndex[i]}");
                //Debug.Log($"�̹��� {i} : {itemsImage[i]}");
            }
        }
    }

    public GameObject woodBoxPrefab;
    // ������ ���� �Լ�
    private void MakeAIRecipeItems()
    {
        Instantiate(woodBoxPrefab, transform.position, transform.rotation);
    }

    // ���۾������� �ִ��� Ȯ���� �迭
    private bool[] haveACraftItem = new bool[4];
    // 0 : diamond
    // 1 : wood
    // 2 : rock
    // 3 : hardwood

    public void CraftButton()
    {
        // ���⼭�� ���� ������ �����͸� �����ͼ� ����Ұ���
        int _diamond = -1;
        int _wood = 1;
        int _rock = 1;
        int _hardwood = 1;
        HaveACraftItem(_diamond, _wood, _rock, _hardwood);
    }

    // ���� �������� �ִ��� Ȯ���ϴ� �Լ�
    public void HaveACraftItem(int _diamond, int _wood, int _rock, int _hardwood) // ���� ��ư���� ���
    {
        // ȣ�� �Ǹ� haveACraftItem �迭�� false�� �ʱ�ȭ �Ѵ�.
        for (int i = 0; i < haveACraftItem.Length; i++)
        {
            haveACraftItem[i] = false;
        }

        // -1�� �����Ͱ� ������ ��� Ʈ��� �ٲ۴�.
        // �� ���� ������ ���������� �ʴ´�.
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

        // 1. ���� : 1, �ܴ��� ���� : 1, �� : 1 �� �ִ��� Ȯ���Ѵ�
        // ���� ������ �����͸� �����ͼ� ����Ұǵ� ������ �ӽ÷� �ϵ��ڵ��Ѵ�.
        // �ε����� ������
        for (int i = 0; i < itemsIndex.Count; i++)
        {
            if (itemsIndex[i] == 0 && _diamond != -1)
            {
                // ������ 1 �̻� �ִ��� Ȯ���Ѵ�.
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
                // ������ 1 �̻� �ִ��� Ȯ���Ѵ�.
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
                // ������ 1 �̻� �ִ��� Ȯ���Ѵ�.
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
                // ������ 1 �̻� �ִ��� Ȯ���Ѵ�.
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
        // 2. ��ᰡ ��� ������ HaveARecipeItemWood()�� �����Ѵ�.
        if (haveACraftItem[0] == true
            && haveACraftItem[1] == true
            && haveACraftItem[2] == true
            && haveACraftItem[3] == true)
        {
            HaveARecipeItemWood();
        }

        // 3. ��ᰡ �ϳ��� ������ ���ٴ� ������ ����ش�.
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
        // �������� ������ �߰��ϴ� ��
        // itemsIndex ����Ʈ ��, ���� �ε����� �����ϰ� 0�� �ƴϰ� 99������ �ε����� �����ϸ� 
        // �̹����� ���� �ʰ� �ش� �ε����� ī��Ʈ�� +�Ѵ�.
        for (int i = 0; i < itemsIndex.Count; i++)
        {
            // �������� �ε����� ���� ���� �ְ�
            if (itemsIndex[i] == _itemIndex && itemsIndex[i] != -1)
            {
                // �������� ������ 0�� �ƴϰ�
                if (itemsCount[i] != 0)
                {
                    // �������� ������ 99���� ������
                    // ������ 99�̻��� �Ǹ� ������ 99�� ����� ����ִ� ���Կ� 99�̻��� �� - 99�� �ؼ� �ٸ� �� ���Կ� �־��ش�.
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
                        // �ش� �ε����� ī��Ʈ�� �����ش�.
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
                        // ó�� ������ -1(�� ����)�� �������� ������ �ִ´�.
                        for (int j = 0; j < itemsIndex.Count; j++)
                        {
                            if (itemsIndex[j] == -1 || itemsCount[j] == 0) // �� ����
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

        // ���� �� �� �������� ����� ��
        // �ε����� -1�� ���� ���� �������� �ִ´�.
        for (int i = 0; i < itemsIndex.Count; i++)
        {
            // -1�̸�
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
                    // �ε����� ���� �ε����� �ٲ��ְ�
                    // ī��Ʈ�� �ٲ��ְ�
                    // �̹����� �ٲ��ش�.
                }*/

            }
        }

        // ���ο� �������� ������ ��� �߰��ϴ� ��
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

