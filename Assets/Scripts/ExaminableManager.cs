using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    [SerializeField]
    private Transform _examineTarget;
    private Vector3 _originalPosition;
    private Quaternion _originalRotation;
    private Vector3 _originalScale;
    private Examinable _currentExaminable;
    private bool _isExamined = false;
    [SerializeField]
    private float _rotateSpeed = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        if (_examineTarget == null)
        {
            Debug.LogError("ExamineTarget is Null");
        }
    }

    void Update()
    {
        if (_isExamined && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                _currentExaminable.transform.Rotate(touch.deltaPosition.x * _rotateSpeed, touch.deltaPosition.y * _rotateSpeed, 0);
            }
        }
    }

    public void PerformExamine(Examinable examinable)
    {
        if (examinable != null)
        {
            _currentExaminable = examinable;
            _originalPosition = _currentExaminable.transform.position;
            _originalRotation = _currentExaminable.transform.rotation;
            _originalScale = _currentExaminable.transform.localScale;

            _currentExaminable.transform.position = _examineTarget.position;
            _currentExaminable.transform.parent = _examineTarget;

            Vector3 offsetScale = _originalScale * _currentExaminable.scaleOffset;
            _currentExaminable.transform.localScale = offsetScale;

            _isExamined = true;
        }
    }

    public void PerformUnexamine()
    {
        if (_currentExaminable != null)
        {
            _currentExaminable.transform.parent = null;
            _currentExaminable.transform.position = _originalPosition;
            _currentExaminable.transform.rotation = _originalRotation;
            _currentExaminable.transform.localScale = _originalScale;
            _currentExaminable = null;
            _originalPosition = Vector3.zero;
            _originalRotation = Quaternion.identity;
            _originalScale = Vector3.one;
            _isExamined = false;
        }
    }
}
