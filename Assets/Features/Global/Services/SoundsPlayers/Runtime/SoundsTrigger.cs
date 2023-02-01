geusing System;
using Common.UiTools.ButtonEventTriggers;
using GamePlay.Puzzle.Assemble.Runtime;
using Global.Services.Common.Abstract;
using Global.Services.MessageBrokers.Runtime;
using UnityEngine;

namespace Global.Services.SoundsPlayers.Runtime
{
    [DisallowMultipleComponent]
    public class SoundsTrigger : MonoBehaviour, IGlobalAwakeListener
    {
        [SerializeField] private AudioClip _buttonTouched;
        [SerializeField] private AudioClip _buttonClicked;
        [SerializeField] private AudioClip _winSound;

        [SerializeField] private AudioClip _ambient;

        [SerializeField] private SoundsPlayer _player;

        private IDisposable _buttonClickListener;

        private IDisposable _buttonTouchListener;
        private IDisposable _correctAnswerListener;
        private IDisposable _finalEnterListener;
        private IDisposable _newQuestionListener;
        private IDisposable _assembleListener;

        private void OnDestroy()
        {
            _buttonTouchListener?.Dispose();
            _buttonClickListener?.Dispose();
            _newQuestionListener?.Dispose();
            _correctAnswerListener?.Dispose();
            _finalEnterListener?.Dispose();
            _assembleListener?.Dispose();
        }

        public void OnAwake()
        {
            _player.PlayLoopMusic(_ambient);

            _buttonTouchListener = Msg.Listen<ButtonTouchEvent>(OnButtonTouched);
            _buttonClickListener = Msg.Listen<ButtonClickEvent>(OnButtonClicked);
            _assembleListener = Msg.Listen<AssembledEvent>(OnAssembled);
        }

        private void OnButtonTouched(ButtonTouchEvent data)
        {
            _player.PlaySound(_buttonTouched);
        }

        private void OnButtonClicked(ButtonClickEvent data)
        {
            _player.PlaySound(_buttonClicked);
        }

        private void OnAssembled(AssembledEvent data)
        {
            Debug.Log("Play win");
            _player.PlaySound(_winSound);
        }
    }
}