using Commands;
using Yandex;
using AudioManager;
using UnityEngine;

namespace BotController
{
    public class BotContainer
    {
        readonly ICommand[] commands = {
                                           new HelloCommand(),
                                           new SearchCommand(),
                                       };

        SpeechKit speechKit = new SpeechKit();
        SynthesizeManager synthesizeManager = new SynthesizeManager();


        public void Synthesize(string str)
        {
            speechKit.Synthesize(str);
        }

        public void Recognize(AudioClip audio)
        {
            speechKit.Recognize(audio);
        }

        public void PlaySynthenized()
        {
            synthesizeManager.Play();
        }

        public ICommand ChooseCommand(string str)
        {
            foreach (ICommand command in commands)
            {
                if (command.IsItI(str))
                {
                    return command;
                }
            }

            return null;
        }
    }

}