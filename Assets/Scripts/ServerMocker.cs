using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerMocker : MonoBehaviour
{
    public List<Question> mockList;

    [SerializeField]private int mockIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Question[] GetQuestionArray(Prompt prompt)
    {
        return mockList.ToArray();
    }
}
