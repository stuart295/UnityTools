using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace StuTools
{
    //Based on giacomelli's answer here:
    //https://stackoverflow.com/questions/56498130/how-can-i-make-a-button-to-act-like-a-toggle-or-maybe-using-a-toggle-and-make-th

    [RequireComponent(typeof(Image))]
    public class ToggleButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {

        public Color normalColor = Color.white;
        public Color toggledColor = Color.blue;
        public Color hoverToggledColor = Color.gray;
        public Color hoverNormalColor = Color.gray;
        public Color disabledColor = Color.black;

        [SerializeField]
        private bool toggled = false;
        public bool canUntoggle = false;

        [SerializeField]
        private bool interactable = true;

        public ToggleEvent onToggleEvent = new ToggleEvent();

        private Image image;
        private bool hovering = false;



        public bool Toggled
        {
            get => toggled;
            set
            {
                if (toggled != value && interactable)
                {
                    toggled = value;
                    UpdateVisual();
                    onToggleEvent.Invoke(toggled);
                }
            }
        }

        public bool Interactable
        {
            get => interactable;
            set
            {
                if (interactable == value) return;
                interactable = value;
                UpdateVisual();
            }
        }


        // Start is called before the first frame update
        void Awake()
        {
            image = GetComponent<Image>();
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (!interactable)
            {
                image.color = disabledColor;
                return;
            }

            if (hovering)
            {
                if (toggled)
                {
                    image.color = hoverToggledColor;
                }
                else
                {
                    image.color = hoverNormalColor;
                }
            }
            else
            {
                if (toggled)
                {
                    image.color = toggledColor;
                }
                else
                {
                    image.color = normalColor;
                }
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!interactable) return;
            if (Toggled && !canUntoggle) return;
            Toggled = !Toggled;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!interactable) return;
            hovering = true;
            UpdateVisual();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!interactable) return;
            hovering = false;
            UpdateVisual();
        }

        [System.Serializable]
        public class ToggleEvent : UnityEvent<bool> { }

    }
}