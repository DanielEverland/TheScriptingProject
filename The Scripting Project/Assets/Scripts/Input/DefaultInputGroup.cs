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

    private IUIInputElement activeElement;

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

        if (activeElement != null)
        {
            HandleUIElement(activeElement);
        }
        else
        {
            PollNewActiveElement();
        }
    }
    private void PollNewActiveElement()
    {
        foreach (RaycastResult result in raycastResults)
        {
            IUIInputElement element = result.gameObject.GetComponent<IUIInputElement>();

            if (element != null)
            {
                HandleUIElement(element);
                break;
            }
        }
    }
    private void HandleUIElement(IUIInputElement element)
    {
        if(activeElement != null)
        {
            activeElement.UpdateUIElement();

            if (activeElement.ShouldDisable())
                DisableActiveElement();
        }
        else
        {
            PollEnableElement(element);
        }
    }
    private void PollEnableElement(IUIInputElement element)
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            EnableElement(element);
        }
    }
    private void EnableElement(IUIInputElement element)
    {
        activeElement = element;

        if (activeElement is IUIInputEnableCallback enableCallbackHandler)
            enableCallbackHandler.OnUIElementEnabled();
    }
    private void DisableActiveElement()
    {
        if (activeElement is IUIInputDisableCallback disableCallbackHandler)
            disableCallbackHandler.OnUIElementDisabled();
        
        activeElement = null;
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
