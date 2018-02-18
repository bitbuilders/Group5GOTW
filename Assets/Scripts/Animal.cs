using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    // A generic animal class to be used on all the animals in the game.

    public enum State
    {
        FIND_PLAYER,
        WAIT,
        FIND_FOOD,
    }

    private void SendMessage(Animal target, AnimalActionData.ActionType action)
    {
        // Used to talk to other animals. It will call the RecieveMessage method of the animal (The one below).
        Blackboard.Instance.NotifyAnimal(target, action);
    }
    public void RecieveMessage(AnimalActionData.ActionType action)
    {
        // Do something with value depending on the action
    }
}
