using Avalonia.Controls;
using Demo1.Context;
using Demo1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Demo1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FellingList();
        }
        public void FellingList()
        {
            SamojlenkoContext samojlenkoContext = new SamojlenkoContext();
            var list =  samojlenkoContext.Clients.Include(x=>x.IdgenderNavigation).Select(x=> new
            {
                x.Name,
                x.Nameclient,
                x.Idclient,
                Idgender = x.IdgenderNavigation.Name

            }).ToList();
            ListPeople.ItemsSource = list;
        }

        private void TextBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            FellingList();
        }
    }
}