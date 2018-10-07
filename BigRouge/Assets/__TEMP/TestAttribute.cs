using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigRogue.BattleSystem;

public class TestAttribute : MonoBehaviour {


    public AttributeGroup ag;

    public float abc;

    public AttributeModifer a;
    public AttributeModifer b;

    public Attribute testHp;

    void Awake() {
        ag = new AttributeGroup();
        
        testHp = new Attribute(1, "HP");
        //ag.AddAttribute(hp);
        a = new AttributeModifer("Equip", 1, ModifierType.BaseValue, 100);
        b = new AttributeModifer("Equip", 1, ModifierType.BaseScale, 0.025f);
        ag.AddAttributeModifier(a);
        ag.AddAttributeModifier(b);
    }

    // Update is called once per frame
    void Update() {
        abc = ag.GetAttrValue(1);
        b.value += Time.deltaTime;
       
    }
}
