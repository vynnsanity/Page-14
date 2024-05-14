using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Page_14
{
    public partial class Form1 : Form
    {
        private PictureBox[] stars;
        private int rating = 0;
        public Form1()
        {
            InitializeComponent();
            InitializeStarRating();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UpdateRating(int ratingNumber)
        {
            rating = ratingNumber;
            MessageBox.Show("You rated the product " + rating + " stars.");
        }

        private void InitializeStarRating()
        {
            stars = new PictureBox[] { starOne, starTwo, starThree, starFour, starFive };

            foreach (var star in stars)
            {
                star.MouseEnter += Star_MouseEnter;
                star.MouseLeave += Star_MouseLeave;
                star.Click += Star_Click;
            }
        }

        private void Star_MouseEnter(object sender, EventArgs e)
        {
            int starIndex = Array.IndexOf(stars, sender);
            HighlightStars(starIndex + 1);
        }

        private void Star_MouseLeave(object sender, EventArgs e)
        {
            HighlightStars(rating);
        }

        private void Star_Click(object sender, EventArgs e)
        {
            int starIndex = Array.IndexOf(stars, sender);
            int ratingNumber = starIndex + 1;
            rating = ratingNumber;
            HighlightStars(rating);
            UpdateRating(rating);
        }

        private void HighlightStars(int starsToHighlight)
        {
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].BackColor = (i < starsToHighlight) ? Color.Gold : Color.Gray;
            }
        }
    }
}
