using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DefaultInputGroup : MonoBehaviour, IInputGroup
{
    [SerializeField]
    private RectTransform highlighterPrefab;

    private EventSystem eventSystem;
    private PointerEventData pointer;
    private List<RaycastResult> raycastResults;
    private RectTransform highlighter;

    private void Awake()
    {
        eventSystem = EventSystem.current;
        pointer = new PointerEventData(eventSystem);
        raycastResults = new List<RaycastResult>();

        highlighter = Instantiate(highlighterPrefab);
    }
    public void PollInput()
    {
        HideHighlighter();
        SetPointerData();
        DoRaycast();

        foreach (RaycastResult result in raycastResults)
        {
            IUIInputElement element = result.gameObject.GetComponent<IUIInputElement>();

            if (element != null)
            {
                HighlightUIElement(element);
                break;
            }                
        }
    }
    private void HighlightUIElement(IUIInputElement element)
    {
        highlighter.localScale = Vector3.one;

        highlighter.SetParent(element.rectTransform);
        highlighter.anchoredPosition = Vector3.zero;
        highlighter.sizeDelta = Vector3.zero;
    }
    private void HideHighlighter()
    {
        highlighter.localScale = Vector3.zero;
        highlighter.SetParent(null);

        highlighter.anchorMin = Vector2.zero;
        highlighter.anchorMax = Vector2.one;
    }
    private void SetPointerData()
    {
        pointer.position = Input.mousePosition;
    }
    private void DoRaycast()
    {
        EventSystem.current.RaycastAll(pointer, raycastResults);
    }
}
