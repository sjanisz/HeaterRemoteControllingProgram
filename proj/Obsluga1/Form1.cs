using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using ZedGraph;//dołączenie biblioteki
using System.Diagnostics;

namespace Obsluga1
{

    public partial class Form1 : Form
    {
        //Funkcja sluzaca do pobrania listy portow i zwrocenia jej jako List<string>----------------------------------
        List<String> GetAllPorts()
        {
            //Tworzenie listy string o nazwie allPorts
            List<String> allPorts = new List<string>();
            //Pobranie nazw portów szeregowych 
            foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                allPorts.Add(portName);
            }
            //Zwrócenie listy portów jako listy string allPorts
            return allPorts;
        }
        //koniec funkcji pobierania portow ###########################################################################

        Form2 form2 = new Form2(); //tworzenie nowego okna form2 typu Form2
        public static int variable1;
        char tokensign;
        String SerialDataBefore, SerialDataAfter, SerialDataBuffer;
        String RxString; //tu jest wpisywana temperatura z USART
        UInt32 row_counter = 1;//licznik do tabeli danych (licznik punktów pomiarowych)
        public static List<string> temp_list = new List<string>(); //lista stworzona w celu akwizycji danych pomairowych
        FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();//zmienna służąca otworzeniu przeglądania plików
        string save_path;//string zawierający w sobie ścieżkę, gdzie chcemy zapisać plik
        Stopwatch stopWatch = new Stopwatch(); //stoper w celu pomiaru czasu 
        byte[] TimeArray = new byte[241];
        byte[] TemperatureArray = new byte[111];

        //Zmienne sterownika
        bool FlagTempInTimeProcess = false;//ich nie sciagamy z uC bo i tak sie resetuja po podlaczeniu, tylko wysylanie
        bool FlagTempMaxSpeedProcess = false;
        bool FlagRegulationReset = false;//potrzebne?

        byte MainSetpointTemperature;
        byte HeatingTimeChangeInMinutes;

        enum ProgramStatesEnum { OFF, ONFULL, ONTIME };
        ProgramStatesEnum ProgramStates = new ProgramStatesEnum();
        //Metoda wykonujaca się zaraz po włączeniu programu----------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            //Ustawienie w textboxie tBox_portstatus napisu Zamknięty
            tBox_portstatus.Text = "Zamknięty";
            //Ustawienie szybkości transmisji na 9600 baudów (taka sama jak prędkość ustawiona w uC)
            serialPort.BaudRate = 9600;

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            for(byte i = 15;i!=0;i++)
            {
                TimeArray[i - 15] = i;
                comboBox2.Items.Add(TimeArray[i - 15]);
            }
            comboBox2.SelectedIndex = 0;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            for(byte i = 40;i<=150;i++)
            {
                TemperatureArray[i - 40] = i;
                comboBox1.Items.Add(TemperatureArray[i - 40]);
            }
            comboBox1.SelectedIndex = 10;

            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.Items.AddRange(new [] {ProgramStatesEnum.OFF.ToString(),ProgramStatesEnum.ONFULL.ToString(),ProgramStatesEnum.ONTIME.ToString()});
            comboBox3.SelectedIndex = 0;

            ProgramStates = ProgramStatesEnum.OFF;

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox5.Enabled = false;

            form2.Show();
            form2.Activate();
        }
        //koniec funkcji Form1()######################################################################################

        
        //Funkcja obsługi przyciśnięcia przycisku Dodaj (zmienić nazwę przycisku)-------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {            
            //Uzycie funkcji GetAllPorts() (wlasnej) do pobrania listy portow i wpisanie na liste allPorts
            List<String> allPorts = GetAllPorts();
            //czyszczenie obiektów znajdujących się na liście obiektów do wybrania
            comboBox_porty.Items.Clear();
            //czyszczenie wyświetlanego tekstu w polu wyboru portu
            comboBox_porty.ResetText();
            //dodanie do comboboxa wszystkich portow po kolei z listy allPorts
            foreach(String cbox in allPorts)
            {
                comboBox_porty.Items.Add(cbox);
            }           
        }
        //Koniec funkcji button1_Click(object sender, EventArgs e)####################################################



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //serialPort.Write()
        }

        //Funkcja obsługi przycisku Wyjdź z paska---------------------------------------------------------------------
        private void wyjdźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dodatkowy przycisk wyjscia
            Application.Exit();           
        }
        //Koniec funkcji wyjdźToolStripMenuItem_Click(object sender, EventArgs e)#####################################


        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        
        
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       
          
        //Obsługa funkcji przycisku otwierającego port-------------------------------------------------------------
        private void but_openport_Click(object sender, EventArgs e)
        {
            if(comboBox_porty.SelectedItem ==null) //wyswietlenie errora, gdy nie zostalo wybrane nic w comboboxie
            {
                MessageBox.Show("Brak wybranego portu!", "Błąd");
            }
            else {


                if (serialPort.IsOpen == false)
                {
                    serialPort.PortName = comboBox_porty.SelectedItem.ToString();
                    serialPort.Open();
                    tBox_portstatus.Text = "Otwarty: " + comboBox_porty.SelectedItem.ToString();

                    stopWatch.Start();//włączenie odmierzania czasu

                    if (!serialPort.IsOpen) return; //jezeli port zamkniety nie rob nic
                    char[] buff = new char[1];
                    buff[0] = 'o';                  //o - open
                    serialPort.Write(buff, 0, 1);

                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    groupBox5.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Istnieje otwarty port!", "Błąd");
                }               
                       
                 }                       
        }
        //Koniec funkcji but_openport_Click(object sender, EventArgs e)###########################################


        //Obsługa funkcji służacej do zamykania portu-------------------------------------------------------------
        private void but_closeport_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen == true)
            {
                if (!serialPort.IsOpen) return; //jezeli port zamkniety nie rob nic
                char[] buff = new char[1];
                buff[0] = 'c';                  //c - close
                serialPort.Write(buff, 0, 1);

                serialPort.Close();
                tBox_portstatus.Text = "Zamknięty";

                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox5.Enabled = false;

                ProgramStates = ProgramStatesEnum.OFF;
                pictureBox1.Image = Obsluga1.Properties.Resources.reddot;
            } else MessageBox.Show("Aby zamknąć port, należy go najpierw otworzyć!", "Błąd");        
        }
        //Koniec funkcji but_closeport_Click(object sender, EventArgs e)##########################################


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void tBox_portstatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void tBox_main_TextChanged(object sender, EventArgs e)
        {
            
        }
        //Funkcja służąca do zamykania programu (dokładnie to głównego okna formularza)-------------------------
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProgramStates = ProgramStatesEnum.OFF;
            pictureBox1.Image = Obsluga1.Properties.Resources.reddot;

            //MessageBox.Show("Adasd", "Koniec");
            if (serialPort.IsOpen) serialPort.Close();
        }
        //Koniec funkcji Form1_FormClosing(object sender, FormClosingEventArgs e)###############################

        //Queue<char> SDB = new Queue<char>();
        //bool flaga = false;

        //test
        private delegate void UpdateLabel4Delegate(string status);
        private void UpdateLabel4(string status)
        {
            if (this.label4.InvokeRequired)
            {
                this.Invoke(new UpdateLabel4Delegate(this.UpdateLabel4), new object[] { status });
                return;
            }

            this.label4.Text = status;
        }

        private delegate void UpdateLabel5Delegate(string status);
        private void UpdateLabel5(string status)
        {
            if (this.label5.InvokeRequired)
            {
                this.Invoke(new UpdateLabel5Delegate(this.UpdateLabel5), new object[] { status });
                return;
            }

            this.label5.Text = status;
        }

        private delegate void UpdateLabel8Delegate(string status);
        private void UpdateLabel8(string status)
        {
            if (this.label8.InvokeRequired)
            {
                this.Invoke(new UpdateLabel8Delegate(this.UpdateLabel8), new object[] { status });
                return;
            }

            this.label8.Text = status;
        }
        //etest
        //Funkcja służąca do obsługi portu szeregowego----------------------------------------------------------
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Byte[] readByte = new Byte[serialPort.BytesToRead];
            serialPort.Read(readByte, 0, serialPort.BytesToRead);
            SerialDataBefore += System.Text.Encoding.UTF7.GetString(readByte);
            //SerialDataBefore += serialPort.ReadExisting(); //wpisanie tego co jest w porcie do SerialDataBefore
            SerialDataAfter = string.Empty;//tu będą wpisane dane
            int i = 0, serialLength;//i - licznik do pętli, musi być tu bo zostanie użyty jeszcze w switch
            serialLength = SerialDataBefore.Length; //pobranie długości stringu SerialDataBefore do serialLength

            for (; (i < serialLength) && ((SerialDataBefore[i] != '#') && (SerialDataBefore[i] != 't') && (SerialDataBefore[i] != 'm')); i++)//# temp_odcz, t temp_zadana, m czas w minutach narastania 
            {
                    SerialDataAfter += SerialDataBefore[i];
            }

            if (i < serialLength)//jesli petla for nie zakonczyla sie z powodu znaku konca, to warunek sie nie wykona
            {
                switch (SerialDataBefore[i])
                {
                    case '#':                               //w przypadku końcowego znaku # jest to temperatura aktualna
                        //wywołanie funkcji DisplayText
                        RxString = SerialDataAfter;
                        this.Invoke(new EventHandler(DisplayText));
                        break;
                        
                    case 't':                               //t. zadana    
                    MainSetpointTemperature = (byte)SerialDataBefore[i - 1];
                    UpdateLabel4(MainSetpointTemperature.ToString() + " ,C");
                    break;
                    //tutaj inne case'y
                    case 'm':
                    HeatingTimeChangeInMinutes = (byte)SerialDataBefore[i - 1];
                    UpdateLabel5(HeatingTimeChangeInMinutes.ToString() + " ,min");
                    break;
                    default:
                        break;

                }
                SerialDataBefore = SerialDataBefore.Substring(i+1);
            }

            
                
        }
        //Koniec funkcji serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)##################

        //Funkcja: wyświetlanie danych w tabeli, dodawanie danych do listy do pliku txt, wyświetlanie pkt. na wykresie

        
        private void DisplayText(object sender, EventArgs e)
        {
            //tBox_rx.AppendText(RxString);//wysłanie do okienka tBox_rx temperatury
            //tBox_rx.AppendText("\r\n");//wysłanie do okienka tBox_rx nowej lini           

            TimeSpan ts = stopWatch.Elapsed;
           
            //var data = DateTime.Now; //pobranie aktualnej daty
            var data = new DateTime(2020, 6, 3, ts.Hours, ts.Minutes, ts.Seconds);
            //koniec modyfikacji
            var godzina = data.Hour; //pobranie godziny, minuty, sekundy
            var minuta = data.Minute;
            var sekunda = data.Second;
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();//stworzenie wierszu o kolumnach jak w dataGridView1
            row.Cells[0].Value= row_counter; //podanie licznika do kolumny pierwszej
            row.Cells[1].Value = godzina+":"+minuta+":"+sekunda; //podanie czasu do kolumny drugiej
            row.Cells[2].Value = RxString; //podanie temperatury do kolumny trzeciej
            dataGridView1.Rows.Add(row); //dodanie wiersza do tabeli
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1; //przejście okienka na sam dół

            XDate x = new XDate(data);
            form2.Draw(x, RxString, MainSetpointTemperature.ToString());

            string file_string;
            file_string = row_counter.ToString() + "\t" + godzina.ToString() + ":" + minuta.ToString() + ":" +
                sekunda.ToString() + "\t" + RxString;
            temp_list.Add(file_string);        //tworzenie na bierząco listy kolejnych pomiarów w celu pobrania do pliku   


            row_counter++;//zwiększenie licznika punktów pomiarowych
        }
        //Koniec funkcji DisplayText############################################################################
        
        //funckja keypress wyłapuje wcisniete podczas dzialania programu znaki i wpisuje je do tBox_tx a poznej do serialport
        private void tBox_tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!serialPort.IsOpen) return; //jezeli port zamkniety nie rob nic
            char[] buff = new char[1];
            buff[0] = e.KeyChar;
            serialPort.Write(buff, 0, 1);
            //e.Handled = true;
        }
        //koniec funkcji#########################################################################################

        private void tBox_rx_TextChanged(object sender, EventArgs e)
        {

        }

        private void tBox_rx_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //FUNKCJA słuząca do pobrania ścieżki gdzie znajdzie się plik z danymi-----------------------------------
        private void button1_Click_1(object sender, EventArgs e)
        {
    
            DialogResult dialog = folderBrowserDialog1.ShowDialog();//pokazanie okienka wyboru folderu oraz zapisanie wyniku tego, czy zostałą wybrana jakaś ścieżka do zmiennej
            if(dialog==DialogResult.OK)//jeżeli wybrana została ścieżka to wykonaj:
            {
                save_path = folderBrowserDialog1.SelectedPath;//pobranie ścieżki do stringu save_path
                tBox_selectedPath.Text = save_path;//wpisanie save_path do tBoxa
            }
        }
        //koniec funkcji#########################################################################################

        //FUNKCJA do zapisu do pliku-----------------------------------------------------------------------------
        private void but_savedata_Click(object sender, EventArgs e)
        {
            if(tBox_selectedPath.Text=="")
            {
                MessageBox.Show("Wybierz ścieżkę zapisu pliku!", "Błąd");
            }else
            {
                Queue<string> final_list = new Queue<string>(temp_list);
                int final_list_size = final_list.Count;
                if (final_list_size > 0)
                {
                    var data = DateTime.Now;
                    string filedate = (data.Day).ToString() + " " + data.ToString("MMMM") + " " + (data.Hour).ToString() + "-" + (data.Minute).ToString() + "-" + (data.Second).ToString();
                    string final_directory = save_path + "\\" + filedate + ".txt";
                    string[] final_string = new string[final_list_size+1];
                    final_string[0] = "Pomiar temperatury, data utworzenia: " + data.ToString("MMM ddd d HH:mm yyyy") + " Format: Numer próbki - czas - wartość próbki";
                    for (int i = 1; i <= final_list_size;i++ )
                    {
                        final_string[i] = final_list.Dequeue();
                    }
                        System.IO.File.WriteAllLines(final_directory,final_string);
                        MessageBox.Show(final_directory);
                }else
                {
                    MessageBox.Show("Brak danych do zapisu!", "Błąd");
                }
            }
            
        }
        //koniec funkcji##########################################################################################


        //FUNKCJA do pokazywania ciągle otwartego okna z wykresem-------------------------------------------------
        private void but_graph_Click(object sender, EventArgs e)
        {
            
            form2.Show();   //pokaż wykres
            form2.Activate(); //po naciśnięciu wykres staje się aktywnym oknem
        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            ProgramStates = ProgramStatesEnum.OFF;
            pictureBox1.Image = Obsluga1.Properties.Resources.reddot;

            MainSetpointTemperature = Byte.Parse(comboBox1.Text);
            UpdateLabel4(MainSetpointTemperature.ToString() + " ,C");

            if (!serialPort.IsOpen) return; //jezeli port zamkniety nie rob nic
            byte[] buff = new byte[2];
            buff[0] = (byte)'t';                  //t - set temp
            buff[1] = MainSetpointTemperature;
            serialPort.Write(buff, 0, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProgramStates = ProgramStatesEnum.OFF;
            pictureBox1.Image = Obsluga1.Properties.Resources.reddot;

            HeatingTimeChangeInMinutes = Byte.Parse(comboBox2.Text);
            UpdateLabel5(HeatingTimeChangeInMinutes.ToString() + " ,min");

            if (!serialPort.IsOpen) return; //jezeli port zamkniety nie rob nic
            byte[] buff = new byte[2];
            buff[0] = (byte)'m';                  //m - minutes, heating time
            buff[1] = HeatingTimeChangeInMinutes;
            serialPort.Write(buff, 0, 2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) return; //jezeli port zamkniety nie rob nic
            byte[] buff;
            switch(comboBox3.Text)
            {
                case "OFF":
                    ProgramStates = ProgramStatesEnum.OFF;
                    pictureBox1.Image = Obsluga1.Properties.Resources.reddot;

                    buff = new byte[1];
                    buff[0] = (byte)'s';                  //s -cancel, stop                   
                    serialPort.Write(buff, 0, 1);
                    break;
                case "ONFULL":
                    ProgramStates = ProgramStatesEnum.ONFULL;
                    pictureBox1.Image = Obsluga1.Properties.Resources.greendot;

                    buff = new byte[1];
                    buff[0] = (byte)'f';                  //f -onfull                  
                    serialPort.Write(buff, 0, 1);
                    break;
                case "ONTIME":
                    ProgramStates = ProgramStatesEnum.ONTIME;
                    pictureBox1.Image = Obsluga1.Properties.Resources.greendot;

                    buff = new byte[1];
                    buff[0] = (byte)'i';                  //i -ontime                  
                    serialPort.Write(buff, 0, 1);
                    break;
            }
            UpdateLabel8(ProgramStates.ToString());
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void informacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autor: Janisz Szymon\nKontakt: szymon.janisz.et.di@gmail.com", "Informacje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //koniec funkcji##########################################################################################

        
    }
}
