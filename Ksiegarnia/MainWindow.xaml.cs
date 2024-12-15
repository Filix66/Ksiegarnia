using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Ksiegarnia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Book> book = new List<Book>();

        public List<string> text = new List<string>();


        public MainWindow()
        {
            InitializeComponent();      
            v_list.ItemsSource = book;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {         
            BookWindow bookWindow = new BookWindow();
            bookWindow.books = new Book();

            if (bookWindow.ShowDialog() == true)
            {
                book.Add(bookWindow.books);
                v_list.ItemsSource = null;
                v_list.ItemsSource = book;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if(v_list.SelectedItems != null)
            {
                BookWindow bookWindow = new BookWindow();
                bookWindow.books = v_list.SelectedItem as Book;
                bookWindow.UpdateUI();

                if(bookWindow.ShowDialog() == true)
                {
                    v_list.ItemsSource = null;
                    v_list.ItemsSource = book;
                }

            }
        }

        private void Delate_Click(object sender, RoutedEventArgs e)
        {
            if(v_list.SelectedItems != null)
            {
                book.RemoveAt(v_list.SelectedIndex);

                v_list.ItemsSource = null;
                v_list.ItemsSource = book;
            }
        }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Otwieranie Pliku";
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                List<string> lines = new List<string>();

                using (var streamReader = File.OpenText(openFileDialog.FileName))
                {
                    var s = string.Empty;
                    while ((s = streamReader.ReadLine()) != null)
                        lines.Add(s);
                }

                v_list.ItemsSource = lines;
            }

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Title = "Okno zapisywania do pliku";
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if(saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {                
                List<string> list = new List<string>();
                for (int i = 0; i < book.Count; i++)
                {
                    list.Add(book[i].ToString());
                }
                File.AppendAllLines(saveFileDialog.FileName, list);

                v_list.ItemsSource = null;
                v_list.ItemsSource = book;
            }
        }

        private void font_dialog_Click(object sender, RoutedEventArgs e)
        {
            FontDialog fd = new FontDialog();
            var result = fd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Debug.WriteLine(fd.Font);

                v_list.FontFamily = new FontFamily(fd.Font.Name);
                v_list.FontSize = fd.Font.Size * 96.0 / 72.0;
                v_list.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                v_list.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;

                TextDecorationCollection tdc = new TextDecorationCollection();
                if (fd.Font.Underline) tdc.Add(TextDecorations.Underline);
                if (fd.Font.Strikeout) tdc.Add(TextDecorations.Strikethrough);
                //v_list.TextDecorations = tdc;
            }
        }

        private void font_color_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            var result = cd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                v_list.Foreground = new SolidColorBrush(Color.FromArgb(cd.Color.A, cd.Color.R, cd.Color.G, cd.Color.B));
            }
        }
    }
}
