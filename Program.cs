using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TheEndOfMOdule2
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Form form = new InteractiveForm("Привет, я интерактивчик");
            Application.Run(form);
        }
    }
    public class InteractiveForm : Form
    {
        private bool _mouseOnForm = false;
        public InteractiveForm(string title)
        {
            Text = title; ;
            Height = 600;
            Width = 800;
            StartPosition = FormStartPosition.CenterScreen;

            Button exitButton = CreateButton(new Size(60, 30), new Point(700, 500), "Выход");
            exitButton.Click += (sender, e) => Application.Exit();
            Label label = CreateLabel(new Size(200, 30), new Point(300, 200), "Вы дважды щелкнули по форме");
            label.Visible = false;
            DoubleClick += (sender, e) => ShowLabel(label);
            MouseEnter += (sender, e) => _mouseOnForm = true;
            MouseLeave += (sender, e) => _mouseOnForm = false;
        }

        private void ShowLabel(Label label)
        {
            if (_mouseOnForm) label.Visible = true; 
        }

        private void SetcommonParameters(Control element, Size size, Point position, string title)
        {
            element.Size = size;
            element.Location = position;
            element.Text = title;
            Controls.Add(element);
        }
        private Button CreateButton(Size size, Point position, string title)
        {
            Button button = new Button();
            SetcommonParameters(button,size,position,title);
            return button;
        }
        private Label CreateLabel(Size size, Point position, string title)
        {
            Label label = new Label();
            SetcommonParameters(label, size, position, title);
            return label;
        }
    }
}
