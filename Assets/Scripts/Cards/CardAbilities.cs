using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardAbilities
{
    public static void DamageCharacter(GridCharacter character, GridCharacter target, int damage)
    {
        // play some animation on character
        // and probably on target
        target.Health = target.Health - damage;
    }

    // ability does not emanate from a character, but globally. do we ever want to do this?
    public static void DamageCharacter(GridCharacter target, int damage)
    {
        // and probably on target
        target.Health = target.Health - damage;
    }

    public static void HealCharacter(GridCharacter character, GridCharacter target, int health)
    {
        // play some animation on character
        // and probably on target
        target.Health = target.Health + health;
    }
}
