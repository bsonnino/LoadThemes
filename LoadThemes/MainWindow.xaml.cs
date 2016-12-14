using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Markup;

namespace LoadThemes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public partial class MainWindow : Window
    {
        List<Person> SouthPark = new List<Person>() {
            new Person() { Name = "Eric", Surname="Cartman" },
            new Person() { Name = "Stan", Surname="Marsh" },
            new Person() { Name = "Kyle", Surname="Broflovski" },
            new Person() { Name = "Kenny", Surname="McCormick" },
            new Person() { Name = "Bebe", Surname="Stevens" },
            new Person() { Name = "Clyde", Surname="Donovan" },
            new Person() { Name = "Craig", Surname="Tucker" },
            new Person() { Name = "Jimmy", Surname="Vulmer" },
            new Person() { Name = "Pip", Surname="Pirrup" },
            new Person() { Name = "Token", Surname="Black" },
            new Person() { Name = "Tweek", Surname="Tweak" },
            new Person() { Name = "Wendy", Surname="Testaburger" },
            new Person() { Name = "Annie", Surname="Polk" },
            new Person() { Name = "Randy", Surname="Marsh" },
            new Person() { Name = "Sharon", Surname="Marsh" },
            new Person() { Name = "Shelley", Surname="Marsh" },
            new Person() { Name = "Marvin", Surname="Marsh" },
            new Person() { Name = "Jimbo", Surname="Kern" },
            new Person() { Name = "Gerald", Surname="Broflovski" },
            new Person() { Name = "Sheila", Surname="Broflovski" },
            new Person() { Name = "Ike", Surname="Broflovski" },
            new Person() { Name = "Kyle", Surname="Schwartz" },
            new Person() { Name = "Liane", Surname="Cartman" },
            new Person() { Name = "Stuart", Surname="McCormick" },
            new Person() { Name = "Carol", Surname="McCormick" },
            new Person() { Name = "Kevin", Surname="McCormick" },
            new Person() { Name = "Stephen", Surname="Stotch" },
            new Person() { Name = "Linda", Surname="Stotch" },
            new Person() { Name = "Richard", Surname="Tweak" }
        };

        public MainWindow()
        {
            InitializeComponent();
            comboBox.ItemsSource = SouthPark;
            listBox.ItemsSource = SouthPark;
            LoadThemes();
        }

        private void LoadThemes()
        {
            themes.ItemsSource = Directory.EnumerateDirectories("Themes").Select(t => t.Substring(7));
        }

        private void themes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;
            using (FileStream fs = new FileStream($"Themes\\{e.AddedItems[0]}\\Theme.xaml", FileMode.Open))
            {
                var dict = XamlReader.Load(fs) as ResourceDictionary;
                if (dict != null)
                {
                    Application.Current.Resources.Clear();
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }
            }
        }
    }
}
