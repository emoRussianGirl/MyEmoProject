using Microsoft.EntityFrameworkCore;
using MyEmoProject.Models;
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

namespace MyEmoProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonsDbContext _db = new PersonsDbContext();
        private int Count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PersonName.Text) ||
                string.IsNullOrEmpty(PersonBirthDate.Text) ||
                string.IsNullOrEmpty(PersonGender.Text))
            {
                ClearInputs();
                MessageBox.Show("Данные введены неправильно.");

                return;
            }

            List<DopInfo> infos = new List<DopInfo>();

            if (Dobriy.IsChecked ?? false)
            {
                infos.Add(_db.DopInfos.First(d => d.Name == Dobriy.Content.ToString()));
            }

            if (Otziv.IsChecked ?? false)
            {
                infos.Add(_db.DopInfos.First(d => d.Name == Otziv.Content.ToString()));
            }

            if (Scromniy.IsChecked ?? false)
            {
                infos.Add(_db.DopInfos.First(d => d.Name == Scromniy.Content.ToString()));
            }

            Person person = new Person()
            {
                Name = PersonName.Text,
                BirthDate = DateTime.Parse(PersonBirthDate.Text),
                GenderId = _db.Genders.First(g => g.GenderName == PersonGender.Text).Id,
                DopInfos = infos
            };

            _db.People.Add(person);
            _db.SaveChanges();

            ClearInputs();
        }

        private void ClearInputs()
        {
            PersonName.Text = null;
            PersonBirthDate.Text = null;
            PersonGender.Text = null;
            Dobriy.IsChecked = false;
            Otziv.IsChecked = false;
            Scromniy.IsChecked = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Count >= _db.People.Count())
            {
                Count = 0;
            }

            Person person = _db.People.Include(p => p.DopInfos).Skip(Count).First();

            StringBuilder sb = new StringBuilder();

            foreach (var dop in person.DopInfos)
            {
                sb.Append(dop.Name + ' ');
            }

            NameText.Text = person.Name;
            BirthText.Text = DateOnly.FromDateTime(person.BirthDate).ToString();
            GenderText.Text = _db.Genders.First(g => g.Id == person.GenderId).GenderName;
            DopText.Text = sb.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Count++;
            Button_Click_1(sender, e);
        }
    }
}
