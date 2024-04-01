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
            dialog.InitialDirectory = "C:\\Users\\User\\OneDrive\\Dokumentumok\\_Informatika_2022\\3 - 4_félév\\Asztali és mobil alkalmazások fejlesztése és tesztelése\\2020_október_emelt_ADFGVX - rejtjel";
            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    listBox1.Items.Clear();
                    //c
                    string[] kodTabla = File.ReadAllLines(dialog.FileName);
                    //f
                    if (kodTabla.Length!=6)                     //sorok mérete 6?
                    {
                        listBox1.Items.Add("Hiba a mátrix méretében");
                        
                    }
                    else
                    {
                        foreach (var i in kodTabla)
                        {
                            if(i.Length!=6) listBox1.Items.Add("Hiba a mátrix méretében"); //oszlopok mérete 6?
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
                                listBox1.Items.Add($"Hibás karakter {j} van a mátrixban");
                                megfelelo = false;
                            }
                        }
                    }
                    //ismétlõdõ betûk
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
                        listBox1.Items.Add($"A(z) {i.Key} karakter {i.Value}x szerepel a mátrixban!");
                    }
                    foreach (var i in stat)
                    { 
                        if(i.Value!=1) megfelelo=false;
                    }
                    //i
                    if (megfelelo)
                    {
                        listBox1.Items.Clear();
                        listBox1.Items.Add("A mátix megfelelõ");
                    }

                    // d            a mátrix kiíratása a listbox-ba
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
                listBox1.Text = "";  //listbox törlése
            }
            catch(Exception ex) 
            {
                listBox1.Items.Add(ex.Message);
                label3.Text = "";
            }
        }
    }
}