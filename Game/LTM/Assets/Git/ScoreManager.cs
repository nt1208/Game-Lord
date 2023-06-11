using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Collections;

public class ScoreManager : NetworkBehaviour
{
    // Start is called before the first frame update
    NetworkVariable<int> Score = new NetworkVariable<int>();
    NetworkVariable<FixedString128Bytes> Name = new NetworkVariable<FixedString128Bytes>();

}
