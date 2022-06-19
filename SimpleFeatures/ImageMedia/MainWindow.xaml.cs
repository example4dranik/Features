using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ImageMedia
{
    public partial class MainWindow : Window
    {
        private readonly string CurrentDirectory = Directory.GetCurrentDirectory();
        private readonly string ScrDirectory = "files";
        private readonly string TampleNumber = "#";
        private readonly string TamplePng = "coding#.png";
        private readonly string TampleGif = "coding#.gif";
        private int _startIndex;
        private int _currentIndex;
        private int _lengthIndex;

        public MainWindow()
        {
            _startIndex = 1;
            _currentIndex = _startIndex;
            _lengthIndex = 2;
            InitializeComponent();
        }

        private void ButtonShowImage_Click(object sender, RoutedEventArgs e)
        {
            PreviewImage.Source = new BitmapImage(new Uri(GetPathToFile(TamplePng.Replace(TampleNumber, GetCurrentIndex().ToString()))));
        }

        private void ButtonShowMedia_Click(object sender, RoutedEventArgs e)
        {
            var media = new MediaElement();
            media.Source = new Uri(GetPathToFile(TampleGif.Replace(TampleNumber, GetCurrentIndex().ToString())));
            PreviewMedia.Source = media.Source;
        }

        private string GetPathToFile(string fileName) => System.IO.Path.Combine(CurrentDirectory, ScrDirectory, fileName);

        private int GetCurrentIndex()
        {
            var current = _currentIndex;

            _currentIndex = (_currentIndex + 1 <= _lengthIndex) ? _currentIndex + 1 : _startIndex;

            return current;
        }
    }
}