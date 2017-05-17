using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ClassesDatabase", menuName = "Classes Database")]
public class ClassesDatabase : ScriptableObject, IInitialized {

    private static ClassesDatabase instance;

    private CharacterClass[] m_Classes;

    public void Init()
    {
        instance = this;


    }
	
}
