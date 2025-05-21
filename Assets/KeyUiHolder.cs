using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using System.Reflection;

public class KeyUiHolder : MonoBehaviour
{

    [SerializeField] private InventoryHolder inventoryHolder;
    private Transform container;
    private Transform template;

    private void Awake()
    {
        container = transform.Find("Container");
        template = container.Find("Template");
        template.gameObject.SetActive(false);
    }

    private void Start()
    {
        inventoryHolder.OnKeyChanged += InventoryHolder_OnKeyChanged;
    }

    private void InventoryHolder_OnKeyChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == template) continue;
            Destroy(child.gameObject);
        }
        List<Key.KeyColor> keyList = inventoryHolder.GetKeyList();
        for (int i = 0; i < keyList.Count; i++)
        {
            Key.KeyColor keyColor = keyList[i];
            Transform keyTransform = Instantiate(template, container);
            keyTransform.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * i, 0);
            UnityEngine.UI.Image keyImage = keyTransform.Find("Image").GetComponent<UnityEngine.UI.Image>();
            switch (keyColor)
            {
                default:
                case Key.KeyColor.Red: keyImage.color = Color.red; break;
                case Key.KeyColor.Green: keyImage.color = Color.green; break;
                case Key.KeyColor.Blue: keyImage.color = Color.blue; break;
            }
        }
    }


}
