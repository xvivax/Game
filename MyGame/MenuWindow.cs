using System;
using System.Collections.Generic;

namespace MyGame
{
    public class MenuWindow : Window
    {
        private List<Button> buttons = new List<Button>();
        private TextBlock titleTextBlock;
        private int buttonIndex;

        public MenuWindow() : base(0, 0, 120, 30, '&')
        {
            titleTextBlock = new TextBlock(10, 5, 100, new List<string> { "Super duper zaidimas", "viva Las Vegas kuryba!", "Made in Vilnius Coding School!" });

            buttons.Add(new Button(10, 15, 20, 7, "Start Game"));
            buttons.Add(new Button(50, 15, 20, 7, "Credits"));
            buttons.Add(new Button(90, 15, 20, 7, "Exit"));


            buttonIndex = 0;
            buttons[buttonIndex].SetActive();

            //Render();
        }

        public void Render()
        {
            base.Render();

            titleTextBlock.Render();
            
            foreach (Button itemButton in buttons)
            {
                itemButton.Render();
            }

            Console.SetCursorPosition(0,0);
        }

        public void NextButton()
        {
            if (buttonIndex < 2)
            {
                buttons[buttonIndex].SetNotActive();
                buttonIndex++;
                buttons[buttonIndex].SetActive();
            }
        }

        public void PreviousButton()
        {
            if (buttonIndex > 0)
            {
                buttons[buttonIndex].SetNotActive();
                buttonIndex--;
                buttons[buttonIndex].SetActive();
            }
        }

        //Just for test
    }
}