using Pairs.Commands;
using Pairs.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;



namespace Pairs.ViewModel
{
    public class CardViewModel : BaseVM
    {
        public CardButtons buttons;

        public int timeInSeconds;

        private DispatcherTimer dispacherTimer;

        public Button PrevButtons { get; set; }
        public Card SelectedCard { get; set; }
        public ObservableCollection<ObservableCollection<Card>> Cards { get; set; }

        public List<String> Images;

        public CardViewModel()
        {
            Images = new List<String>();
            Images.Add(@"\Resources\img0.png");
            Images.Add(@"\Resources\img1.png");
            Images.Add(@"\Resources\img2.png");
            Images.Add(@"\Resources\img3.png");
            Images.Add(@"\Resources\img4.png");
            Images.Add(@"\Resources\img5.png");
            Images.Add(@"\Resources\img6.png");
            Images.Add(@"\Resources\img7.png");
            Images.Add(@"\Resources\img8.png");
            buttons = new CardButtons(this);
            Cards = new ObservableCollection<ObservableCollection<Card>>();
            Random random = new Random();
            for(int i=0;i<4;i++)
            {
                Cards.Add(new ObservableCollection<Card>());
                for(int j=0;j<4;j++)
                {
                    Cards[i].Add(new Card { Cover = @"\Resources\intrebare.png", IsShown = false });
                }
            }

            for(int i=0;i<Cards.Count;i++)
            {
                String path = null;
                for(int j=0;j<Cards.Count;j++)
                {
                    if(j%2==0)
                    {
                        path = Images.ElementAt(random.Next(0, Images.Count));
                    }
                    Cards[i][j].Image = path;
                }
            }
            for(int i=0;i<Cards.Count;i++)
            {
                Cards[i]= RandomizeCollection2(Cards[i]);
            }
            Cards = RandomizeCollection(Cards);
            TimeInSeconds = 30;
            dispacherTimer = new DispatcherTimer();
            dispacherTimer.Tick += dispacherTimer_Tick;
            dispacherTimer.Interval = new TimeSpan(0, 0, 1);
            dispacherTimer.Start();

        }

        private ObservableCollection<ObservableCollection<Card>> RandomizeCollection(ObservableCollection<ObservableCollection<Card>> cards)
        {
            ObservableCollection<ObservableCollection<Card>> newCollection = new ObservableCollection<ObservableCollection<Card>>();
            Random random = new Random();
            int randomIndex = 0;
            while(cards.Count >0)
            {
                randomIndex = random.Next(0, cards.Count);
                newCollection.Add(cards[randomIndex]);
                cards.RemoveAt(randomIndex);
            }
            return newCollection;
        }

        private ObservableCollection<Card> RandomizeCollection2(ObservableCollection<Card> cards)
        {
            ObservableCollection<Card> newCollection = new ObservableCollection<Card>();
            Random random = new Random();
            int randomIndex = 0;
            while(cards.Count>0)
            {
                randomIndex = random.Next(0, cards.Count);
                newCollection.Add(cards[randomIndex]);
                cards.RemoveAt(randomIndex);
            }
            return newCollection;
        }

        private void dispacherTimer_Tick(object sender, EventArgs e)
        {
            TimeInSeconds = TimeInSeconds - 1;
            if(TimeInSeconds==0)
            {
                dispacherTimer.Stop();
                
            }
        }


        private bool canExecuteCommand = true;
        private bool CanExecuteCommand
        {
            get
            {
                return canExecuteCommand;
            }

            set
            {
                if(canExecuteCommand == value)
                {
                    return;
                }
                canExecuteCommand = value;
            }
        }


        public int TimeInSeconds
        {
            get
            {
                return timeInSeconds;
            }
            set
            {
                timeInSeconds = value;
                OnPropertyChanged("TimeInSeconds");
            }
        }

        private ICommand cardPress;

        public ICommand CardPress
        {
            get
            {
                if(cardPress == null)
                {
                    cardPress = new RelayCommand(buttons.CardPress, param => CanExecuteCommand);
                }
                return cardPress;
            }
        }

    }
}
