using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInventorySlot : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Item item;
    [SerializeField]
    private GameObject selectedItemPrefab;
    private GameObject selectedItem;

    private Vector3 basePosition;
    private bool isBeingDragged = false;

    private Image spriteImage;
    // Start is called before the first frame update
    void Awake()
    {
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
            isBeingDragged = true;
            selectedItem = Instantiate(selectedItemPrefab, transform, true);
            selectedItem.GetComponent<UISelectedItem>().UpdateItem(item);
            selectedItem.transform.position = Input.mousePosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (selectedItem != null)
        {
            isBeingDragged = false;
            Destroy(selectedItem);
            selectedItem = null;
        }
    }
}
