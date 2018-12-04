using System.Collections.Generic;

namespace MyGame
{
    public class CreditWindow : Window
    {
        private Button backButton;
        private TextBlock creditTextBlock;

        public CreditWindow(): base(28, 10, 60, 18, '@')
        {
            List<string> creditInfo = new List<string>();

            creditInfo.Add("Programmer:");
            creditInfo.Add("viva");
            creditInfo.Add("");
            creditInfo.Add("Design:");
            creditInfo.Add("Nobody");

            creditTextBlock = new TextBlock(28 + 1, 10 + 5, 60 - 1, creditInfo);

            backButton = new Button(28 + 20, 10 + 14, 18, 3, "Back");

            //Render();
        }

        public void Render()
        {
            base.Render();
            creditTextBlock.Render();
            backButton.Render();
        }
    }
}