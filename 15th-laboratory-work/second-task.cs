using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace OOPExample
{
    public class FixedSizeForm : Form
    {
        private Button closeButton, okButton;
        private TextBox inputTextBox, fileNameTextBox, outputTextBox;
        private Label outputLabel;

        public FixedSizeForm()
        {
            InitializeForm();
            InitializeCloseButton();
            InitializeInputTextBox();
            InitializeOkButton();
            InitializeFileNameTextBox();
            InitializeOutputLabel();
            InitializeOutputTextBox();
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

        private void InitializeInputTextBox()
        {
            inputTextBox = new TextBox();
            inputTextBox.Location = new Point(10, 10);
            inputTextBox.Size = new Size(280, 20);
            inputTextBox.KeyDown += InputTextBox_KeyDown;
            this.Controls.Add(inputTextBox);
        }

        private void InitializeOkButton()
        {
            okButton = new Button();
            okButton.Text = "OK";
            okButton.Location = new Point(10, 40);
            okButton.Click += OkButton_Click;
            this.Controls.Add(okButton);
        }

        private void InitializeFileNameTextBox()
        {
            fileNameTextBox = new TextBox();
            fileNameTextBox.Location = new Point(10, 70);
            fileNameTextBox.Size = new Size(280, 20);
            this.Controls.Add(fileNameTextBox);
        }

        private void InitializeOutputLabel()
        {
            outputLabel = new Label();
            outputLabel.Location = new Point(10, 100);
            outputLabel.Size = new Size(280, 20);
            this.Controls.Add(outputLabel);
        }

        private void InitializeOutputTextBox()
        {
            outputTextBox = new TextBox();
            outputTextBox.Location = new Point(10, 130);
            outputTextBox.Size = new Size(280, 20);
            outputTextBox.ReadOnly = true;
            this.Controls.Add(outputTextBox);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProcessInput();
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            string input = inputTextBox.Text;
            string reversed = string.Join(" ", input.Split(' ').Reverse());
            outputLabel.Text = $"Кількість символів: {input.Length}";
            SaveToFile(input);
            outputTextBox.Text = LoadFromFile();
        }

        private void SaveToFile(string input)
        {
        string fileName = fileNameTextBox.Text;
        if (string.IsNullOrWhiteSpace(fileName))
        {
            MessageBox.Show("Будь ласка, введіть ім'я файлуа.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            File.WriteAllText(fileName, input);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Не вдалося зберегти файл: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private string LoadFromFile()
    {
        string fileName = fileNameTextBox.Text;
        if (string.IsNullOrWhiteSpace(fileName))
        {
            MessageBox.Show("Будь ласка, введіть ім'я файлу.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return string.Empty;
        }

        try
        {
            string content = File.ReadAllText(fileName);
            return string.Join(" ", content.Split(' ').Reverse());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Не вдалося зчитати файл: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return string.Empty;
        }
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
