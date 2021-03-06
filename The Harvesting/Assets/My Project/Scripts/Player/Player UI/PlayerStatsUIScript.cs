using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    public class PlayerStatsUIScript : MonoBehaviour
    {

        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Slider _manaSlider;
        public IPlayerCore PlayerCore { get; protected set; }
        public void UpdateHealthPercentage(float percentage)
        {
            _healthSlider.value = Mathf.Clamp(percentage, 0f, 1f);
        }

        public void UpdateManaPercentage(float percentage)
        {
            _manaSlider.value = Mathf.Clamp(percentage, 0f, 1f);
        }

        public void Update()
        {
            UpdateHealthPercentage(PlayerCore.CombatController.HealthPercentage());
            UpdateManaPercentage(PlayerCore.CombatController.ManaPercentage());
        }
        public void Initialize(IPlayerCore playerCore)
        {
            PlayerCore = playerCore;
        }
    }
}