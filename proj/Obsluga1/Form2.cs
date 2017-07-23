using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Obsluga1
{
    public partial class Form2 : Form
    {
        int TickStart;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
            SetSize();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void CreateGraph (ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;

            myPane.Title.Text = "Wykres";           
            myPane.XAxis.Title.Text = "czas";
            myPane.YAxis.Title.Text = "temperatura, st. C";

            //RollingPointPairList to wydajna klasa FIFO stworzona specjalnie dla obsługi wykresów zedgraph
            RollingPointPairList list_readings = new RollingPointPairList(64000);//64000, ponieważ daje nam to możliwość zapisu 64000 punktów, czyli brak utraty danych nawet po 4h przy zapisie 5 punktów na sekundę
            RollingPointPairList list_setpoints = new RollingPointPairList(64000);

            //tworzenie krzywych (wartość odczytana i zadana) bez wartości początkowych
            LineItem curve_readings = myPane.AddCurve("Wartość obecna", list_readings, Color.Red, SymbolType.None);
            LineItem curve_setpoints = myPane.AddCurve("Wartość zadana", list_setpoints, Color.Blue, SymbolType.None);
            curve_readings.Line.Width = 2.0f;
            curve_setpoints.Line.Width = 2.0f;
            //Zakresy osi jakie załadują się po wywołaniu CreateGraph
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Scale.Format = "HH:mm:ss";
            myPane.XAxis.Scale.MajorUnit = DateUnit.Second;
            myPane.XAxis.Scale.MinorUnit = DateUnit.Second;
            //myPane.XAxis.Scale.MajorStep = 10;
            //myPane.XAxis.Scale.MinorStep = 1;   
                       
            DateTime scaleDate = new DateTime(2020, 6, 3, 0, 0, 0);
            myPane.XAxis.Scale.Min = new XDate(scaleDate);
            myPane.XAxis.Scale.Max = new XDate(scaleDate.AddSeconds(60));
             
            //myPane.XAxis.Scale.Min = new XDate(DateTime.Now);
            //myPane.XAxis.Scale.Max = new XDate(DateTime.Now.AddSeconds(60));

            //SPRAWA SIATKI
            myPane.XAxis.MinorGrid.IsVisible = true;
            myPane.YAxis.MinorGrid.IsVisible = true;
            myPane.XAxis.MinorGrid.Color = Color.LightGray;
            myPane.YAxis.MinorGrid.Color = Color.LightGray;
            myPane.XAxis.MinorGrid.DashOff = 0;
            myPane.YAxis.MinorGrid.DashOff = 0;

            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.Color = Color.Gray;
            myPane.YAxis.MajorGrid.Color = Color.Gray;
            myPane.XAxis.MajorGrid.DashOff = 0;
            myPane.YAxis.MajorGrid.DashOff = 0;
            /*
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.XAxis.Scale.MajorStep = 5;
            myPane.XAxis.Scale.MinorStep = 1;
            */
            //Wyskalowanie osi
            zgc.AxisChange();

            //Zapis czasu początkowego po wywołaniu CreateGraph (potrzebne jako czas odniesienia przy skalowaniu osi)
            //TickStart = Environment.TickCount;
            
        }

        private void SetSize()
        {
            zedGraphControl1.Location = new Point(10, 10);
            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20);
        }

        public void Draw(XDate x, string reading, string setpoint)
        {
            double intreading;
            double intsetpoint;
            double.TryParse(reading,out intreading);
            double.TryParse(setpoint,out intsetpoint);

            if (zedGraphControl1.GraphPane.CurveList.Count <= 0) return;//sprawdź czy są jakieś krzywe (powinny być)

            LineItem curve_readings = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            LineItem curve_setpoints = zedGraphControl1.GraphPane.CurveList[1] as LineItem;

            if ((curve_readings == null) || (curve_setpoints == null)) return;

            IPointListEdit list_readings = curve_readings.Points as IPointListEdit;
            IPointListEdit list_setpoints = curve_setpoints.Points as IPointListEdit;

            if ((list_readings == null) || (list_setpoints == null)) return;

            //XDate time = new XDate(DateTime.Now.ToOADate());
            list_readings.Add(x, intreading);
            list_setpoints.Add(x, intsetpoint);

            if(x>zedGraphControl1.GraphPane.XAxis.Scale.Max)
            {
                XDate minDate = new XDate(zedGraphControl1.GraphPane.XAxis.Scale.Max);
                minDate.AddSeconds(15);
                zedGraphControl1.GraphPane.XAxis.Scale.Max = minDate;
            }
            
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

        }
        //FUNCKJA SŁUŻĄCA do chowania formatki, NIE ZAMYKANIA! ---------------------------------------------------
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();//przy zamykaniu schowaj formatke
            e.Cancel = true;//zapobiegnij zamknięciu formatki (w połączeniu z Hide tylko ją chowa)
        }
        //koniec funkcji##########################################################################################
    }
}
