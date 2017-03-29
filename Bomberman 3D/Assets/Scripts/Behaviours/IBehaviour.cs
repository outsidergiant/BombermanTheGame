using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBehaviour {

    bool CanExecute(MonoBehaviour monoBehaviourObject);

    void Execute(MonoBehaviour monoBehaviourObject);



}
