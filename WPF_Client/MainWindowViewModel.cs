using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using W6TW4A_HFT_2023241.Models;

namespace WPF_Client
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Adventurer> Adventurers { get; set;}

        public ICommand CreateAdventurerCommand {  get; set; }  
        public ICommand DeleteAdventurerCommand {  get; set; }  
        public ICommand UpdateAdventurerCommand {  get; set; }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        private Adventurer selectedAdventurer;

        public Adventurer SelectedAdventurer
        {
            get { return selectedAdventurer; }
            set 
            {
                if (value != null)
                {
                    selectedAdventurer = new Adventurer() 
                    {
                        AdventurerId = value.AdventurerId,
                        QuestId = value.QuestId,
                        Quest=value.Quest,
                        Name = value.Name,
                        PartyName = value.PartyName,
                        Rank = value.Rank,
                        ResidingTown = value.ResidingTown
                    };
                    OnPropertyChanged();
                    (DeleteAdventurerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Adventurers = new RestCollection<Adventurer>("http://localhost:8351/", "adventurer" , "hub");

                CreateAdventurerCommand = new RelayCommand(() =>
                {
                    Adventurers.Add(new Adventurer
                    {
                        Name = SelectedAdventurer.Name,
                        PartyName = SelectedAdventurer.PartyName,
                        Rank = SelectedAdventurer.Rank,
                        ResidingTown= SelectedAdventurer.ResidingTown
                    });
                });

                UpdateAdventurerCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Adventurers.Update(SelectedAdventurer);
                        //Actors.Update(SelectedActor);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteAdventurerCommand = new RelayCommand(() =>
                {
                    Adventurers.Delete(SelectedAdventurer.AdventurerId);
                },
                () =>
                {
                    return SelectedAdventurer != null;
                });

                SelectedAdventurer= new Adventurer(); 
            }
        }
    }
}
