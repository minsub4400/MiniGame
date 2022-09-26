using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory_new : MonoBehaviour
{
    private ItemRecipeDataBase recipe;

    // �������� �ε����� ������ ����Ʈ
    public List<int> itemsIndex = new List<int>();
    // �������� ������ ������ ����Ʈ
    public List<int> itemsCount = new List<int>();
    // �������� �̹����� ������ ����Ʈ
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

        for (int i = 0; i < itemsIndex.Count; i++) // ����Ʈ�� ���� ��ŭ �ݺ��Ѵ�
        {   // 1. �ε������� ���縦 ã�´�.
            if (itemsIndex[i] == 1)
            {
                // ���簡 ������ ������ 1�̻� �ִ��� Ȯ���Ѵ�.
                if (itemsCount[i] >= 1)
                {
                    // �ִٸ� 1�� �������ش�.
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
        for (int i = 0; i < itemsIndex.Count; i++) // ����Ʈ�� ���� ��ŭ �ݺ��Ѵ�
        {
            if (itemsIndex[i] == 3)
            {    // ������ ������ 1�̻� �ִ��� Ȯ���Ѵ�.
                if (itemsCount[i] >= 1)
                {
                    // �ִٸ� 1�� �������ش�.
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
        for (int i = 0; i < itemsIndex.Count; i++) // ����Ʈ�� ���� ��ŭ �ݺ��Ѵ�
        {
            if (itemsIndex[i] == 2)
            {    //������ ������ ã�´�. ������ 1�̻����� Ȯ���Ѵ�.
                if (itemsCount[i] >= 1)
                {
                    // �ִٸ� 1�� �������ش�.
                    HaveARecipeItems();
                    //itemsCount[i] -= 1;
                    //Debug.Log("���� ���� �մϴ�.");
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
            }
            else if (itemsIndex[i] == 3)
            {    // ������ ������ 1�̻� �ִ��� Ȯ���Ѵ�.
                if (itemsCount[i] >= 1)
                {
                    // �ִٸ� 1�� �������ش�.
                    itemsCount[i] -= 1;
                }
            }
            else if (itemsIndex[i] == 2)
            {    //������ ������ ã�´�. ������ 1�̻����� Ȯ���Ѵ�.
                if (itemsCount[i] >= 1)
                {
                    // �ִٸ� 1�� �������ش�.
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
        {    // ī��Ʈ�� 0�� �ε����� ã��
            if (itemsCount[i] == 0)
            {
                itemsIndex.RemoveAt(i); //�ε����� ����ش�.
                itemsImage.RemoveAt(i); //�̹����� ����ش�.
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
            if (itemsIndex[i] == _itemIndex)
            {
                // �������� ������ 0�� �ƴϰ�
                if (itemsCount[i] != 0)
                {
                    // �������� ������ 99���� ������
                    if (itemsCount[i] < 99)
                    {
                        // �ش� �ε����� ī��Ʈ�� �����ش�.
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
