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
using System.Windows.Shapes;

namespace Ksiegarnia
{
    /// <summary>
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        public Book books { get; set; }

        public BookWindow()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            if(books != null)
            {
                book_name.Text = books.bookName;
                author_name.Text = books.author;
                description_name.Text = books.description;
                book_id.Text = books.bookId.ToString();
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            books.bookName = book_name.Text;
            books.author = author_name.Text;
            books.description = description_name.Text;
            books.bookId = Convert.ToInt32(book_id.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
