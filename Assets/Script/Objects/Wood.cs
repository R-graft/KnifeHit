using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [System.Serializable]
    public class Rotator
    {
        public float speed;
        public float duration;
    }

    private WheelJoint2D _wheelJoint;
    private JointMotor2D _jointMotor;

    private List <Rotator> _rotationPattern;

    private void Awake()
    {
        _rotationPattern = new List<Rotator>();
        _jointMotor = new JointMotor2D();
        _wheelJoint = GetComponent<WheelJoint2D>();
        _rotationPattern = CreateRotationPatterns (PlayController._levelNumber,_rotationPattern);
    }
    private void Start()
    {
        StartCoroutine(StartRotationPattern());
    }

    private IEnumerator StartRotationPattern()
    {
        int rotationIndex = 0;
        while (true)
        {
            yield return new WaitForFixedUpdate();
            _jointMotor.motorSpeed = _rotationPattern[rotationIndex].speed;
            _jointMotor.maxMotorTorque = 10000;
            _wheelJoint.motor = _jointMotor;

            yield return new WaitForSecondsRealtime(_rotationPattern[rotationIndex].duration);
            rotationIndex++;
            rotationIndex = rotationIndex < _rotationPattern.Count ? rotationIndex : 0;
        }
    }
    List<Rotator> CreateRotationPatterns(int level, List<Rotator> rotatorPattern)
    {
        _rotationPattern.Clear();

        Rotator rotator1 = new Rotator();
        Rotator rotator2 = new Rotator();
        Rotator rotator3 = new Rotator();
        if (level > 5)
        {
            level = System.Convert.ToInt32(level / 5);
        }
            switch (level)
            {
                case 1:
                    rotator1.speed = 200;
                    rotator1.duration = 2;

                    rotatorPattern.Add(rotator1);
                    break;
                case 2:
                    rotator1 = new Rotator();
                    rotator1.speed = 250;
                    rotator1.duration = 1.5f;

                    rotator2.speed = -150;
                    rotator2.duration = 3;

                    rotatorPattern.Add(rotator1);
                    rotatorPattern.Add(rotator2);
                    break;
                case 3:
                    rotator1.speed = 300;
                    rotator1.duration = 1;

                    rotator2.speed = -200;
                    rotator2.duration = 2;

                    rotator3.speed = 150;
                    rotator3.duration = 3;

                    rotatorPattern.Add(rotator1);
                    rotatorPattern.Add(rotator2);
                    rotatorPattern.Add(rotator3);
                    break;
                case 4:
                    rotator1.speed = 150;
                    rotator1.duration = 2;

                    rotator2.speed = -300;
                    rotator2.duration = 1;

                    rotator3.speed = 250;
                    rotator3.duration = 3;

                    rotatorPattern.Add(rotator1);
                    rotatorPattern.Add(rotator2);
                    rotatorPattern.Add(rotator3);
                    break;
                case 5:
                    rotator1.speed = 350;
                    rotator1.duration = 1;

                    rotator2.speed = -200;
                    rotator2.duration = 3;

                    rotator3.speed = 150;
                    rotator3.duration = 1;

                    rotatorPattern.Add(rotator1);
                    rotatorPattern.Add(rotator2);
                    rotatorPattern.Add(rotator3);
                    break;
        }
        return rotatorPattern;
    }
    
}
