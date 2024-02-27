using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class AttackRange : MonoBehaviour
{
    public List<Monster> monstersList = new List<Monster>();
    //public event UnityAction OnDied;
    public LayerMask monsterMask;



    private void OnTriggerEnter(Collider other)
    {
        if(((1 << other.gameObject.layer) & monsterMask) != 0)
        {
            Monster monster = other.gameObject.GetComponent<Monster>();
            monster.Ondied += () => monstersList.Remove(monster);
            monstersList.Add(monster);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (monsterMask.Contain(other.gameObject.layer))
        {
            Monster monster = other.gameObject.GetComponent<Monster>();
            monstersList.Remove(monster);
        }
    }
}

public static class Extension
{
    public static bool Contain(this LayerMask mask, int layer)
    {
        return (((1 << layer) & mask) != 0);
    }
}