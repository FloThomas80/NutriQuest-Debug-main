using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


public class Testmov
{
    [UnityTest]
    public IEnumerator Moves_On_X()
    {
        GameObject playerTest = new GameObject();
        Rigidbody rb = playerTest.AddComponent<Rigidbody>();
        PlayerMovement PM = playerTest.AddComponent<PlayerMovement>();
        PM.Initialize(rb);

        playerTest.transform.position = Vector3.zero;
       

        rb.AddForce(10, 10, 10);
        yield return new WaitForFixedUpdate();
        //Assert.AreEqual(1, playerTest.transform.position.x, 0.1f);
        Assert.IsFalse(playerTest.transform.position.x == 0);

        Object.Destroy(playerTest);
    }
}