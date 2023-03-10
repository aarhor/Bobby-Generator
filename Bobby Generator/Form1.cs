namespace Bobby_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> Wort_Liste = new List<string>();
        int r = 0;
        Random random = new Random();

        void Shutdown()
        {
            int i = 0;
            while (i < 10)
            {
                DialogResult result = MessageBox.Show("Möchten sie ihren PC herunterfahren?", "8UNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    MessageBox.Show("Sind sie sich ganz sicher????\nBitte einmal erneut bestätigen.");
                else
                    MessageBox.Show("Das ist aber schade :(");
                i++;
            }
        }

        public void Generator()
        {
            string FileToRead = Application.StartupPath + @"Resources\Woerter.txt";
            using (StreamReader ReaderObject = new StreamReader(FileToRead, System.Text.Encoding.UTF8))
            {
                string Line;
                while ((Line = ReaderObject.ReadLine()) != null)
                {
                    Wort_Liste.Add(Line);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread myThread = new Thread(Generator);

            if (!(Wort_Liste.Count >= 3))
            {
                myThread.Start();
                button1.Text = "Bobby Generieren";
            }
            else
            {
                r = random.Next(Wort_Liste.Count);
                string Wort = (string)Wort_Liste[r];
                label2.Text = r.ToString() + " von " + Wort_Liste.Count.ToString();

                if (r % 1337 == 0)
                {
                    DialogResult result = MessageBox.Show("Möchten sie ihren PC herunterfahren?", "8UNG", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        Shutdown();
                    else
                        Shutdown();
                }
                label1.Text = "Bobby " + Wort;
            }
        }
    }
}