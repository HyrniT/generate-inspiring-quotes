using System;
using System.IO;
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


namespace InspiringQuotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome to Inspiration Quotes App");

            setupData();

            nextQuote();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            nextQuote();
        }

        //-------------------------------------------------------------------------------------------------------------WEEK 01

        //List<string> _images;
        //List<string> _quotes;
        //List<string> _authors;

        /*
        private void setupData()
        {
            _quotes = new List<string>{
                "We can't solve problems with the kind of thinking employed when came up with them.",
                "Learn as if you will live forever, live like you will die tomorrow.",
                "Nothing is impossible. The word itself says 'I'm possible!",
                "The bad news is time flies. The good news is you're the pilot.",
                "When you change your thoughts, remember to also change your world.",
                "Keep your face always toward the sunshine, and shadows will fall behind you.",
                "You are never too old to set another goal or to dream a new dream.",
                "Success is not final; failure is not fatal: It is the courage to continue that counts.",
                "It is better to fail in originality than to succeed in imitation.",
                "The road to success and the road to failure are almost exactly the same.",
            };

            _images = new List<string>
            {
                "/Images/img0.jpg",
                "/Images/img1.jpg",
                "/Images/img2.jpg",
                "/Images/img3.jpg",
                "/Images/img4.jpg",
                "/Images/img5.jpg",
                "/Images/img6.jpg",
                "/Images/img7.jpg",
                "/Images/img8.jpg",
                "/Images/img9.jpg",
            };

            _authors = new List<string>
            {
                "- Albert Einstein",
                "- Mahatma Gandhi",
                "- Audrey Hepburn",
                "- Michael Altshuler",
                "- Norman Vincent Peale",
                "- Walt Whitman",
                "- Malala Yousafzain",
                "- Winston S. Churchill",
                "- Herman Melville",
                "- Colin R. Davis",
            };
        }

        private void nextQuote()
        {
            int i = new Random().Next(0, _quotes.Count);

            string quote = _quotes[i];
            quoteTextBlock.Text = quote;

            string author = _authors[i];
            authorTextBlock.Text = author;

            var bitmap = new BitmapImage(
                new Uri(_images[i], UriKind.Relative)
            );
            quoteImage.Source = bitmap;
        }
        */


        //-------------------------------------------------------------------------------------------------------------WEEK 02

        class Quote
        {
            private string _conternt;
            private string _author;
            private string _image;

            public string Content { get; set; }
            public string Author { get; set; }
            public string Image { get; set; }  
            public Quote()
            {
                _conternt = "";
                _author = "";
                _image = "";
            }
            
        }
        
        List<Quote> Quotes = new List<Quote>();

        private void setupData()
        {
            string fileName = "data.txt";
            string[] lines = System.IO.File.ReadAllLines(fileName);

            //var quotes = new List<Quote>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] tokens = lines[i].Split(new string[] { ";" }, StringSplitOptions.None);

                string content = tokens[0];
                string author = tokens[1];
                string image = tokens[2];

                var quote = new Quote
                {
                    Content = content,
                    Author = author,
                    Image = image,
                };

                Quotes.Add(quote);
            }
        }

        private void nextQuote()
        {
            int i = new Random().Next(0, Quotes.Count);

            string content = Quotes[i].Content;
            quoteTextBlock.Text = content;

            string author = "- " + Quotes[i].Author;
            authorTextBlock.Text = author;

            string baseUri = AppDomain.CurrentDomain.BaseDirectory;
            string imageUri = Quotes[i].Image;
            string uri = $"{baseUri}{imageUri}";
            var bitmap = new BitmapImage(new Uri(uri, UriKind.Absolute));
            quoteImage.Source = bitmap;
        }
    }
}

