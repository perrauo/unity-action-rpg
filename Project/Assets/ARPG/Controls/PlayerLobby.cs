using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityInputs = UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Controls;
using UnityEngine.Experimental.Input.LowLevel;
using UnityEngine.Experimental.Input.Plugins.Users;

// TODO

namespace Cirrus.ARPG.Playable.Controls
{
    public class PlayerLobby : MonoBehaviour
    {
        [SerializeField]
        private List<Player> _players;

        public void Awake()
        {
            InputUser.onUnpairedDeviceUsed += OnUnpairedInputDeviceUsed;
            // Have it let us know then the user setup in the system changes.
            InputUser.onChange += OnUserChange;
        }

        private void OnUserChange(InputUser user, InputUserChange change, UnityInputs.InputDevice device)
        {
            //var player = FindPlayerControllerForUser(user);
            //switch (change)
            //{
            //    // A player has switched accounts. This will only happen on platforms that have user account
            //    // management (PS4, Xbox, Switch). On PS4, for example, this can happen at any time by the
            //    // player pressing the PS4 button and switching accounts. We simply update the information
            //    // we display for the player's active user account.
            //    case InputUserChange.AccountChanged:
            //        {
            //            if (player != null)
            //                player.OnUserAccountChanged();
            //            break;
            //        }

            //    // If the user has cancelled account selection, we remove the user if there's no devices
            //    // already paired to it. This usually happens when a player initiates a join on a device on
            //    // Xbox or Switch, has the account picker come up, but then cancels instead of making an
            //    // account selection. In this case, we want to cancel the join.
            //    // NOTE: We are only adding DemoPlayerControllers once device pairing is complete
            //    case InputUserChange.AccountSelectionCancelled:
            //        {
            //            if (user.pairedDevices.Count == 0)
            //            {
            //                Debug.Assert(FindPlayerControllerForUser(user) == null);
            //                user.UnpairDevicesAndRemoveUser();
            //            }
            //            break;
            //        }

            //    // An InputUser gained a new device. If we're in the lobby and don't yet have a player
            //    // for the user, it means a new player has joined. We don't join players until they have
            //    // a device paired to them which is why we ignore InputUserChange.Added and only react
            //    // to InputUserChange.DevicePaired instead.
            //    case InputUserChange.DevicePaired:
            //        {
            //            if (state == State.InLobby && player == null)
            //            {
            //                OnPlayerJoins(user);
            //            }
            //            else if (player != null)
            //            {
            //                player.OnDevicesOrBindingsHaveChanged();
            //            }
            //            break;
            //        }

            //    // Some player ran out of battery or unplugged a wired device.
            //    case InputUserChange.DeviceLost:
            //        {
            //            Debug.Assert(player != null);
            //            player.OnDeviceLost();

            //            ////REVIEW: should we unjoin a user when losing devices in the lobby?
            //            ////TODO: we need a way for other players to be able to resolve the situation

            //            // If we're currently in-game, we pause the game until the player has re-gained control.
            //            if (isInGame)
            //                PauseGame();

            //            break;
            //        }

            //    // Some player has customized controls or had previously customized controls loaded.
            //    case InputUserChange.BindingsChanged:
            //        {
            //            player.OnDevicesOrBindingsHaveChanged();
            //            break;
            //        }
            //}
        }

        private void OnUnpairedInputDeviceUsed(InputControl obj)
        {
           
        }


        public void OnPlayerJoins(Player player)
        {
            
        }

   
    }
}