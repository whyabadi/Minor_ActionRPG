using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

namespace Harvesting
{
    public class PlayerSFXController : CharacterSFXController, IPlayerSFXController
    {
        public new IPlayerCore Core { get; protected set; }

        [EventRef, SerializeField]
        public string FootStepsSound = default;
        [EventRef, SerializeField]
        public string ItemPickupSound = default;
        private FMOD.Studio.EventInstance footstepSoundEvent;
        private FMOD.Studio.EventInstance itemPickupSoundEvent;



        void Update()
        {
            if (Core.MovementController.IsRunning())
            {
                footstepSoundEvent.setVolume(1f);
            }
            else
            {
                footstepSoundEvent.setVolume(0f);
            }
        }

        private void InitializeSFX()
        {
            footstepSoundEvent = RuntimeManager.CreateInstance(FootStepsSound);
            itemPickupSoundEvent = RuntimeManager.CreateInstance(ItemPickupSound);
            footstepSoundEvent.start();

        }

        public void PlayItemSound()
        {
            itemPickupSoundEvent.start();
        }

        public void Initialize(IPlayerCore core)
        {
            Core = core;
            if (Core == null) print("Player Core is NULL!!!!!!");
            //InitializeSFX();
            footstepSoundEvent = RuntimeManager.CreateInstance(FootStepsSound);
            itemPickupSoundEvent = RuntimeManager.CreateInstance(ItemPickupSound);
            // FMODUnity.RuntimeManager.AttachInstanceToGameObject(sound, gameObject.transform);
            footstepSoundEvent.start();
        }
    }
}