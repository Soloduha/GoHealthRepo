using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using BLL;
using BLL.DTO;

namespace UserInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>   
    public class Pat
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ThirdName { get; set; }
    }

    public partial class MainWindow : Window
    {
        Grid currentGrid;
        //public ObservableCollection<TestClass> myCollection;
        //public List<Pat> patients;
        public List<PatientDTO> patients;
        public MainWindow()
        {
            InitializeComponent();
            currentGrid = new Grid();           //to simplify controlling grids
            DateOfReception.BlackoutDates.AddDatesInPast();
            patients = new List<PatientDTO>(TestClass.GetSomePatients());
            //patients = new List<Pat>();
            GridLogSign.Visibility = Visibility.Visible;

            //myCollection = new ObservableCollection<TestClass>();
            //myCollection.Add(new TestClass() { Name = "Vlad", StartDate = DateTime.Now, EndDate = DateTime.Now});
            //myCollection.Add(new TestClass() { Name = "Oleh", StartDate = DateTime.Now, EndDate = DateTime.Now });
            //myCollection.Add(new TestClass() { Name = "Sasha", StartDate = DateTime.Now, EndDate = DateTime.Now });
            //myCollection.Add(new TestClass() { Name = "Liza", StartDate = DateTime.Now, EndDate = DateTime.Now });
            //MondayListView.ItemsSource = myCollection;

            //patients.Add(new Pat() { Name = "Vlad", Surname = "Soloduha", ThirdName = "Valentinovich" });
            //patients.Add(new Pat() { Name = "Vlad1", Surname = "Sollllqqq", ThirdName = "Valentinovich1" });
            //patients.Add(new Pat() { Name = "Vlad2", Surname = "hakunaMatata", ThirdName = "Valentinovich2" });
            //patients.Add(new Pat() { Name = "Vlad3", Surname = "lion", ThirdName = "Valentinovich" });
            //patients.Add(new Pat() { Name = "Vlad4", Surname = "strikalo", ThirdName = "Valentinovich" });
            SurnamesComboBox.ItemsSource = patients;


            //DoctorsR.ItemsSource = patients;
            //DateOfReception.

            DateOfReception.BlackoutDates.AddDatesInPast();
        }

        private void NextWeekButton_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //перехід на наступний тиждень
        }

        private void PreviousWeekButton_Click(object sender, RoutedEventArgs e)
        {
            //перехід на попередній тиждень
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            GridLogSign.Visibility = Visibility.Collapsed;
            RegisterGrid.Visibility = Visibility.Visible;
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            GridLogSign.Visibility = Visibility.Collapsed;
            GridSignIn.Visibility = Visibility.Visible;
        }

        private void OkRegister_Click(object sender, RoutedEventArgs e)
        {
            //перевірка на введені дані
            //добавлення в базу нового користувача
            RegisterGrid.Visibility = Visibility.Collapsed;
            FunctionalGrid.Visibility = Visibility.Visible;

        }

        private void CancelRegister_Click(object sender, RoutedEventArgs e)
        {           
            RegisterGrid.Visibility = Visibility.Collapsed;
            GridLogSign.Visibility = Visibility.Visible;
        }

        private void ScheduleMenuItem_Click(object sender, RoutedEventArgs e)
        {
            //графік роботи лікарів
            currentGrid.Visibility = Visibility.Collapsed;
            currentGrid = CurrentWeekGrid;
            CurrentWeekGrid.Visibility = Visibility.Visible;
        }

        private void OkSign_Click(object sender, RoutedEventArgs e)
        {            
            //перевірка на наявність поточного користувача в базі даних
            GridSignIn.Visibility = Visibility.Collapsed;
            FunctionalGrid.Visibility = Visibility.Visible;
        }

        private void SignInCancelButton_Click(object sender, RoutedEventArgs e)
        {
            GridSignIn.Visibility = Visibility.Collapsed;
            GridLogSign.Visibility = Visibility.Visible;
        }

        private void OkNewReceptionButton_Click(object sender, RoutedEventArgs e)
        {
            //add new reception to database
            //if patient doesn`t exist, add him/her to database
        }

        private void ReceptionMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //поява вікна нового прийому
            currentGrid.Visibility = Visibility.Collapsed;
            currentGrid = NewReceptionGrid;
            currentGrid.Visibility = Visibility.Visible;
        }

        private void SurnamesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if patient exists in database, textboxes below will be filled with his/her data 
            PatientDTO p;
            p = SurnamesComboBox.SelectedItem as PatientDTO;
            if (p != null)
            {
                NewReceptionNameTextBox.Text = p.Name;
                NewReceptionPoBatkoviTextBox.Text = p.ThirdName;
            }
            else
            {
                NewReceptionNameTextBox.Text = "";
                NewReceptionPoBatkoviTextBox.Text = "";
            }
        }

        private void ViewReceptions_Click(object sender, RoutedEventArgs e)
        {
            currentGrid.Visibility = Visibility.Collapsed;
            currentGrid = AllReceptionsGrid;
            currentGrid.Visibility = Visibility.Visible;
        }

        private void ProfileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            currentGrid.Visibility = Visibility.Collapsed;
            currentGrid = ProfileGrid;
            currentGrid.Visibility = Visibility.Visible;
        }

        private void ClearAllFieldsButton_Click(object sender, RoutedEventArgs e)
        {
            NewReceptionNameTextBox.Text = "";
            NewReceptionPoBatkoviTextBox.Text = "";
            SurnamesComboBox.Text = "";            
        }

        private void WorkProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentGrid.Tag != null)
            {
                (currentGrid.Tag as Grid).Visibility = Visibility.Collapsed;
            }
            currentGrid.Tag = ProfileWorkGrid;
            (currentGrid.Tag as Grid).Visibility = Visibility.Visible;
            (sender as Button).Background = Brushes.OrangeRed;
            PersonalProfileButton.Background = Brushes.Red;
            OwnScheduleButton.Background = Brushes.Red;
        }

        private void PersonalProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentGrid.Tag != null)
            {
                (currentGrid.Tag as Grid).Visibility = Visibility.Collapsed;
            }
            currentGrid.Tag = ProfileInfoGrid;
            (currentGrid.Tag as Grid).Visibility = Visibility.Visible;
            (sender as Button).Background = Brushes.OrangeRed;
            WorkProfileButton.Background = Brushes.Red;
            OwnScheduleButton.Background = Brushes.Red;
        }

        private void OwnScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentGrid.Tag != null)
            {
                (currentGrid.Tag as Grid).Visibility = Visibility.Collapsed;
            }
            currentGrid.Tag = ProfileScheduleGrid;
            (currentGrid.Tag as Grid).Visibility = Visibility.Visible;
            (sender as Button).Background = Brushes.OrangeRed;
            WorkProfileButton.Background = Brushes.Red;
            PersonalProfileButton.Background = Brushes.Red;
        }
    }
}