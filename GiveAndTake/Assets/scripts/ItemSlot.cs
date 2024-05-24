using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public List<ItemSlot> childSlots = new List<ItemSlot>();
    public PuzzleVerification puzzleVerification; // Reference to PuzzleVerification
    public TrianglePuzzleVerify trianglePuzzleVerifier; // Reference to the TrianglePuzzleVerify
    AudioSource audioSource;
    public float slotValue;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            slotValue = eventData.pointerDrag.GetComponent<DragDrop>().value;
            Debug.Log($"{gameObject.name} slot value set to: {slotValue}");
            audioSource.Play();
            eventData.pointerDrag.GetComponent<DragDrop>().transform.parent = gameObject.transform;
            // Reset the rect of the object
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);

            // Notify the puzzle verification
            if(SceneManager.GetActiveScene().name == "MiniGame1"){
                puzzleVerification.CheckAllSlotsFilled(); // New method to check if all slots are filled
            }
            if(SceneManager.GetActiveScene().name == "MiniGame2"){
                trianglePuzzleVerifier.CheckAllSlotsFilled(); // New method to check if all slots are filled
            }
                
        }
    }
}
