using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public List<ItemSlot> childSlots = new List<ItemSlot>();
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            slotValue = eventData.pointerDrag.GetComponent<DragDrop>().value;
            Debug.Log(slotValue);
            audioSource.Play();


        }
    }




    public float detectionRadius = 10f;
    public float slotValue;

    

    // Get the value of the coin placed in this slot
    public float CoinValue()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Coin"))
            {
                DragDrop coinComponent = collider.GetComponent<DragDrop>();
                if (coinComponent != null)
                {
                    Debug.Log(coinComponent.value);
                    return coinComponent.value;

                }
            }
        }
        Debug.Log("nao entrou");
        return 0; // Return 0 if no coin is found within the detection radius
    }

    // Get the expected value for this slot based on child slots
    
}
