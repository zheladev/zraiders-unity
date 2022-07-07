using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class UIInventorySlot : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int slotId { get; set; }
    public InventoryManager inventoryManager { get; set; }
    public Item item;
    [SerializeField]
    private GameObject selectedItemPrefab;
    private GameObject selectedItem;
    private CanvasGroup inventoryCanvasGroup;

    [SerializeField]
    private GameObject tooltipPrefab;
    private UITooltip tooltip;

    private Vector3 basePosition;

    private Image spriteImage;
    // Start is called before the first frame update
    void Awake()
    {
        inventoryCanvasGroup = GameObject.Find("InventoryPanel").GetComponent<CanvasGroup>();
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    // Update is called once per frame
    public void UpdateItem(Item i)
    {
        item = i;
        if (item == null)
        {
            spriteImage.color = Color.clear;
        }
        else
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = i.sprite;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (selectedItem != null)
        {
            selectedItem.transform.position = Input.mousePosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (item != null)
        {
            selectedItem = Instantiate(selectedItemPrefab, inventoryCanvasGroup.transform, false);
            selectedItem.transform.position = Input.mousePosition;
            selectedItem.GetComponent<UISelectedItem>().UpdateItem(item);
            selectedItem.GetComponent<UISelectedItem>().selectedItemUIInventorySlot = this;

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (selectedItem != null)
        {
            UISelectedItem selectedItemUIComponent = selectedItem.GetComponent<UISelectedItem>();

            UIInventorySlot dropSlot = GetDropSlot();

            //check dropSlot exists and it's not self
            if (dropSlot != null && dropSlot.slotId != slotId)
            {
                //check if dropSlot is holding an item already
                if (dropSlot.item == null)
                {
                    //move item if dropSlot doesn't hold an item
                    inventoryManager.AddItem(item, dropSlot.slotId);
                    dropSlot.UpdateItem(item);
                    inventoryManager.RemoveItem(slotId);
                    UpdateItem(null);
                }
                else
                {
                    //swap items if dropSlot already holds an item
                    Item temp = item;
                    UpdateItem(dropSlot.item);
                    inventoryManager.AddItem(dropSlot.item, slotId);

                    dropSlot.UpdateItem(temp);
                    inventoryManager.AddItem(temp, dropSlot.slotId);
                }
            }

            Destroy(selectedItem);
            selectedItem = null;
        }
    }

#nullable enable
    private UIInventorySlot? GetDropSlot()
    {
        Vector3 mousePos = Input.mousePosition;
        GameObject[] UIInventorySlots = GameObject.FindGameObjectsWithTag("UIInventorySlot").ToArray();

        GameObject[] dropSlotArr = UIInventorySlots.Where(slot =>
        {
            return RectTransformUtility.RectangleContainsScreenPoint(slot.transform as RectTransform, mousePos);
        }).ToArray();
        GameObject? dropSlot = null;

        if (dropSlotArr.Count() > 0)
        {
            dropSlot = dropSlotArr[0];
        }

        return dropSlot == null ? null : dropSlot.GetComponent<UIInventorySlot>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // if (item != null)
        // {
        //     tooltip = Instantiate(tooltipPrefab, inventoryCanvasGroup.transform, true).GetComponent<UITooltip>();
        //     tooltip.Show(item);
        // }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Destroy(tooltip);
        // tooltip = null;
    }
}
