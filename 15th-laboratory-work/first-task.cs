using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOPExample
{
    public class FixedSizeForm : Form
    {
        private Button closeButton;

        public FixedSizeForm()
        {
            InitializeForm();
            InitializeCloseButton();
        }

        private void InitializeForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new Size(300, 200);
        }

        private void InitializeCloseButton()
        {
            closeButton = new Button();
            closeButton.Text = "Закрити";
            closeButton.Location = new Point((this.ClientSize.Width - closeButton.Width) / 2, this.ClientSize.Height - closeButton.Height - 10);
            closeButton.Click += CloseButton_Click;
            this.Controls.Add(closeButton);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FixedSizeForm());
        }
    }
}
