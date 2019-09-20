using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeElement : MonoBehaviour, IUIInputElement, IUIInputEnableCallback
{
    public RectTransform rectTransform => (RectTransform)transform;

    [SerializeField]
    private AnchorElement anchorPrefab = null;

    private bool hasInitialized = false;
    private INode node = null;
    private Vector2 previousMousePosition = Vector2.zero;

    public void Initialize(INode node)
    {
        if (hasInitialized)
            throw new System.InvalidOperationException("Node has already been initialized");

        hasInitialized = true;
        this.node = node;

        SetName(node.GetType());
        SetScreenPosition(node.Position);
        SetSize(node.Size);

        if (node is INodeInputHandler inputHandler)
            HandleInputSockets(inputHandler);

        if (node is INodeOutputHandler outputHandler)
            HandleOutputSockets(outputHandler);
    }

    public void UpdateUIElement()
    {
        Vector2 mouseDelta = (Vector2)Input.mousePosition - previousMousePosition;

        node.Position += mouseDelta / GraphUtility.NodeUnitInPixels;
        SetScreenPosition(node.Position);

        previousMousePosition = Input.mousePosition;
    }

    public bool ShouldDisable()
    {
        return !Input.GetKey(KeyCode.Mouse0);
    }

    public void OnUIElementEnabled()
    {
        previousMousePosition = Input.mousePosition;
    }

    private void SetSize(Vector2 size)
    {
        RectTransform rectTrans = (RectTransform)transform;

        rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x * GraphUtility.NodeUnitInPixels);
        rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y * GraphUtility.NodeUnitInPixels);
    }
    private void SetName(System.Type nodeType)
    {
        name = $"Node ({nodeType.Name})";
    }
    private void SetScreenPosition(Vector2 position)
    {
        ((RectTransform)transform).anchoredPosition = position * GraphUtility.NodeUnitInPixels;
    }
    private void HandleInputSockets(INodeInputHandler inputHandler)
    {
        AnchorElement anchor = CreateAnchor(new Vector2(0, 0.5f));

        foreach (IDirectionalInputSocket socket in inputHandler.InputSockets)
        {
            anchor.AddSocket(socket);
        }
    }
    private void HandleOutputSockets(INodeOutputHandler outputHandler)
    {
        AnchorElement anchor = CreateAnchor(new Vector2(1, 0.5f));

        foreach (IDirectionalOutputSocket socket in outputHandler.OutputSockets)
        {
            anchor.AddSocket(socket);
        }
    }
    private AnchorElement CreateAnchor(Vector2 anchor)
    {
        AnchorElement anchorInstance = Instantiate(anchorPrefab);

        RectTransform rectTransform = (RectTransform)anchorInstance.transform;
        rectTransform.SetParent(transform);
        rectTransform.anchorMin = anchor;
        rectTransform.anchorMax = anchor;
        rectTransform.anchoredPosition = Vector3.zero;

        return anchorInstance;
    }
}
