using System.Windows;

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