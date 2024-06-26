﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using ISSLab.ViewModel;
using ISSLab.Domain;

namespace ISSLab.ViewModel
{
    public class PollViewModel : ViewModelBase
    {
        public PollViewModel(Poll pollThatIsEncapsulatedByThisInstanceOnAViewModel)
        {
            PollThatIsEncapsulatedByThisInstanceOnViewModel = pollThatIsEncapsulatedByThisInstanceOnAViewModel;
        }

        private Poll pollThatIsEncapsulatedByThisInstanceOnViewModel;
        public Poll PollThatIsEncapsulatedByThisInstanceOnViewModel
        {
            get
            {
                return this.pollThatIsEncapsulatedByThisInstanceOnViewModel;
            }
            set
            {
                this.pollThatIsEncapsulatedByThisInstanceOnViewModel = value;
                OnPropertyChanged(nameof(PollThatIsEncapsulatedByThisInstanceOnViewModel));
            }
        }

        public string DescriptionOfThePoll
        {
            get
            {
                return PollThatIsEncapsulatedByThisInstanceOnViewModel.Description;
            }
            set
            {
                PollThatIsEncapsulatedByThisInstanceOnViewModel.Description = value;
                OnPropertyChanged(nameof(DescriptionOfThePoll));
            }
        }

        public string DueDateOfThePollInStringFormat
        {
            get
            {
                return PollThatIsEncapsulatedByThisInstanceOnViewModel.EndDate.ToString();
            }
            set
            {
                PollThatIsEncapsulatedByThisInstanceOnViewModel.EndDate = DateOnly.Parse(value);
                OnPropertyChanged(nameof(DueDateOfThePollInStringFormat));
            }
        }

        // public PollOption FirstPossibleOptionOfThePoll
        // {
        //    get
        //    {
        //        return PollThatIsEncapsulatedByThisInstanceOnViewModel.PollOptions.First();
        //    }
        //    set
        //    {
        //        PollThatIsEncapsulatedByThisInstanceOnViewModel.PollOptions.First() = value;
        //        //OnPropertyChanged(nameof(FirstPossibleOptionOfThePoll));
        //    }
        // }

        // public string SecondPossibleOptionOfThePoll
        // {
        //    get
        //    {
        //        return PollThatIsEncapsulatedByThisInstanceOnViewModel.Options[1];
        //    }
        //    set
        //    {
        //        PollThatIsEncapsulatedByThisInstanceOnViewModel.Options[1] = value;
        //        OnPropertyChanged(nameof(SecondPossibleOptionOfThePoll));
        //    }
        // }

        // public string ThirdPossibleOptionOfThePoll
        // {
        //    get
        //    {
        //        return PollThatIsEncapsulatedByThisInstanceOnViewModel.Options[2];
        //    }
        //    set
        //    {
        //        PollThatIsEncapsulatedByThisInstanceOnViewModel.Options[2] = value;
        //        OnPropertyChanged(nameof(ThirdPossibleOptionOfThePoll));
        //    }
        // }

        // public string FourthPossibleOptionOfThePoll
        // {
        //    get
        //    {
        //        return PollThatIsEncapsulatedByThisInstanceOnViewModel.Options[3];
        //    }
        //    set
        //    {
        //        PollThatIsEncapsulatedByThisInstanceOnViewModel.Options[3] = value;
        //        OnPropertyChanged(nameof(FourthPossibleOptionOfThePoll));
        //    }
        // }
    }
}
