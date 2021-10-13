using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.Timers;
using System.Windows.Media;

using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Threading;
using System.Windows;

namespace WpfApp2
{

    public static class WorkingMySQLDBHelper
    {
        public static vmMainViewModel MainViewModel { set; get; }

        static WorkingMySQLDBHelper()
        {
            MainViewModel = new vmMainViewModel();
        }
    }


    public partial class vmMainViewModel : INotifyPropertyChanged
    {
        private bool _isConnected;
        private string _user = "root";
        private string _password;

        public string User
        {
            set
            {
                _user = value;
                RaisePropertyChanged("User");
            }
            get => _user;
        }

        public string Password
        {
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
            get => _password;
        }

        public bool IsConnected
        {
            set
            {
                _isConnected = value;
                RaisePropertyChanged("Connection");
            }
            get => _isConnected;
        }

        public bool TryConnect()
        {
            try
            {
                MySqlConnectionStringBuilder _connectionString = new MySqlConnectionStringBuilder();
                Connection = null;

                //задаем логин и пароль подключения, или БД, сервер (localhost)
                _connectionString.AllowBatch = true;
                _connectionString.Server = "127.0.0.1";
                _connectionString.Database = "mysql57";
                _connectionString.UserID = _user;
                _connectionString.ConnectionTimeout = 30;
                _connectionString.Password = Password;

                Connection = new MySqlConnection(_connectionString.ConnectionString);
                Connection.Open();

                IsConnected = true;
                LOG.Clear();
                LOG.Add("Подключение к БД выполнено");

                InitAdapter_results();

                ReadResults();

                RaisePropertyChanged("Results");


                return true;
            }
            catch (Exception e)
            {
                if (Connection != null)
                {
                    Connection.Close();
                }
                LOG.Add(e.Message);
                IsConnected = false;

                return false;
            }
        }

        private string _SQLCommand = "SELECT * FROM results";
        public string SQLCommand
        {
            set
            {
                _SQLCommand = value;
                RaisePropertyChanged("SQLCommand");
            }
            get { return _SQLCommand; }
        }

        public DataTable DoSqlQuery()
        {
            return DoSqlQuery(_SQLCommand);
        }

        public DataTable DoSqlQuery(string SQL)
        {
            try
            {
                using (MySqlCommand cmdSel = new MySqlCommand(SQL, Connection))
                {
                    DataTable dt = new DataTable();
                    MySqlDataAdapter _da = new MySqlDataAdapter(cmdSel);
                    _da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception e)
            {
                LOG.Add(e.Message);
                return null;
            }
        }

        private ObservableCollection<string> log_ = new ObservableCollection<string>();

        private DataTable _results;

        private DataTable _p;
        private DataTable _dp;
        private DataTable _t;

        private DataTable _qm_water;
        private DataTable _qm_oil;
        private DataTable _qv_air;
        private DataTable _time;

        private CartesianChart _selectedPlot = null;


        //public List<int> RatingValues { get; } = new List<int> { 1, 2, 3, 4, 5 };

        private ChartValues<string> _x = new ChartValues<string>(Enumerable.Repeat(" ", 60).ToList());

        private ChartValues<double> _lineSeriesQ_water = new ChartValues<double>(Enumerable.Repeat(0.0, 60).ToList());
        private ChartValues<double> _lineSeriesQ_oil = new ChartValues<double>(Enumerable.Repeat(0.0, 60).ToList());
        private ChartValues<double> _lineSeriesQ_air = new ChartValues<double>(Enumerable.Repeat(0.0, 60).ToList());
        private ChartValues<double> _lineSeriesT = new ChartValues<double>(Enumerable.Repeat(0.0, 60).ToList());
        private ChartValues<double> _lineSeriesP = new ChartValues<double>(Enumerable.Repeat(0.0, 60).ToList());
        private ChartValues<double> _lineSeriesdP = new ChartValues<double>(Enumerable.Repeat(0.0, 60).ToList());

        private Dictionary<string, string> color_dict = new Dictionary<string, string>
        {
            {"PlotQ_water", "#FF2195F2"},
            {"PlotQ_oil", "#FFE86A1B"},
            {"PlotQ_air", "#FFFFFFFF"},
            {"PlotT", "Red"},
            {"PlotP", "Yellow" },
            {"PlotdP", "Green" }
        };


        //private LineSeries _lineSeries = new LineSeries { PointForeground = Brushes.Gray, PointGeometry = DefaultGeometries.Square, PointGeometrySize = 15, Values = new ChartValues<double>(Enumerable.Repeat(0.04, 60).ToList()) };

        public ObservableCollection<string> LOG
        {
            set { log_ = value; RaisePropertyChanged("LOG"); }
            get => log_;
        }


        public CartesianChart CurrentPlot => _selectedPlot;

        public IChartValues CurrentValue
        {
            get            
            {                
                try { return _selectedPlot.Series[0].Values; }
                catch { return null; }
            }
        }

        public string CurrentColor
        {
            get
            {
                try
                {
                    return color_dict[_selectedPlot.Name];
                }
                catch
                {
                    return "#FF000000";
                }
            }
        }


        public CartesianChart SelectedPlot
        {
            set
            {
                _selectedPlot = value;
                LOG.Add("Выбрано: " +  _selectedPlot.Name);
                RaisePropertyChanged("CurrentPlot");
                RaisePropertyChanged("CurrentValue");
                RaisePropertyChanged("CurrentColor");

                RaisePropertyChanged("LOG");
            }
            get
            {
                return _selectedPlot;
            }
        }


        public ChartValues<double> CurrentQ_water => _lineSeriesQ_water;
        public ChartValues<double> CurrentQ_oil => _lineSeriesQ_oil;
        public ChartValues<double> CurrentQ_air => _lineSeriesQ_air;
        public ChartValues<double> CurrentT => _lineSeriesT;
        public ChartValues<double> CurrentP => _lineSeriesP;
        public ChartValues<double> CurrentdP => _lineSeriesdP;



        public ChartValues<string> X => _x;

        public DataTable Results => _results;
        public string LastP => _p.Rows[0][0].ToString();
        public string LastdP => _dp.Rows[0][0].ToString();
        public string LastT => _t.Rows[0][0].ToString();
        public string LastQm_water => _qm_water.Rows[0][0].ToString();
        public string LastQm_oil => _qm_oil.Rows[0][0].ToString();
        public string LastQv_air => _qv_air.Rows[0][0].ToString();
        public string LastCur_time => _time.Rows[0][0].ToString();

        private void ReadX() => _time = DoSqlQuery("SELECT `cur_time` FROM `results` ORDER BY `id` DESC LIMIT 1");
        private void ReadResults() => _results = DoSqlQuery("SELECT `cur_time`, `P`, `dP`, `T`, `Qm_water`, `Qm_oil`, `Qv_air`, `comment` FROM `results`");
        private void ReadLastP() => _p = DoSqlQuery("SELECT `P` FROM `results` ORDER BY `id` DESC LIMIT 1");
        private void ReadLastdP() => _dp = DoSqlQuery("SELECT `dP` FROM `results` ORDER BY `id` DESC LIMIT 1");
        private void ReadLastT() => _t = DoSqlQuery("SELECT `T` FROM `results` ORDER BY `id` DESC LIMIT 1");
        private void ReadLastQm_water() => _qm_water = DoSqlQuery("SELECT `Qm_water` FROM `results` ORDER BY `id` DESC LIMIT 1");
        private void ReadLastQm_oil() => _qm_oil = DoSqlQuery("SELECT `Qm_oil` FROM `results` ORDER BY `id` DESC LIMIT 1");
        private void ReadLastQv_air() => _qv_air = DoSqlQuery("SELECT `Qv_air` FROM `results` ORDER BY `id` DESC LIMIT 1");

        public void UpdateResults()
        {
            try
            {
                _adapterResults.Update(Results);
            }
            catch (Exception e)
            {
                LOG.Add(e.Message);
            }
        }

        public void RefreshResults()
        {
            ReadResults();
            RaisePropertyChanged("Results");
        }

        public void RefreshPlot()
        {
            CurrentQ_water.RemoveAt(0);
            CurrentQ_water.Add(Convert.ToDouble(LastQm_water));

            CurrentQ_oil.RemoveAt(0);
            CurrentQ_oil.Add(Convert.ToDouble(LastQm_oil));

            CurrentQ_air.RemoveAt(0);
            CurrentQ_air.Add(Convert.ToDouble(LastQv_air));

            CurrentT.RemoveAt(0);
            CurrentT.Add(Convert.ToDouble(LastT));

            CurrentP.RemoveAt(0);
            CurrentP.Add(Convert.ToDouble(LastP));

            CurrentdP.RemoveAt(0);
            CurrentdP.Add(Convert.ToDouble(LastdP));

            X.RemoveAt(0);
            X.Add(LastCur_time);

            RaisePropertyChanged("CurrentQ_water");
            RaisePropertyChanged("CurrentQ_oil");
            RaisePropertyChanged("CurrentQ_air");
            RaisePropertyChanged("CurrentT");
            RaisePropertyChanged("CurrentP");
            RaisePropertyChanged("CurrentdP");
            RaisePropertyChanged("X");


            //LOG.Add(LastQm_water);
            //RaisePropertyChanged("LOG");
        }


        ////СПРАВОЧНИКИ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        ////студенты
        //public DataTable student { get { return DoSqlQuery("SELECT `student`.student_id, `student`.`name`, `student`.std_group, `student`.student_status FROM pm349_islamov_a_i.`student`;"); } }

        ////дисциплины
        //public DataTable discipline { get { return DoSqlQuery("SELECT discipline.discipline_id, discipline.title_dis FROM pm349_islamov_a_i.discipline;"); } }

        ////группы
        //public DataTable group { get { return DoSqlQuery("SELECT `group`.group_id, `group`.name_group FROM pm349_islamov_a_i.`group`;"); } }

        ////преподаватели
        //public DataTable teacher { get { return DoSqlQuery("SELECT teacher.teacher_id, teacher.name FROM pm349_islamov_a_i.teacher;"); } }

        ////Статус студента
        //public DataTable std_status { get { return DoSqlQuery("SELECT `std_sess_id`, `std_sess_status` FROM student_session;"); } }

        ////Статус вида контроля
        //public DataTable vrf_status { get { return DoSqlQuery("SELECT `verification_status_id`, `title_ver_status` FROM verification_status;"); } }

        ////оценки
        //public DataTable mark { get { return DoSqlQuery("SELECT `mark_id`, `value` FROM mark;"); } }

        #region ------------------------------------------Члены INotifyPropertyChanged-----------------------------------------------------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        #endregion

        private static DispatcherTimer timer;

        public vmMainViewModel()
        {
            StartTimer();
        }

        private void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Tick;
            timer.Start();
        }


        private void Tick(object sender, EventArgs e)
        {
            if (IsConnected)
            {


                LOG.Add("Данные обновлены!");
                RaisePropertyChanged("LOG");

                ReadLastP();
                ReadLastdP();
                ReadLastT();
                ReadLastQm_water();
                ReadLastQm_oil();
                ReadLastQv_air();

                ReadX();

                RaisePropertyChanged("LastP");
                RaisePropertyChanged("LastdP");
                RaisePropertyChanged("LastT");
                RaisePropertyChanged("LastQm_water");
                RaisePropertyChanged("LastQm_oil");
                RaisePropertyChanged("LastQv_air");

                RefreshPlot();




                //ReadX();
                //RaisePropertyChanged("X");

                //ReadResults();
                //RaisePropertyChanged("Results");
            }
        }
    }

}