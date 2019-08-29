using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeElement : MonoBehaviour
{
    [SerializeField]
    private AnchorElement anchorPrefab = null;

    private bool hasInitialized = false;

    private void Start()
    {
        Initialize(new StartNode());
    }
    public void Initialize(INode node)
    {
        if (hasInitialized)
            throw new System.InvalidOperationException("Node has already been initialized");

        hasInitialized = true;

        SetPosition(node.Position);

        if (node is INodeInputHandler inputHandler)
            HandleInputSockets(inputHandler);

        if (node is INodeOutputHandler outputHandler)
            HandleOutputSockets(outputHandler);
    }
    private void SetPosition(Vector2 position)
    {
        ((RectTransform)transform).anchoredPosition = position;
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
