using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Based on giacomelli's answer here:
//https://stackoverflow.com/questions/56498130/how-can-i-make-a-button-to-act-like-a-toggle-or-maybe-using-a-toggle-and-make-th

public class ToggleGroup : MonoBehaviour
{

    public ToggleGroupEvent onItemToggle = new ToggleGroupEvent();

    private List<ToggleButton> toggleButtons;

    private int toggledIdx = -1;


    // Start is called before the first frame update
    void Awake()
    {
        if (toggleButtons == null)
            toggleButtons = new List<ToggleButton>(transform.GetComponentsInChildren<ToggleButton>());

        for (int i = 0; i < toggleButtons.Count; i++)
        {
            int contextI = i;
            toggleButtons[i].onToggleEvent.AddListener((bool newVal) => OnItemToggled(contextI, newVal));
        }
    }

    public void RegisterButton(GameObject buttonGo)
    {
        ToggleButton toggle = buttonGo.GetComponent<ToggleButton>();

        if (toggle == null)
        {
            Debug.LogError("ToggleButton component not found on gameobject", buttonGo);
            return;
        }

        RegisterButton(toggle);
    }

    public void RegisterButton(ToggleButton toggle)
    {
        if (toggleButtons == null) toggleButtons = new List<ToggleButton>();

        toggleButtons.Add(toggle);
        int idx = toggleButtons.Count - 1;
        toggle.onToggleEvent.AddListener((bool newVal) => OnItemToggled(idx, newVal));
    }

    private void OnItemToggled(int buttonIdx, bool newVal)
    {
        if (newVal)
        {
            toggledIdx = buttonIdx;

            for (int i = 0; i < toggleButtons.Count; i++)
            {
                if (i != buttonIdx)
                {
                    toggleButtons[i].Toggled = false;
                }
            }
        }
        //Toggled button was untoggled
        else if (buttonIdx == toggledIdx)
        {
            toggledIdx = -1;
        }


        onItemToggle.Invoke(toggledIdx);
    }

    public void SetToggled(int idx)
    {
        toggleButtons[idx].Toggled = true;
    }

    [System.Serializable]
    public class ToggleGroupEvent : UnityEvent<int> {}


}
