using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputActionRebindingExtensions;

public class InputHandler : MonoBehaviour
{
    public InputActionAsset actionAsset;
    public GameObject buttonPrefab;
    public Transform buttonParent;

    private Dictionary<string, ActionButton> actionButtons = new Dictionary<string, ActionButton>();
    public class ActionButton
    {
        public string actionMapName;
        public string actionName;
        public string fullActionName;
        public string keyName;
        public InputAction action;
        public GameObject button;
    }

    private void Start()
    {
        InitDictionaryActionButton();
        UpdateButtonsDisplay();
    }

    private void InitDictionaryActionButton()
    {
        foreach (var action in actionAsset)
        {
            ActionButton actionButton = new ActionButton();

            var button = Instantiate(buttonPrefab, buttonParent);

            actionButton.actionMapName = action.actionMap.name;
            actionButton.fullActionName = action.actionMap.name + "/" + action.name;
            actionButton.actionName = action.name;
            actionButton.keyName = InputControlPath.ToHumanReadableString(action.bindings[0].effectivePath);

            actionButton.action = action;
            actionButton.button = button;
            actionButton.button.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => StartRebindingProcess(actionButton.fullActionName));

            actionButtons.Add(actionButton.fullActionName, actionButton);
        }
    }

    private void UpdateButtonsDisplay()
    {
        /* hierachy Action
            - Action (Empty object)
                - NameAction (Image)
                    - Text (TextMeshPro)
                - InputButton (Button)
                    - Text (TextMeshPro)
        */
        foreach (string name in actionButtons.Keys)
        {
            UpdateButtonDisplay(name);
        }
    }

    private void UpdateButtonDisplay(string actionName)
    {
        actionButtons[actionName].button.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = actionButtons[actionName].actionName;
        actionButtons[actionName].button.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = actionButtons[actionName].keyName;
    }

    private void StartRebindingProcess(string actionName)
    {
        actionButtons[actionName].action.Disable();

        var rebindingOperation = actionButtons[actionName].action.PerformInteractiveRebinding()
            .WithControlsExcluding("<Mouse>/position")
            .OnMatchWaitForAnother(0.1f)
            .Start();

        actionButtons[actionName].button.transform.GetChild(1).GetComponent<Button>().interactable = false;
        StartCoroutine(WaitForRebind(rebindingOperation, actionButtons[actionName]));
    }

    private IEnumerator WaitForRebind(RebindingOperation rebindingOperation, ActionButton actionButton)
    {
        yield return new WaitUntil(() => rebindingOperation.completed);

        actionButton.button.transform.GetChild(1).GetComponent<Button>().interactable = true;
        actionButton.keyName = InputControlPath.ToHumanReadableString(actionButton.action.bindings[0].effectivePath);
        UpdateButtonDisplay(actionButton.fullActionName);

        actionButton.action.Enable();
    }
}