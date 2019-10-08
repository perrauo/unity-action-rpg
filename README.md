# ARPG FRAMEWORK
![alt text](https://github.com/OliPerraul/arpg-framework/blob/master/Capture4.PNG)
![alt text](https://github.com/OliPerraul/arpg-framework/blob/master/Capture5.PNG)
![alt text](https://github.com/OliPerraul/arpg-framework/blob/master/Capture6.PNG)

![alt text](https://github.com/OliPerraul/arpg-framework/blob/master/dungeon.PNG)
![alt text](https://github.com/OliPerraul/arpg-framework/blob/master/Capture2.PNG)

# Unity version
2019.2.2f1

# Disclaimers
This project is a work in progress.

# Systems
* Object System
    * BaseObject
    * Character
    * Interactable
    
    https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Objects/BaseObject.cs
    https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Objects/Characters/Character.cs


* Character Controller System
    * Finite state machine
    * Kinematic Character Controller Integration
    
    https://github.com/OliPerraul/arpg-framework/tree/master/Project/Assets/ARPG/Objects/Characters/KinematicControls
    https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Objects/Characters/FSM/State.cs
   
 * Agent System (Utility based agent)
    * Agent
    * Task
    * Motivation
    * Consideration
    * Listeners (listens for changes in the environment)
    
    https://github.com/OliPerraul/arpg-framework/tree/master/Project/Assets/ARPG/Objects/Characters/Controls/AI
    https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Objects/Characters/Controls/AI/Agent.cs
    https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Objects/Characters/Controls/AI/Option.cs
    https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Objects/Characters/Controls/AI/Consideration.cs
    https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Objects/Characters/Controls/AI/FSM/State.cs
    
    
 * Controls System
   * Unity new input system integration
   * Controller
   * Operator
   * Player
   * Agent
   
   https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Controls/Player.cs
    
* Ability System
    * AbilityUser
    * Action
    * Effect
    * Modifiers
    
    https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Actions/BaseEffect.cs
    https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Objects/Characters/Actions/Abilities/Ability.cs

* Attributes
   https://github.com/OliPerraul/arpg-framework/tree/master/Project/Assets/ARPG/Objects/Attributes
   https://github.com/OliPerraul/arpg-framework/tree/master/Project/Assets/ARPG/Objects/Characters/Attributes

* Reaction System
    * GlobalReaction
    * PassiveEvent
    * TriggerEvent
        * Trigger

* Inventory
   * Grid UI Inventory
   * Random drops
   * Collectibles
   
   https://github.com/OliPerraul/arpg-framework/tree/master/Project/Assets/ARPG/Objects/Items
   https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Objects/Items/InventoryUser.cs
   https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Objects/Items/Inventory.cs
   https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Objects/Items/Collectible.cs
   https://github.com/OliPerraul/arpg-framework/blob/master/Project/Assets/ARPG/Objects/Items/Drop.cs
   

* Persistence and room transition
    * Transition
    * PersistenceManager
        
* Condition 
    * Condition
    * ConditionListener
    * SituationListener


* Reward System
    * Reward
    * Tiers
       
   
    
# Upcoming Systems

* Level Progression System
   * Population Count/ Danger Count
   * Loss/ Victory conditions

* Action Inventory System

* Focus Targeting System

* Status Effects/ Persistent Effects System

* Character Animation System


