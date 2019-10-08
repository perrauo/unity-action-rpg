// GENERATED AUTOMATICALLY FROM 'Assets/ARPG/Controls/ActionMap.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Cirrus.ARPG.Controls
{
    public class ActionMap : IInputActionCollection
    {
        private InputActionAsset asset;
        public ActionMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActionMap"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""5a4fd1b2-e70c-427f-a1b7-79b5f97d74e7"",
            ""actions"": [
                {
                    ""name"": ""Axes.Left"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5e12d1fb-9937-4b77-b795-65b2dfaa90c8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Axes.Right"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0dfcefc2-41aa-46ea-a723-ba939cef3db5"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cursor.Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e60a99b2-0c77-4a5e-9605-6d36e422692a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cursor.Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""30a9b19a-4391-4d42-a39d-fad577499937"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cursor.Hold"",
                    ""type"": ""PassThrough"",
                    ""id"": ""60a34aaa-3c81-48db-923e-9e8dd8943980"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu.Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""053f28bb-b91f-4675-b27d-d68e8865b916"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu.Swap"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c9963b29-0b51-4df8-9105-3ff59883b948"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Menu.Toggle"",
                    ""type"": ""PassThrough"",
                    ""id"": ""faa0bd53-a2d0-4d73-a9ae-e0879a8ceaf6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f211a626-d2b6-4091-aac9-3e3a798b3c1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action1"",
                    ""type"": ""Button"",
                    ""id"": ""79b09fa4-905e-4d03-821c-d38643942771"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Action2"",
                    ""type"": ""Button"",
                    ""id"": ""c4a8890c-c800-4e47-9e87-b46aaa58eadc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Action3"",
                    ""type"": ""Button"",
                    ""id"": ""c915373f-44b4-4a1a-8fd6-c4c06c37d096"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Action4"",
                    ""type"": ""Button"",
                    ""id"": ""7fe622f4-5dbf-4021-b9a9-1e0eb40e9bcd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Action5"",
                    ""type"": ""Button"",
                    ""id"": ""68b2b5f8-9c76-4a78-89e4-13a439254810"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Action6"",
                    ""type"": ""Button"",
                    ""id"": ""cc0057ff-dbf4-45a8-8b5c-06c4699802a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Action7"",
                    ""type"": ""Button"",
                    ""id"": ""847594f4-5467-434e-88e4-c6a68f361156"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Action8"",
                    ""type"": ""Button"",
                    ""id"": ""79ff5d5b-170a-4d07-8797-b6f1f01c233b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Action9"",
                    ""type"": ""Button"",
                    ""id"": ""9a6e6ee5-ae2c-4ebf-b335-ac959b28c988"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Action0"",
                    ""type"": ""Button"",
                    ""id"": ""728166d8-8edb-4938-9456-5d9450bc7aa9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""HotBar.Cycle.Left"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5cc17350-5005-49bf-beb7-4938abdf8725"",
                    ""expectedControlType"": ""DiscreteButton"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""HotBar.Cycle.Right"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a713fc00-63e8-4dc1-a0de-1fa627cc7ad0"",
                    ""expectedControlType"": ""DiscreteButton"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Focus"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fb924c67-040c-4c8b-848a-549988230b69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press,Press(behavior=1)""
                },
                {
                    ""name"": ""HotBar.Action.Current"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fa669f80-65d0-40b7-8fab-ba17d30b2a54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""GamePad.DPad"",
                    ""id"": ""5518da00-95cc-4cd9-940c-f76fcad66877"",
                    ""path"": ""2DVector(normalize=false)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""e4826a66-087e-4d0d-a933-85264a849240"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""6476f200-7763-4044-b8a0-c9d9c1d53d38"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""0d9a88f5-062a-4b87-8248-1d25e2eb3bda"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""8fe07b50-0351-49f3-8495-8b57917c543c"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyBoard.WASD"",
                    ""id"": ""e3171d7d-d661-46d4-96f6-8eb269af513e"",
                    ""path"": ""2DVector(normalize=false)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""64d1d9ce-2e1f-4162-a9d9-2ad9900a8659"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""32328328-e538-469c-8fc2-695f17ec5561"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""9d92bb92-bed6-4668-a4e9-24ca504cddc6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""376509f4-5892-4f54-a3ef-3dd31738952a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyBoard.Arrows"",
                    ""id"": ""08bf490a-4afa-4238-9a09-9ba0518a6a71"",
                    ""path"": ""2DVector(normalize=false)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""ec8c15d8-05f0-4bc4-8c9f-af0e1eb06b9e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""c9f21e48-4f70-45a2-9d06-923a5595ca9b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""d4b57d90-d0c4-44ae-9865-721a3bf6769e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""0644c833-b507-4b94-872a-c6ca044377ef"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c89dda3d-2925-4c4d-bb42-dab744da0e6e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0b89e7e-b27d-44fa-acb0-7860fcdb0c85"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f45719e-614e-48b8-b1d3-28dc6769a870"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da441c85-22e3-45cc-908f-f0f4ff17f0dd"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15c3012d-c593-457d-91b9-529f4488c53a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40ce9e9b-2c5c-4d09-8243-87804e74d9a2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Swap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1344f4ef-fa4e-41f0-be3b-5c9d70c1d87f"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9646d309-50ae-4743-96bc-78791a32eab6"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""289e573c-01c2-42c0-9dfa-c249bdbca2ac"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1843fb8-339c-4d44-bd78-316a8050aa3a"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""580c5dc3-aba9-4391-969a-557269b9345c"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""316413b6-19ce-4e2d-958e-a77c959ddbb6"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""745f365c-5809-4546-ba5c-a64e343f95d4"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""248bccfd-c92c-4c9e-9746-55639ca140cc"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54d0b043-9e76-4070-a4a7-a0009940ff74"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action9"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""254e043b-6f8b-4a64-9c46-8a0d1b34b530"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""caac8045-fb89-47ce-b6ed-72a241a330fa"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Toggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""243ea465-002c-4b82-9ed8-025f41447a87"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Toggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aab75639-3f0d-4f59-8905-5d80675a70b7"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Axes.Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c23a1fd4-aac3-4ad6-ba63-f9789760fb8b"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Focus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf08bcc1-c55f-478e-9199-1c5529f8cbc9"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Focus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f9c496f-b2df-4ad5-87df-bafd34c201ea"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Focus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fc1cd59-efee-41d9-86bf-e4c06ead9020"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Focus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8939799-8e6b-4bea-8914-f6f04de0a925"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Focus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08e4353c-003b-4194-a5a3-7ba700c2a40a"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Focus"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""268e7ee5-7b94-4748-a1f0-d06b5bd958d1"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotBar.Cycle.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""849c3d23-8366-4cbc-acb7-34b2eada8797"",
                    ""path"": ""<Keyboard>/numpadMinus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotBar.Cycle.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2eb9b46-a1fd-415a-898c-66214ea33e8e"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotBar.Cycle.Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20b90f68-8ff4-4dc4-9ef3-8c1f7e48864d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotBar.Cycle.Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ceabc5f5-a1f9-4671-bf29-effe172cc425"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotBar.Cycle.Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""271cbeb2-c43d-4fd9-9b70-813cb8b78e50"",
                    ""path"": ""<Keyboard>/equals"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotBar.Cycle.Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61e76ce5-ca33-4912-a27e-643293bcc8f5"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotBar.Action.Current"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""035b04a8-9b0c-40e8-b192-ad67bcda38dd"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotBar.Action.Current"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1c7bf44-5639-454f-ad62-614ab229d0d3"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03146bf1-dcc4-4379-9b40-6300cee3c5ee"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor.Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0780ff72-ee8d-446f-814e-15a6545025c7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor.Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""GamePad.DPad"",
                    ""id"": ""e96c57f4-940f-4c97-8391-9da3bc46af8f"",
                    ""path"": ""2DVector(normalize=false)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""1aad66c0-3aad-42fb-9f00-5ab9b03fc160"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""9589470c-a486-48aa-b4b0-808f0ffe2d06"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""affe231d-1fde-4a3b-8028-5c85dca8e743"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""d1b04f61-4d6a-452a-8273-a74c01b38138"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyBoard.WASD"",
                    ""id"": ""22faf7bc-29f5-4e22-b908-4458e84ad964"",
                    ""path"": ""2DVector(normalize=false)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""cf8f5361-f2b3-44aa-8a80-65aac8a88780"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""c1a1d978-f35a-4e65-81c3-09aed2b1d474"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""f93f75dc-1df8-49cb-b634-5407de40f7d7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""415012b0-5e2c-4335-a91f-238005c460dd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyBoard.Arrows"",
                    ""id"": ""54ff7ee3-0805-4727-9898-7963ce4401b9"",
                    ""path"": ""2DVector(normalize=false)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""10ec7742-bbba-4274-8404-2b68bd2e3924"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""e7629545-6b49-4297-9684-b7fca723f228"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""0d95e354-60d9-4bfc-8ffe-63dbc786fea4"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""70ba28f1-79e5-427b-8355-fea8953ed68c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d04ca8a0-adc0-4d09-b935-2d2f79bca2dd"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu.Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player
            m_Player = asset.GetActionMap("Player");
            m_Player_AxesLeft = m_Player.GetAction("Axes.Left");
            m_Player_AxesRight = m_Player.GetAction("Axes.Right");
            m_Player_CursorMove = m_Player.GetAction("Cursor.Move");
            m_Player_CursorClick = m_Player.GetAction("Cursor.Click");
            m_Player_CursorHold = m_Player.GetAction("Cursor.Hold");
            m_Player_MenuMove = m_Player.GetAction("Menu.Move");
            m_Player_MenuSwap = m_Player.GetAction("Menu.Swap");
            m_Player_MenuToggle = m_Player.GetAction("Menu.Toggle");
            m_Player_Jump = m_Player.GetAction("Jump");
            m_Player_Action1 = m_Player.GetAction("Action1");
            m_Player_Action2 = m_Player.GetAction("Action2");
            m_Player_Action3 = m_Player.GetAction("Action3");
            m_Player_Action4 = m_Player.GetAction("Action4");
            m_Player_Action5 = m_Player.GetAction("Action5");
            m_Player_Action6 = m_Player.GetAction("Action6");
            m_Player_Action7 = m_Player.GetAction("Action7");
            m_Player_Action8 = m_Player.GetAction("Action8");
            m_Player_Action9 = m_Player.GetAction("Action9");
            m_Player_Action0 = m_Player.GetAction("Action0");
            m_Player_HotBarCycleLeft = m_Player.GetAction("HotBar.Cycle.Left");
            m_Player_HotBarCycleRight = m_Player.GetAction("HotBar.Cycle.Right");
            m_Player_Focus = m_Player.GetAction("Focus");
            m_Player_HotBarActionCurrent = m_Player.GetAction("HotBar.Action.Current");
        }

        ~ActionMap()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_AxesLeft;
        private readonly InputAction m_Player_AxesRight;
        private readonly InputAction m_Player_CursorMove;
        private readonly InputAction m_Player_CursorClick;
        private readonly InputAction m_Player_CursorHold;
        private readonly InputAction m_Player_MenuMove;
        private readonly InputAction m_Player_MenuSwap;
        private readonly InputAction m_Player_MenuToggle;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_Action1;
        private readonly InputAction m_Player_Action2;
        private readonly InputAction m_Player_Action3;
        private readonly InputAction m_Player_Action4;
        private readonly InputAction m_Player_Action5;
        private readonly InputAction m_Player_Action6;
        private readonly InputAction m_Player_Action7;
        private readonly InputAction m_Player_Action8;
        private readonly InputAction m_Player_Action9;
        private readonly InputAction m_Player_Action0;
        private readonly InputAction m_Player_HotBarCycleLeft;
        private readonly InputAction m_Player_HotBarCycleRight;
        private readonly InputAction m_Player_Focus;
        private readonly InputAction m_Player_HotBarActionCurrent;
        public struct PlayerActions
        {
            private ActionMap m_Wrapper;
            public PlayerActions(ActionMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @AxesLeft => m_Wrapper.m_Player_AxesLeft;
            public InputAction @AxesRight => m_Wrapper.m_Player_AxesRight;
            public InputAction @CursorMove => m_Wrapper.m_Player_CursorMove;
            public InputAction @CursorClick => m_Wrapper.m_Player_CursorClick;
            public InputAction @CursorHold => m_Wrapper.m_Player_CursorHold;
            public InputAction @MenuMove => m_Wrapper.m_Player_MenuMove;
            public InputAction @MenuSwap => m_Wrapper.m_Player_MenuSwap;
            public InputAction @MenuToggle => m_Wrapper.m_Player_MenuToggle;
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @Action1 => m_Wrapper.m_Player_Action1;
            public InputAction @Action2 => m_Wrapper.m_Player_Action2;
            public InputAction @Action3 => m_Wrapper.m_Player_Action3;
            public InputAction @Action4 => m_Wrapper.m_Player_Action4;
            public InputAction @Action5 => m_Wrapper.m_Player_Action5;
            public InputAction @Action6 => m_Wrapper.m_Player_Action6;
            public InputAction @Action7 => m_Wrapper.m_Player_Action7;
            public InputAction @Action8 => m_Wrapper.m_Player_Action8;
            public InputAction @Action9 => m_Wrapper.m_Player_Action9;
            public InputAction @Action0 => m_Wrapper.m_Player_Action0;
            public InputAction @HotBarCycleLeft => m_Wrapper.m_Player_HotBarCycleLeft;
            public InputAction @HotBarCycleRight => m_Wrapper.m_Player_HotBarCycleRight;
            public InputAction @Focus => m_Wrapper.m_Player_Focus;
            public InputAction @HotBarActionCurrent => m_Wrapper.m_Player_HotBarActionCurrent;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    AxesLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAxesLeft;
                    AxesLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAxesLeft;
                    AxesLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAxesLeft;
                    AxesRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAxesRight;
                    AxesRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAxesRight;
                    AxesRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAxesRight;
                    CursorMove.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorMove;
                    CursorMove.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorMove;
                    CursorMove.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorMove;
                    CursorClick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorClick;
                    CursorClick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorClick;
                    CursorClick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorClick;
                    CursorHold.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorHold;
                    CursorHold.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorHold;
                    CursorHold.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCursorHold;
                    MenuMove.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuMove;
                    MenuMove.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuMove;
                    MenuMove.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuMove;
                    MenuSwap.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuSwap;
                    MenuSwap.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuSwap;
                    MenuSwap.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuSwap;
                    MenuToggle.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuToggle;
                    MenuToggle.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuToggle;
                    MenuToggle.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuToggle;
                    Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    Action1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction1;
                    Action1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction1;
                    Action1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction1;
                    Action2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction2;
                    Action2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction2;
                    Action2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction2;
                    Action3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction3;
                    Action3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction3;
                    Action3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction3;
                    Action4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction4;
                    Action4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction4;
                    Action4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction4;
                    Action5.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction5;
                    Action5.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction5;
                    Action5.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction5;
                    Action6.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction6;
                    Action6.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction6;
                    Action6.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction6;
                    Action7.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction7;
                    Action7.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction7;
                    Action7.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction7;
                    Action8.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction8;
                    Action8.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction8;
                    Action8.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction8;
                    Action9.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction9;
                    Action9.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction9;
                    Action9.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction9;
                    Action0.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction0;
                    Action0.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction0;
                    Action0.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAction0;
                    HotBarCycleLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHotBarCycleLeft;
                    HotBarCycleLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHotBarCycleLeft;
                    HotBarCycleLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHotBarCycleLeft;
                    HotBarCycleRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHotBarCycleRight;
                    HotBarCycleRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHotBarCycleRight;
                    HotBarCycleRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHotBarCycleRight;
                    Focus.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFocus;
                    Focus.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFocus;
                    Focus.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFocus;
                    HotBarActionCurrent.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHotBarActionCurrent;
                    HotBarActionCurrent.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHotBarActionCurrent;
                    HotBarActionCurrent.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHotBarActionCurrent;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    AxesLeft.started += instance.OnAxesLeft;
                    AxesLeft.performed += instance.OnAxesLeft;
                    AxesLeft.canceled += instance.OnAxesLeft;
                    AxesRight.started += instance.OnAxesRight;
                    AxesRight.performed += instance.OnAxesRight;
                    AxesRight.canceled += instance.OnAxesRight;
                    CursorMove.started += instance.OnCursorMove;
                    CursorMove.performed += instance.OnCursorMove;
                    CursorMove.canceled += instance.OnCursorMove;
                    CursorClick.started += instance.OnCursorClick;
                    CursorClick.performed += instance.OnCursorClick;
                    CursorClick.canceled += instance.OnCursorClick;
                    CursorHold.started += instance.OnCursorHold;
                    CursorHold.performed += instance.OnCursorHold;
                    CursorHold.canceled += instance.OnCursorHold;
                    MenuMove.started += instance.OnMenuMove;
                    MenuMove.performed += instance.OnMenuMove;
                    MenuMove.canceled += instance.OnMenuMove;
                    MenuSwap.started += instance.OnMenuSwap;
                    MenuSwap.performed += instance.OnMenuSwap;
                    MenuSwap.canceled += instance.OnMenuSwap;
                    MenuToggle.started += instance.OnMenuToggle;
                    MenuToggle.performed += instance.OnMenuToggle;
                    MenuToggle.canceled += instance.OnMenuToggle;
                    Jump.started += instance.OnJump;
                    Jump.performed += instance.OnJump;
                    Jump.canceled += instance.OnJump;
                    Action1.started += instance.OnAction1;
                    Action1.performed += instance.OnAction1;
                    Action1.canceled += instance.OnAction1;
                    Action2.started += instance.OnAction2;
                    Action2.performed += instance.OnAction2;
                    Action2.canceled += instance.OnAction2;
                    Action3.started += instance.OnAction3;
                    Action3.performed += instance.OnAction3;
                    Action3.canceled += instance.OnAction3;
                    Action4.started += instance.OnAction4;
                    Action4.performed += instance.OnAction4;
                    Action4.canceled += instance.OnAction4;
                    Action5.started += instance.OnAction5;
                    Action5.performed += instance.OnAction5;
                    Action5.canceled += instance.OnAction5;
                    Action6.started += instance.OnAction6;
                    Action6.performed += instance.OnAction6;
                    Action6.canceled += instance.OnAction6;
                    Action7.started += instance.OnAction7;
                    Action7.performed += instance.OnAction7;
                    Action7.canceled += instance.OnAction7;
                    Action8.started += instance.OnAction8;
                    Action8.performed += instance.OnAction8;
                    Action8.canceled += instance.OnAction8;
                    Action9.started += instance.OnAction9;
                    Action9.performed += instance.OnAction9;
                    Action9.canceled += instance.OnAction9;
                    Action0.started += instance.OnAction0;
                    Action0.performed += instance.OnAction0;
                    Action0.canceled += instance.OnAction0;
                    HotBarCycleLeft.started += instance.OnHotBarCycleLeft;
                    HotBarCycleLeft.performed += instance.OnHotBarCycleLeft;
                    HotBarCycleLeft.canceled += instance.OnHotBarCycleLeft;
                    HotBarCycleRight.started += instance.OnHotBarCycleRight;
                    HotBarCycleRight.performed += instance.OnHotBarCycleRight;
                    HotBarCycleRight.canceled += instance.OnHotBarCycleRight;
                    Focus.started += instance.OnFocus;
                    Focus.performed += instance.OnFocus;
                    Focus.canceled += instance.OnFocus;
                    HotBarActionCurrent.started += instance.OnHotBarActionCurrent;
                    HotBarActionCurrent.performed += instance.OnHotBarActionCurrent;
                    HotBarActionCurrent.canceled += instance.OnHotBarActionCurrent;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnAxesLeft(InputAction.CallbackContext context);
            void OnAxesRight(InputAction.CallbackContext context);
            void OnCursorMove(InputAction.CallbackContext context);
            void OnCursorClick(InputAction.CallbackContext context);
            void OnCursorHold(InputAction.CallbackContext context);
            void OnMenuMove(InputAction.CallbackContext context);
            void OnMenuSwap(InputAction.CallbackContext context);
            void OnMenuToggle(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnAction1(InputAction.CallbackContext context);
            void OnAction2(InputAction.CallbackContext context);
            void OnAction3(InputAction.CallbackContext context);
            void OnAction4(InputAction.CallbackContext context);
            void OnAction5(InputAction.CallbackContext context);
            void OnAction6(InputAction.CallbackContext context);
            void OnAction7(InputAction.CallbackContext context);
            void OnAction8(InputAction.CallbackContext context);
            void OnAction9(InputAction.CallbackContext context);
            void OnAction0(InputAction.CallbackContext context);
            void OnHotBarCycleLeft(InputAction.CallbackContext context);
            void OnHotBarCycleRight(InputAction.CallbackContext context);
            void OnFocus(InputAction.CallbackContext context);
            void OnHotBarActionCurrent(InputAction.CallbackContext context);
        }
    }
}
