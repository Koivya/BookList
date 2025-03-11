using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SQLitePCL;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BooksList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BooksContext _booksContext;
        public MainWindow()
        {
            InitializeComponent();
            _booksContext = new BooksContext();
            LoadBooks();
        }

        private void LoadBooks()
        {
            var books = _booksContext.Books.ToList();
            booksList.ItemsSource = books;
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            var sortedBooks = _booksContext.Books
                .OrderBy(b => b.Genre)
                .ThenByDescending(b => b.Rating)
                .ToList();

            booksList.ItemsSource = sortedBooks;
        }
    }
}