using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class UIInventorySlot : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Item item;
    [SerializeField]
    private GameObject selectedItemPrefab;
    private GameObject selectedItem;
    private CanvasGroup inventoryCanvasGroup;

    private Vector3 basePosition;

    private Image spriteImage;
    // Start is called before the first frame update
    void Awake()
    {
        inventoryCanvasGroup = GameObject.Find("InventoryPanel").GetComponent<CanvasGroup>();
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
    }

    void Start()
    {

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

            Debug.Log(dropSlot);
            if (dropSlot != null)
            {
                dropSlot.UpdateItem(item);
                UpdateItem(null);
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

        GameObject[] dropSlotArr = UIInventorySlots.Where(slot => {
            return RectTransformUtility.RectangleContainsScreenPoint(slot.transform as RectTransform , mousePos);
        }).ToArray();
        GameObject? dropSlot = null;

        if (dropSlotArr.Count() > 0) {
            dropSlot = dropSlotArr[0];
        }

        return dropSlot == null ? null : dropSlot.GetComponent<UIInventorySlot>();
    }
}
