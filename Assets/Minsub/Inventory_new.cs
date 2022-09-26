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
        /*Debug.Log("������ ����");
        Debug.Log(recipe.itemRecipe_dic.Keys.ElementAt(0));
        Debug.Log(recipe.itemRecipe_dic["���� ����"][0]);
        Debug.Log(recipe.itemRecipe_dic["���� ����"][1]);
        Debug.Log(recipe.itemRecipe_dic["���� ����"][2]);
        Debug.Log(recipe.itemRecipe_dic["���� ����"][3]);
        Debug.Log(recipe.itemRecipe_dic["���� ����"][4]);*/
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
            } // �ش� �������� ������ �����ϸ� true�� ���巯 �ش�.
            
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
            }  // �ε����� ����ְų� -1�̰� ī��Ʈ�� ��� ���� �ϋ�,
            if (itemsCount[i] < 2)
            {
                Debug.Log("3");
                lackOfMaterial = true;
                lackOfMaterials();
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
                    Debug.Log("ī��Ʈ�� 0��");
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
                    Debug.Log("ī��Ʈ�� 0��");
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
                    Debug.Log("ī��Ʈ�� 0��");
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

    public bool AddItem(int _itemIndex, int _itemCount, Sprite _itemImage)
    {
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
                    if (itemsCount[i] < 99)
                    {
                        // �ش� �ε����� ī��Ʈ�� �����ش�.
                        itemsCount[i] += _itemCount;
                        Debug.Log("���� �ִ�2");
                        Debug.Log(itemsCount[i]);
                        inventory_ui.RedrawCountSlotUI(i);
                        return true;
                    }
                }
            }
        }

        // �ε����� -1�� ���� ���� �������� �ִ´�.
        for (int i = 0; i < itemsIndex.Count; i++)
        {
            // -1�̸�
            if (itemsIndex[i] == -1)
            {
                Debug.Log("���� �ִ�1");
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

        if (itemsIndex.Count < SlotCnt)
        {
            Debug.Log("���� �ִ�3");
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

