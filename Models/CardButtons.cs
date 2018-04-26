using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Pairs.ViewModel;

namespace Pairs.Models
{
   public class CardButtons
    {
        private CardViewModel CardVM;

        public CardButtons(CardViewModel cardvm)
        {
            this.CardVM = cardvm;
        }

        public void CardPress(object param)
        {
            Button myButton = (param as Button);
            Card card = (Card)myButton.Content;
         


            for(int i=0;i<CardVM.Cards.Count;i++)
            {
                for(int j=0;j<CardVM.Cards[i].Count;j++)
                {
                    if (CardVM.Cards[i][j].Equals(card))
                    {
                     
                        CardVM.Cards[i][j].Cover = CardVM.Cards[i][j].Image;
                        CardVM.Cards[i][j].IsShown = true;


                        if (ReferenceEquals(null, CardVM.PrevButtons) )
                        {
                            CardVM.SelectedCard = CardVM.Cards[i][j];
                            CardVM.PrevButtons = myButton;
                        }
                       
                        if (!card.Equals(CardVM.SelectedCard) && CardVM.PrevButtons!=null)
                        {
                           
                            if (CardVM.SelectedCard.Image.Equals(card.Image))
                            {
                                MessageBox.Show("Pereche");
                                CardVM.PrevButtons.IsEnabled = false;
                                CardVM.PrevButtons = null;
                                CardVM.SelectedCard = null;
                                myButton.IsEnabled = false;

                            }
                            else
                            {
                                MessageBox.Show("Incearca iar");
                                for(int k=0;k<CardVM.Cards.Count;k++)
                                {
                                    for(int p=0;p<CardVM.Cards[i].Count;p++)
                                    {
                                        if (CardVM.Cards[k][p].Equals(CardVM.SelectedCard))
                                        {
                                            CardVM.Cards[k][p].Cover = @"\Resources\intrebare.png";
                                        }
                                    }
                                }
                                CardVM.PrevButtons = null;
                                CardVM.SelectedCard = null;
                                CardVM.Cards[i][j].Cover = @"\Resources\intrebare.png";
                            }
                        }
                    }
                }
            }
            
        }


    }
}
