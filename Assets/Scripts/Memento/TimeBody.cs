using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TimeBody : MonoBehaviour
    {
        [SerializeField] private float _recordTime = 5f;
        private List<PointInTime> _pointsInTime;
        private Rigidbody2D _rb;
        private bool _isRewinding;
        
        private void Start ()
        {
            _pointsInTime = new List<PointInTime>();
            _rb = GetComponent<Rigidbody2D>();
        }
        private void Update ()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartRewind();
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                StopRewind();
            }
        }
        private void FixedUpdate ()
        {
            if (_isRewinding)
            {
                Rewind();
            }
            else
            {
                Record();
            }
        }
        private void Rewind ()
        {
            if (_pointsInTime.Count > 1)
            {
                PointInTime pointInTime = _pointsInTime[0];
                transform.position = pointInTime.Position;
                transform.rotation = pointInTime.Rotation;
                _pointsInTime.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _pointsInTime[0];
                transform.position = pointInTime.Position;
                transform.rotation = pointInTime.Rotation;
                StopRewind();
            }
        }
        private void Record ()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime /
                                                  Time.fixedDeltaTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }
            _pointsInTime.Insert(0, new PointInTime(transform.position,
                transform.rotation, _rb.velocity));
        }
        private void StartRewind ()
        {
            _isRewinding = true;
            _rb.isKinematic = true;
        }
        private void StopRewind ()
        {
            _isRewinding = false;
            _rb.isKinematic = false;
            _rb.velocity = _pointsInTime[0].Velocity;
        }
    }
