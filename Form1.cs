namespace ADFGVXgui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender,  EventArgs e)
        {
            //b
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "C:\\Users\\User\\OneDrive\\Dokumentumok\\_Informatika_2022\\3 - 4_f�l�v\\Asztali �s mobil alkalmaz�sok fejleszt�se �s tesztel�se\\2020_okt�ber_emelt_ADFGVX - rejtjel";
            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    listBox1.Items.Clear();
                    //c
                    string[] kodTabla = File.ReadAllLines(dialog.FileName);
                    //f
                    if (kodTabla.Length!=6)                     //sorok m�rete 6?
                    {
                        listBox1.Items.Add("Hiba a m�trix m�ret�ben");
                        
                    }
                    else
                    {
                        foreach (var i in kodTabla)
                        {
                            if(i.Length!=6) listBox1.Items.Add("Hiba a m�trix m�ret�ben"); //oszlopok m�rete 6?
                        }
                    }
                    bool megfelelo = false;
                    if (kodTabla.Length == 6)
                    {
                        megfelelo = true;
                        
                        foreach (var i in kodTabla)
                        {
                            if (i.Length != 6) megfelelo = false; 
                        }
                    }
                    //g
                    string angol_szam = "qwertzuiopasdfghjklyxcvbnm0123456789";
                    foreach (var i in kodTabla)
                    {
                        foreach (var j in i)
                        {
                            if (!(angol_szam.Contains(j)))
                            {
                                listBox1.Items.Add($"Hib�s karakter {j} van a m�trixban");
                                megfelelo = false;
                            }
                        }
                    }
                    //ism�tl�d� bet�k
                    //h
                    Dictionary<char, int> stat = new Dictionary<char, int>();
                    foreach (var b in angol_szam)
                    {
                        stat[b] = 0;
                    }
                    foreach (var i in kodTabla)
                    {
                        foreach (var j in i)
                        { 
                            if (stat.ContainsKey(j)) stat[j]++;
                            else stat.Add(j, 1);
                         
                        }
                    }
                    foreach (var i in stat)
                    {
                        listBox1.Items.Add($"A(z) {i.Key} karakter {i.Value}x szerepel a m�trixban!");
                    }
                    foreach (var i in stat)
                    { 
                        if(i.Value!=1) megfelelo=false;
                    }
                    //i
                    if (megfelelo)
                    {
                        listBox1.Items.Clear();
                        listBox1.Items.Add("A m�tix megfelel�");
                    }

                    // d            a m�trix ki�rat�sa a listbox-ba
                    label3.Text = "";               
                    foreach (var i in kodTabla)
                    {
                        foreach (var j in i)
                        {
                            label3.Text += j + " ";
                        }
                        label3.Text += "\n";
                    }
                }
                listBox1.Text = "";  //listbox t�rl�se
            }
            catch(Exception ex) 
            {
                listBox1.Items.Add(ex.Message);
                label3.Text = "";
            }
        }
    }
}