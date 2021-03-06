using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Harvesting
{
    public class ItemGroundPrefab : MonoBehaviour
    {
        public TMP_Text TextUI;
        public GameItem Item;
        public Vector3 WorldPosition;
        // Start is called before the first frame update
        void Start()
        {
           /* if(Item != null)
            {
                if (Item.Template().ItemData.UnidentifiedName != "")
                {
                    TextUI.SetText(Item.Template().ItemData.UnidentifiedName);
                } else
                {
                    TextUI.SetText(Item.Name);
                }

                TextUI.color = Item.Template().Quality.Color;
            }
            MaintainPosition();*/
        }

        // Update is called once per frame
        void Update()
        {
            MaintainPosition();
        }

        public void MaintainPosition()
        {
            transform.position = Camera.main.WorldToScreenPoint(WorldPosition);
        }

        public bool PickUp(IPlayerCore playerCore)
        {
            /*if (playerCore.Inventory.AddItem(Item, 1) != -1)
            {
                Debug.Log("INVENTORY ADD IS FINE");
                if (Vector3.Distance(playerCore.transform.position, WorldPosition) < 2f)
                {

                    Destroy(gameObject);
                    return true;
                }
            }
            */
            return false;
        }
    }
}