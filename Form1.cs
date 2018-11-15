using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

using System.Threading;
using System.Runtime.Remoting.Messaging;


namespace SeriesSortCleanup
{
    public partial class Form1 : Form
    {
        DataTable dtInfo = new DataTable();
        List<string> feedback = new List<string>();

        public Form1()
        {
            InitializeComponent();

            //Sort Directories fields
            txtDestination.Text = Properties.Settings.Default.destinationDir.ToString();
            txtSource.Text = Properties.Settings.Default.sourceDir.ToString();

            //Check and export Directories fields
            txtCheckSource.Text = Properties.Settings.Default.sourceDirCheck.ToString();
            txtCheckDestination.Text = Properties.Settings.Default.destinationDirCheck.ToString();
            txtSizeMB.Text = Properties.Settings.Default.WarningSize.ToString();

            //Rename and Extract directories fields
            txtRenameTargetDir.Text = Properties.Settings.Default.TargetDirRename.ToString();
            txtWinrarSrcDir.Text = Properties.Settings.Default.WinRARDir.ToString();
            txtRenameSize.Text = Properties.Settings.Default.MinRenameSize.ToString();
        }

        private void AddFeedback(string text)
        {
            txtFeedback.AppendText(text + "\n");
        }

        private void ClearFeedback()
        {
            txtFeedback.Clear();
        }




        #region CHECK DIRECTORY

        #region CHECK DIR Global Variables

        string _sCheckSrcPath = "";
        string _sCheckDestPath = "";

        long _lDirBytes = 0;
        int MaxDirSize = 0;

        List<string> dirs;
        List<string> DirWarning;

        int CheckStep = 0;

        #endregion


        #region CHECK DIR Functions

        private void CheckFiles()
        {
            try
            {
                _lDirBytes = 0;

                dirs = new List<string>(Directory.EnumerateDirectories(_sCheckSrcPath));
                DirWarning = new List<string>();

                foreach (var dir in dirs)
                {
                    string _sOutput = dir.Substring(dir.LastIndexOf("\\") + 1);
                    long _lCurrentDirByte = GetDirectorySize(dir);

                    _lDirBytes += _lCurrentDirByte;
                    decimal _dTest = ConvertToMB(_lCurrentDirByte);

                    string _stest = String.Format("{0:0.00}  MB", _dTest);

                    if (Convert.ToInt32(_dTest) > MaxDirSize)
                    {
                        DirWarning.Add(dir);
                    }

                    if (_stest.Length > 8)
                    {
                        feedback.Add(string.Format("{0:0.00}  MB\t {1}", _dTest, _sOutput));
                    }
                    else
                    {
                        feedback.Add(string.Format("{0:0.00}  MB\t\t {1}", _dTest, _sOutput));
                    }
                }
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }
        }

        private decimal ConvertToMB(long _lBytes)
        {
            decimal _dConvert = 0;

            // To Kilo bytes
            _dConvert = _lBytes / 1024;

            // To Mega bytes
            _dConvert = _dConvert / 1024;

            return _dConvert;
        }

        static long GetDirectorySize(string p)
        {
            // 1.
            // Get array of all file names.
            //string[] a = Directory.GetFiles(p, "*.*");
            string[] a = Directory.GetFiles(p, "*.*", SearchOption.AllDirectories);

            // 2.
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4.
            // Return total size
            return b;
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void MoveDir(int step)
        {
            if (DirWarning.Count > step)
            {
                string path = DirWarning[step].ToString();

                string[] nameArray = path.Split('\\');

                string folder = nameArray[nameArray.Length - 1];
                string _sDestPath = string.Format(@"{0}\{1}", _sCheckDestPath, folder);

                if (!Directory.Exists(_sDestPath))
                {
                    Directory.Move(path, _sDestPath);
                    feedback.Add(string.Format("Dir Moved - {0}", path));
                }
                else
                {
                    feedback.Add(string.Format("** Dir already exist - {0}", _sDestPath));
                }

                CheckStep++;
            }

        }

        #endregion


        #region CHECK DIR Async Threading

        private delegate void MyCheckTaskWorkerDelegate(int StepCounter);

        private bool _myCheckTaskIsRunning = false;

        //This property indicates a running asynchronous operation
        public bool IsCheckBusy
        {
            get { return _myCheckTaskIsRunning; }
        }

        //This method invokes the asynchronous operation and immediately returns. 
        //If an asynchronous operation is already running, an InvalidOperati­onException is thrown.
        public void MyCheckTaskAsync(int StepCounter)
        {
            MyCheckTaskWorkerDelegate worker = new MyCheckTaskWorkerDelegate(MoveDir);
            AsyncCallback completedCallback = new AsyncCallback(MyCheckTaskCompletedCallback);

            lock (_Checksync)
            {
                if (_myCheckTaskIsRunning)
                    throw new InvalidOperationException("The control is currently busy.");

                AsyncOperation async = AsyncOperationManager.CreateOperation(null);
                worker.BeginInvoke(StepCounter, completedCallback, async);
                _myTaskIsRunning = true;
            }
        }

        private readonly object _Checksync = new object();

        //This method calls worker delegate's En­dInvoke method to finish the asynchronous operation and raises the MyTaskCompleted e­vent
        private void MyCheckTaskCompletedCallback(IAsyncResult ar)
        {

            // get the original worker delegate and the AsyncOperation instance
            MyCheckTaskWorkerDelegate worker = (MyCheckTaskWorkerDelegate)((AsyncResult)ar).AsyncDelegate;
            AsyncOperation async = (AsyncOperation)ar.AsyncState;

            // finish the asynchronous operation
            worker.EndInvoke(ar);

            // clear the running task flag
            lock (_Checksync)
            {
                _myCheckTaskIsRunning = false;
            }

            // raise the completed event
            AsyncCompletedEventArgs completedArgs = new AsyncCompletedEventArgs(null, false, null);
            async.PostOperationCompleted(delegate(object e) { OnMyCheckTaskCompleted((AsyncCompletedEventArgs)e); }, completedArgs);
        }

        //This event is raised when the asynchronous operation is completed
        public event AsyncCompletedEventHandler MyCheckTaskCompleted;

        protected virtual void OnMyCheckTaskCompleted(AsyncCompletedEventArgs e)
        {
            if (MyCheckTaskCompleted != null)
            {
                MyCheckTaskCompleted(this, e);
            }
            else
            {
                //lblProgress.Text = string.Format("{0}  /  {1}", step.ToString(), max.ToString());

                foreach (var item in feedback)
                {
                    AddFeedback(item);
                }

                feedback.Clear();

                //AddFeedback("--------------------------------------------------------------");
                //AddFeedback("");

                //progressBar1.PerformStep();
                //progressBar1.Update();

                if (CheckStep != max)
                {
                    //string Source = dtInfo.Rows[step]["Path"].ToString();
                    //AddFeedback(string.Format("Source Location \t: {0}", Source));

                    MyCheckTaskAsync(CheckStep);
                }
                else
                {
                    //    AddFeedback(string.Format("{0} files were copied.", FileCounter.ToString()));
                    //    AddFeedback(string.Format("{0} files already existed.", AlreadyExisted.ToString()));
                    //    AddFeedback(string.Format("{0} files were skipped or invalid.", skipped.ToString()));
                    //    AddFeedback("--------------------------------------------------------------");
                    //    AddFeedback(string.Format("{0} files were processed in total.", step.ToString()));

                    //    WriteToLog();

                    AddFeedback("");
                    AddFeedback("--------------------------------------------------------------");
                    AddFeedback("DONE.");

                    WriteToLog();
                }
            }
        }

        #endregion


        #region CHECK DIR EVENTS

        private void btnCheckSourceBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderDiag = new FolderBrowserDialog();
            DialogResult result = FolderDiag.ShowDialog();
            if (result == DialogResult.OK)
            {
                _sCheckSrcPath = FolderDiag.SelectedPath;
                txtCheckSource.Text = _sCheckSrcPath;
            }
        }

        private void btnCheckDestBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderDiag = new FolderBrowserDialog();
            DialogResult result = FolderDiag.ShowDialog();
            if (result == DialogResult.OK)
            {
                _sCheckDestPath = FolderDiag.SelectedPath;
                txtCheckDestination.Text = _sCheckDestPath;
            }
        }

        private void btnCheckDir_Click(object sender, EventArgs e)
        {
            ClearFeedback();
            feedback.Clear();

            AddFeedback("Checking directory for warning sizes:");
            AddFeedback("");

            string WarningSizeText = txtSizeMB.Text;

            if (WarningSizeText != "" && WarningSizeText != null)
            {
                if (IsDigitsOnly(WarningSizeText))
                {
                    MaxDirSize = Convert.ToInt32(txtSizeMB.Text);
                    Properties.Settings.Default.WarningSize = MaxDirSize;
                }
                else
                {
                    return;
                }
            }

            _sCheckSrcPath = txtCheckSource.Text;

            Properties.Settings.Default.sourceDirCheck = _sCheckSrcPath;
            Properties.Settings.Default.Save();


            CheckFiles();


            foreach (var item in feedback)
            {
                AddFeedback(item);
            }

            feedback.Clear();

            int iWarnings = DirWarning.Count;

            AddFeedback("");
            AddFeedback(string.Format("{0} Directories have size warnings.", iWarnings.ToString()));
        }

        private void btnCheckExport_Click(object sender, EventArgs e)
        {
            feedback.Clear();

            AddFeedback("");
            AddFeedback("Moving directories...");
            AddFeedback("");

            _sCheckDestPath = txtCheckDestination.Text;
            Properties.Settings.Default.destinationDirCheck = _sCheckDestPath;
            Properties.Settings.Default.Save();

            CheckStep = 0;

            if (DirWarning.Count > 0)
            {
                max = DirWarning.Count;

                if (_sCheckDestPath != "")
                {
                    if (Directory.Exists(_sCheckDestPath))
                    {
                        MyCheckTaskAsync(CheckStep);

                        //foreach (var Dir in DirWarning)
                        //{
                        //    MoveDir(Dir);    

                        //    AddFeedback(string.Format("Dir Moved - {0}", Dir));
                        //}
                    }
                    else
                    {
                        AddFeedback(string.Format("Dir does not exist - {0}", _sCheckDestPath));
                    }
                }
                else
                {
                    AddFeedback("Not a valid Export Dir.");
                }
            }
            else
            {
                AddFeedback("No Warning Directories To Move.");
            }
        }

        #endregion

        #endregion




        #region SORT DIRectory
        

        #region SORT Global Variables

        int FileCounter = 0;
        int max = 0;
        int step = 0;
        int AlreadyExisted = 0;
        int skipped = 0;

        string _sSrcPath = "";
        string _sDestPath = "";

        Regex num3_Format = new Regex("([0-9])([0-9])([0-9])");
        Regex num4_Format = new Regex("([0-9])([0-9])([0-9])([0-9])");
        Regex SxxExx_Format = new Regex("([s,S])([0-9])([0-9])([e,E])([0-9])([0-9])");
        Regex Sxx_Format = new Regex("([s,S])([0-9])([0-9])");
        Regex Sx_Format = new Regex("([s,S])([0-9])");
        Regex NxNN_Format = new Regex("[0-9]x[0-9][0-9]");
        Regex x264_Format = new Regex("x264");
        Regex NewsHost_Format = new Regex("NewsHost");

        Regex REG_num3_Format = new Regex("([0-9])([0-9])([0-9])");
        Regex REG_num4_Format = new Regex("([0-9])([0-9])([0-9])([0-9])");
        Regex REG_SxxExx_Format = new Regex("([s,S])([0-9])([0-9])([e,E])([0-9])([0-9])");
        Regex REG_Sxx_Format = new Regex("([s,S])([0-9])([0-9])");
        Regex REG_Sx_Format = new Regex("([s,S])([0-9])");
        Regex REG_NxNN_Format = new Regex("[0-9]x[0-9][0-9]");
        Regex REG_x264 = new Regex("(?i)x264");
        Regex REG_NewsHost = new Regex("(?i)newshost");
        Regex REG_xxxp = new Regex("([0-9][0-9][0-9][p,P])");

        #endregion


        #region Sort Functions

        private void CreateDir(string name)
        {
            try
            {
                string path = _sDestPath + name;
                Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                AddFeedback(string.Format("Create Directory error : {0}", ex.ToString()));
            }
        }

        private void CreateDir(string name, string path)
        {
            try
            {
                path = path + name;
                Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                AddFeedback(string.Format("Create Directory error : {0}", ex.ToString()));
            }
        }

        //private int getSeason(string name, out int index)  
        //{
        //    //  EXAMPLES  
        //    //  ncis.los.angeles.601.hdtv-lol
        //    //  Person.of.Interest.S04E02.HDTV.x264-LOL-NewsHost-2753
        //    //  House.of.Cards.2013.S01.480p.BluRay.nSD.x264-NhaNc3-NewsHost-3092

        //    try
        //    {
        //        int count = 0;
        //        index = -1;

        //        string[] nameArray = name.Split('.');

        //        for (int i = nameArray.Length - 1; i >= 0; --i)
        //        //for (int i = 0; i < nameArray.Length; i++)
        //        {
        //            string testVal = nameArray[i];

        //            if (NewsHost_Format.Match(testVal).Success)
        //            {
        //                // Do nothing move and on
        //            }
        //            else if (x264_Format.Match(testVal).Success)
        //            {
        //                // Do nothing move and on
        //            }
        //            else if (SxxExx_Format.Match(testVal).Success)
        //            {
        //                count = Convert.ToInt32(testVal.Substring(1, 2));
        //                index = i;
        //                return count;
        //            }
        //            else if (Sxx_Format.Match(testVal).Success)
        //            {
        //                count = Convert.ToInt32(testVal.Substring(1, 2));
        //                index = i;
        //                return count;
        //            }
        //            else if (Sx_Format.Match(testVal).Success)
        //            {
        //                count = Convert.ToInt32(testVal.Substring(1, 1));
        //                index = i;
        //                return count;
        //            }
        //            else if (num4_Format.Match(testVal).Success)
        //            {
        //                count = Convert.ToInt32(testVal.Substring(0, 2));
        //                index = i;
        //                return count;
        //            }
        //            else if (NxNN_Format.Match(testVal).Success)
        //            {
        //                count = Convert.ToInt32(testVal.Substring(0, 1));
        //                index = i;
        //                return count;
        //            }
        //            else if (num3_Format.Match(testVal).Success)
        //            {
        //                count = Convert.ToInt32(testVal.Substring(0, 1));
        //                index = i;
        //                return count;
        //            }
        //        }

        //        return count;
        //    }
        //    catch (Exception ex)
        //    {
        //        AddFeedback(string.Format("Error :: getSeason - {0}", ex.ToString()));
        //        AddFeedback(string.Format("Error Culprit :: {0}", name));
        //        index = -1;
        //        return -1;
        //    }
        //}

        //private string getShowName(string name, int index)
        //{
        //    //  EXAMPLES  
        //    //  ncis.los.angeles.601.hdtv-lol
        //    //  Person.of.Interest.S04E02.HDTV.x264-LOL-NewsHost-2753
        //    //  House.of.Cards.2013.S01.480p.BluRay.nSD.x264-NhaNc3-NewsHost-3092

        //    try
        //    {
        //        string[] nameArray = name.Split('.');

        //        string show = "";

        //        for (int k = 0; k < index; k++)
        //        {
        //            show = show + " " + nameArray[k];
        //        }

        //        show.Trim();

        //        return show;
        //    }
        //    catch (Exception ex)
        //    {
        //        AddFeedback(string.Format("Error :: getShowName - {0}", ex.ToString()));
        //        return "";
        //    }
        //}

        private int getSeason(string name)
        {
            //  EXAMPLES  
            //  ncis.los.angeles.601.hdtv-lol
            //  Person.of.Interest.S04E02.HDTV.x264-LOL-NewsHost-2753
            //  House.of.Cards.2013.S01.480p.BluRay.nSD.x264-NhaNc3-NewsHost-3092
            try
            {
                int SeasonCount = 0;

                string[] nameArray = name.Split('.');

                for (int i = nameArray.Length - 1; i >= 0; --i)
                {
                    string testVal = nameArray[i];

                    if (REG_NewsHost.Match(testVal).Success)
                    {
                        //move on
                    }
                    else if (REG_x264.Match(testVal).Success)
                    {
                        //move on
                    }
                    else if (REG_xxxp.Match(testVal).Success)
                    {
                        //move on
                    }
                    else if (REG_SxxExx_Format.Match(testVal).Success)
                    {
                        SeasonCount = Convert.ToInt32(testVal.Substring(1, 2));
                        return SeasonCount;
                    }
                    else if (REG_Sxx_Format.Match(testVal).Success)
                    {
                        SeasonCount = Convert.ToInt32(testVal.Substring(1, 2));
                        return SeasonCount;
                    }
                    else if (REG_Sx_Format.Match(testVal).Success)
                    {
                        SeasonCount = Convert.ToInt32(testVal.Substring(1, 1));
                        return SeasonCount;
                    }
                    else if (REG_num4_Format.Match(testVal).Success)
                    {
                        SeasonCount = Convert.ToInt32(testVal.Substring(0, 2));
                        return SeasonCount;
                    }
                    else if (REG_NxNN_Format.Match(testVal).Success)
                    {
                        SeasonCount = Convert.ToInt32(testVal.Substring(0, 1));
                        return SeasonCount;
                    }
                    else if (REG_num3_Format.Match(testVal).Success)
                    {
                        SeasonCount = Convert.ToInt32(testVal.Substring(0, 1));
                        return SeasonCount;
                    }
                }

                return SeasonCount;
            }
            catch (Exception ex)
            {
                AddFeedback(string.Format("Error :: getSeason - {0}", ex.ToString()));
                return -1;
            }

        }

        private string getShowName(string name)
        {
            //  EXAMPLES  
            //  ncis.los.angeles.601.hdtv-lol
            //  Person.of.Interest.S04E02.HDTV.x264-LOL-NewsHost-2753
            //  House.of.Cards.2013.S01.480p.BluRay.nSD.x264-NhaNc3-NewsHost-3092

            int PositionIndex = 0;

            string[] nameArray = name.Split('.');

            for (int i = nameArray.Length - 1; i >= 0; --i)
            //for (int i = 0; i < nameArray.Length; i++)
            {
                string testVal = nameArray[i];

                if (REG_NewsHost.Match(testVal).Success)
                {
                    //move on
                }
                else if (REG_x264.Match(testVal).Success)
                {
                    //move on
                }
                else if (REG_xxxp.Match(testVal).Success)
                {
                    //move on
                }
                else if (REG_SxxExx_Format.Match(testVal).Success)
                {
                    PositionIndex = i;
                    break;
                }
                else if (REG_Sxx_Format.Match(testVal).Success)
                {
                    PositionIndex = i;
                    break;
                }
                else if (REG_Sx_Format.Match(testVal).Success)
                {
                    PositionIndex = i;
                    break;
                }
                else if (REG_num4_Format.Match(testVal).Success)
                {
                    PositionIndex = i;
                    break;
                }
                else if (REG_NxNN_Format.Match(testVal).Success)
                {
                    PositionIndex = i;
                    break;
                }
                else if (REG_num3_Format.Match(testVal).Success)
                {
                    PositionIndex = i;
                    break;
                }
            }

            string show = string.Join(" ", nameArray, 0, PositionIndex);

            //string show = "";

            //for (int k = 0; k < PositionIndex; k++)
            //{

            //    show = show + " " + nameArray[k];
            //}

            show.Trim();

            return show;
        }

        private void ClearTables()
        {
            dtInfo.Rows.Clear();
        }

        //private void IterateInfo()
        //{
        //    try
        //    {
        //        List<string> dirs = new List<string>(Directory.EnumerateDirectories(_sSrcPath));

        //        foreach (var item in dirs)
        //        {
        //            string _sShow = "";
        //            int _iSeason = 0;
        //            string _sFile = "";
        //            string _sPath = "";
        //            //string _sPath = item.ToString();

        //            List<string> paths = new List<string>(Directory.EnumerateFiles(item.ToString()));

        //            foreach (var files in paths)
        //            {
        //                try
        //                {
        //                    int index = item.LastIndexOf(@"\", item.Length);
        //                    string test = item.Substring(index);
        //                    string test2 = test.Trim('\\');
        //                    int IndexField = 0;

        //                    _iSeason = getSeason(test2.Trim(), out IndexField);
        //                    _sShow = getShowName(test2.Trim(), IndexField).Trim();

        //                    index = files.LastIndexOf(@"\", item.Length);
        //                    test = files.Substring(index);
        //                    test2 = test.Trim('\\');

        //                    _sFile = test2.Trim();

        //                    _sPath = files.ToString().Trim();

        //                    dtInfo.Rows.Add(_sShow, _iSeason, _sFile, _sPath);
        //                }
        //                catch (Exception InnerEx)
        //                {
        //                    AddFeedback(string.Format("Error Inner :: IterateInfo - {0}", InnerEx.ToString()));
        //                    AddFeedback(string.Format("Error culprit :: IterateInfo - {0}", files.ToString()));
        //                }
        //            }

        //            //AddFeedback(item.ToString());

        //            //dtInfo.Rows.Add(_sShow, _iSeason, _sFile, _sPath);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        AddFeedback(string.Format("Error :: IterateInfo - {0}", ex.ToString()));
        //    }
        //}

        private void PrepDatatable()
        {
            dtInfo.Columns.Add("Show", typeof(string));
            dtInfo.Columns.Add("Season", typeof(int));
            dtInfo.Columns.Add("File", typeof(string));
            dtInfo.Columns.Add("Path", typeof(string));
            dtInfo.Columns.Add("FullPath", typeof(string));
        }

        private void IterateInfo()
        {
            try
            {
                PrepDatatable();

                List<string> dirs = new List<string>(Directory.EnumerateDirectories(_sSrcPath));

                foreach (var item in dirs)
                {
                    string _sShow = "";
                    int _iSeason = 0;
                    string _sFile = "";
                    string _sPath = "";
                    //string _sPath = item.ToString();

                    List<string> paths = new List<string>(Directory.EnumerateFiles(item.ToString()));

                    foreach (var files in paths)
                    {
                        int Fileindex = files.LastIndexOf(@"\", item.Length);
                        string Filetest = files.Substring(Fileindex);
                        string Filetest2 = Filetest.Trim('\\');

                        _sFile = Filetest2.Trim();

                        int index = item.LastIndexOf(@"\", item.Length);
                        string test = item.Substring(index);
                        string test2 = test.Trim('\\');
                        _sShow = getShowName(test2).Trim();

                        _iSeason = getSeason(test2);

                        _sPath = files.ToString().Trim();

                        dtInfo.Rows.Add(_sShow, _iSeason, _sFile, _sPath);
                    }
                    //AddFeedback(item.ToString());

                    //dtInfo.Rows.Add(_sShow, _iSeason, _sFile, _sPath);
                }
            }
            catch (Exception ex)
            {
                AddFeedback(string.Format("Error :: IterateInfo - {0}", ex.ToString()));
            }
        }

        private bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private void WriteToLog()
        {
            try
            {
                string _sDate = DateTime.Now.ToString();
                _sDate = _sDate.Replace('/', '-');
                _sDate = _sDate.Replace(':', '-');

                string Dir = Environment.CurrentDirectory.ToString();
                Dir = Dir + @"\Logs\";
                string filename = string.Format("Log - {0}.txt", _sDate);
                string fullpath = Path.Combine(Dir, filename);

                var textLines = txtFeedback.Text.Split('\n');

                using (StreamWriter writer = new StreamWriter(fullpath, true))
                {
                    foreach (var line in textLines)
                    {
                        writer.WriteLine(line.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CopyFiles(int StepCounter)
        {
            try
            {
                string Show = dtInfo.Rows[StepCounter]["Show"].ToString();
                string Season = dtInfo.Rows[StepCounter]["Season"].ToString();
                string Source = dtInfo.Rows[StepCounter]["Path"].ToString();
                string file = dtInfo.Rows[StepCounter]["File"].ToString();

                //feedback.Add(string.Format("Processing \t: {0}", file));
                //feedback.Add(string.Format("Source Location \t: {0}", Source));

                string Despath;
                CreateDir(Show.Trim(), Season.Trim(), out Despath);
                string fullpath = string.Format(@"{0}\{1}", Despath, file);

                dtInfo.Rows[StepCounter]["FullPath"] = fullpath;

                string ext = Path.GetExtension(Source).Trim('.');

                if (ext == "avi" || ext == "mp4" || ext == "mkv")
                {
                    if (!File.Exists(fullpath))
                    {
                        File.Copy(Source, fullpath);

                        //txtFeedback.AppendText(string.Format("File copied : {0} \n", file));
                        feedback.Add(string.Format("Destination \t: {0}", fullpath));
                        feedback.Add(string.Format("File copied \t: {0}", file));

                        FileCounter++;
                        step++;

                        //lblProgress.Text = string.Format("{0}  /  {1}", step.ToString(), max.ToString());
                    }
                    else
                    {
                        //txtFeedback.AppendText(string.Format("File already exist : {0} \n", file));
                        feedback.Add(string.Format("File already exist \t: {0}", file));
                        step++;
                        AlreadyExisted++;

                        //lblProgress.Text = string.Format("{0}  /  {1}", step.ToString(), max.ToString());
                    }
                }
                else
                {
                    feedback.Add(string.Format("Invalid video file \t: {0}", file));
                    step++;
                    skipped++;
                }

                DeleteFiles(StepCounter);

            }
            catch (Exception ex)
            {
                //AddFeedback(string.Format("Error :: CopyFiles - {0}", ex.ToString()));
                //txtFeedback.AppendText(string.Format("Error :: CopyFiles - {0}", ex.ToString()));
                feedback.Add(string.Format("Error :: CopyFiles - {0}", ex.ToString()));
            }
        }

        private void CreateDir(string show, string season, out string fullpath)
        {
            if (season.Length == 1)
            {
                season = "0" + season;
            }

            string showPath = string.Format(@"{0}\{1}", _sDestPath, show);
            string seasonPath = string.Format(@"{0}\Season {1}", showPath, season);

            if (!Directory.Exists(showPath))
            {
                Directory.CreateDirectory(seasonPath);
                //AddFeedback(string.Format("Directory Created: {0}", seasonPath));
                feedback.Add(string.Format("Directory Created \t: {0}", seasonPath));
            }
            else
            {
                if (!Directory.Exists(seasonPath))
                {
                    Directory.CreateDirectory(seasonPath);
                    //AddFeedback(string.Format("Directory Created : {0}", seasonPath));
                    feedback.Add(string.Format("Directory Created \t: {0}", seasonPath));
                }
            }

            fullpath = seasonPath;
        }

        private void DeleteFiles(int StepCounter)
        {
            string SourceFile = dtInfo.Rows[StepCounter]["Path"].ToString();
            string DestFile = dtInfo.Rows[StepCounter]["FullPath"].ToString();
            string msg = "";
            string sourceDir = Path.GetDirectoryName(SourceFile);

            if (SourceFile != null && SourceFile != "" && DestFile != null && DestFile != "")
            {
                if (CheckDeleteFile(DestFile, SourceFile, out msg))
                {
                    File.Delete(SourceFile);
                    feedback.Add(string.Format("Source file Deleted \t: {0}", SourceFile));
                }
                else
                {
                    feedback.Add(msg);
                    feedback.Add(string.Format("Delete aborted \t: {0}", SourceFile));
                } 
            }

            if (IsDirectoryEmpty(sourceDir))
            {
                Directory.Delete(sourceDir);
                feedback.Add(string.Format("Directory Deleted \t: {0}", sourceDir));
            }
            else
            {
                feedback.Add("Directory Not Empty. Cannot Delete.");
                feedback.Add(string.Format("Directory Not Empty \t: {0}", sourceDir));
            }
        }

        private bool CheckDeleteFile(string fullpath, string Source, out string msg)
        {
            msg = "";

            try
            {
                bool bEqual = false;

                byte[] file1 = File.ReadAllBytes(Source);
                byte[] file2 = File.ReadAllBytes(fullpath);
                if (file1.Length == file2.Length)
                {
                    for (int i = 0; i < file1.Length; i++)
                    {
                        if (file1[i] != file2[i])
                        {
                            bEqual = false;
                            msg = "Files copied are not equal. Cannot Delete.";
                            break;
                        }
                    }
                    bEqual = true;
                }
                else
                {
                    bEqual = false;
                    msg = msg = "Files copied are not equal. Cannot Delete.";
                }

                if (bEqual)
                {
                    File.Delete(Source);
                    msg = string.Format("Deleted - {0}", Source);
                }

                return bEqual;
            }
            catch (Exception ex)
            {
                msg = string.Format("ERROR - {0}", ex.ToString());
                return false;
            }
        }

        #endregion


        #region SORT Async Threading

        //private void MyTaskWorker(string files)
        //{
        //    //threaded job to be done here
        //    Thread.Sleep(4000);
        //}

        private delegate void MyTaskWorkerDelegate(int StepCounter);

        private bool _myTaskIsRunning = false;

        //This property indicates a running asynchronous operation
        public bool IsBusy
        {
            get { return _myTaskIsRunning; }
        }
        
        //This method invokes the asynchronous operation and immediately returns. 
        //If an asynchronous operation is already running, an InvalidOperati­onException is thrown.
        public void MySortTaskAsync(int StepCounter)
        {
            MyTaskWorkerDelegate worker = new MyTaskWorkerDelegate(CopyFiles);
            AsyncCallback completedCallback = new AsyncCallback(MyTaskCompletedCallback);

            lock (_sync)
            {
                if (_myTaskIsRunning)
                    throw new InvalidOperationException("The control is currently busy.");

                AsyncOperation async = AsyncOperationManager.CreateOperation(null);
                worker.BeginInvoke(StepCounter, completedCallback, async);
                _myTaskIsRunning = true;
            }
        }

        private readonly object _sync = new object();

        //This method calls worker delegate's En­dInvoke method to finish the asynchronous operation and raises the MyTaskCompleted e­vent
        private void MyTaskCompletedCallback(IAsyncResult ar)
        {

            // get the original worker delegate and the AsyncOperation instance
            MyTaskWorkerDelegate worker = (MyTaskWorkerDelegate)((AsyncResult)ar).AsyncDelegate;
            AsyncOperation async = (AsyncOperation)ar.AsyncState;

            // finish the asynchronous operation
            worker.EndInvoke(ar);

            // clear the running task flag
            lock (_sync)
            {
                _myTaskIsRunning = false;
            }

            // raise the completed event
            AsyncCompletedEventArgs completedArgs = new AsyncCompletedEventArgs(null,
              false, null);
            async.PostOperationCompleted(
              delegate(object e) { OnMyTaskCompleted((AsyncCompletedEventArgs)e); },
              completedArgs);
        }

        //This event is raised when the asynchronous operation is completed
        public event AsyncCompletedEventHandler MyTaskCompleted;

        protected virtual void OnMyTaskCompleted(AsyncCompletedEventArgs e)
        {
            if (MyTaskCompleted != null)
            {
                MyTaskCompleted(this, e);
            }
            else
            {
                lblProgress.Text = string.Format("{0}  /  {1}", step.ToString(), max.ToString());

                foreach (var item in feedback)
                {
                    AddFeedback(item);
                }

                feedback.Clear();

                AddFeedback("--------------------------------------------------------------");
                AddFeedback("");

                progressBar1.PerformStep();
                progressBar1.Update();

                if (step != max)
                {
                    string file = dtInfo.Rows[step]["File"].ToString();
                    AddFeedback(string.Format("Processing \t: {0}", file));
                    string Source = dtInfo.Rows[step]["Path"].ToString();
                    AddFeedback(string.Format("Source Location \t: {0}", Source));

                    MySortTaskAsync(step);
                }
                else
                {
                    AddFeedback(string.Format("{0} files were copied.", FileCounter.ToString()));
                    AddFeedback(string.Format("{0} files already existed.", AlreadyExisted.ToString()));
                    AddFeedback(string.Format("{0} files were skipped or invalid.", skipped.ToString()));
                    AddFeedback("--------------------------------------------------------------");
                    AddFeedback(string.Format("{0} files were processed in total.", step.ToString()));

                    WriteToLog();
                }
            }
        }

        #endregion


        #region SORT EVENTS

        private void btnSourceBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderDiag = new FolderBrowserDialog();
            DialogResult result = FolderDiag.ShowDialog();
            if (result == DialogResult.OK)
            {
                _sSrcPath = FolderDiag.SelectedPath;
                txtSource.Text = _sSrcPath;                
            }
        }

        private void btnDestBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderDiag = new FolderBrowserDialog();
            DialogResult result = FolderDiag.ShowDialog();
            if (result == DialogResult.OK)
            {
                _sDestPath = FolderDiag.SelectedPath;
                txtDestination.Text = _sDestPath; 
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            //int test1 = getSeason("ncis.los.angeles.601.hdtv-lol");
            //AddFeedback(test1.ToString() + "\n");
            //int test2 = getSeason("Person.of.Interest.S04E02.HDTV.x264-LOL-NewsHost-2753");
            //AddFeedback(test2.ToString() + "\n");
            try
            {
                ClearFeedback();
                ClearTables();

                step = 0;
                FileCounter = 0;
                AlreadyExisted = 0;
                skipped = 0;

                feedback.Clear();

                _sSrcPath = txtSource.Text;
                _sDestPath = txtDestination.Text;

                Properties.Settings.Default.sourceDir = _sSrcPath;
                Properties.Settings.Default.destinationDir = _sDestPath;
                Properties.Settings.Default.Save();

                //get all structures for directories and save in datatable
                IterateInfo();

                max = dtInfo.Rows.Count;
                progressBar1.Maximum = max;
                progressBar1.Minimum = 0;
                progressBar1.Step = 1;

                if (max > 0)
                {
                    string file = dtInfo.Rows[step]["File"].ToString();
                    AddFeedback(string.Format("Processing \t: {0}", file));

                    string Source = dtInfo.Rows[step]["Path"].ToString();
                    AddFeedback(string.Format("Source Location \t: {0}", Source));

                    MySortTaskAsync(step);
                }
                else
                {
                    AddFeedback("No files to sort.");
                }
            }
            catch (Exception ex)
            {
                AddFeedback(string.Format("Error :: button1_Click - {0}", ex.ToString()));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteToLog();
        }

        #endregion


        #endregion




        #region Rename, WinRar, 7Zip Shared GLOBAL VARIABLES

        string _sRenameTargetPath = "";

        int MinDirSize = 0;
        int FileStepCounter = 0;
        int TotalFiles = 0;

        List<string> AllDirs;
        List<string> DirRAR;
        List<string> ErrorList;

        #endregion


        #region RENAME FILES IN DIRECTORIES

                
        #region Rename FILES FUNCTIONS

        private void getAllDirectories()
        {
            try
            {
                AllDirs = new List<string>(Directory.EnumerateDirectories(_sRenameTargetPath));
            }
            catch (Exception ex)
            {
                AddFeedback(string.Format("getAllDirectories() - ERROR EXCEPTION : {0}", ex.ToString()));
            }
        }

        private void getDirectoriesToRename()
        {
            FileStepCounter = 0;
            string fileNameOnly, extension, directoryOnly; 

            try
            {
                foreach (var dir in AllDirs)
                {
                    string fullPath = dir.ToString();
                    var ext = new List<string> { ".mkv", ".mp4", ".avi" };
                    var myExtentionFiles = Directory.EnumerateFiles(fullPath, "*.*", SearchOption.AllDirectories).Where(s => ext.Contains(Path.GetExtension(s)));

                    foreach (var files in myExtentionFiles)
                    {
                        FileInfo info = new FileInfo(files);
                        long b = info.Length;
                        if ((b / 1024) > (MinDirSize * 1000))
                        {
                            TotalFiles++;
                            string fullFile = files.ToString();
                            fileNameOnly = Path.GetFileNameWithoutExtension(fullFile);

                            extension = Path.GetExtension(fullFile);
                            directoryOnly = fullPath.Substring(fullPath.LastIndexOf("\\") + 1);
                            string newfilename = fullFile.Substring(0, fullFile.LastIndexOf("\\") + 1) + directoryOnly + extension;

                            if (fileNameOnly.ToLower() != directoryOnly.ToLower())
                            {
                                if (!File.Exists(newfilename))
                                {
                                    AddFeedback(string.Format("OLD file : {0}", fullFile));
                                    AddFeedback(string.Format("NEW file : {0}", newfilename));
                                    System.IO.File.Move(fullFile, newfilename);
                                    AddFeedback("");
                                    FileStepCounter++;
                                }
                                else
                                {
                                    AddFeedback(string.Format("File already exist: {0}", newfilename));
                                }
                            }
                        }
                    }
                }

                AddFeedback(string.Format("Files Checked : {0}", TotalFiles.ToString()));
                AddFeedback(string.Format("Files renamed : {0}", FileStepCounter.ToString()));
            }
            catch (Exception ex)
            {
                AddFeedback(string.Format("getDirectoriesToRename() - ERROR EXCEPTION : {0}", ex.ToString()));
            }
            finally
            {
                AllDirs.Clear();
                Dispose();
            }

        }

        #endregion


        #region RENAME FILE EVENTS

        private void btnTargetBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderDiag = new FolderBrowserDialog();
            DialogResult result = FolderDiag.ShowDialog();
            if (result == DialogResult.OK)
            {
                _sRenameTargetPath = FolderDiag.SelectedPath;
                txtRenameTargetDir.Text = _sRenameTargetPath;
            }
        }

        private void btnBrowseWinrar_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Filter = "EXE files (*.exe)|*.exe"; // "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            filedialog.InitialDirectory = @"C:\Program Files\WinRAR";

            DialogResult result = filedialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _sWinrarPath = filedialog.FileName;

                txtWinrarSrcDir.Text = _sWinrarPath;
            }
        }

        private void btnBrowseTargetExtract_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderDiag = new FolderBrowserDialog();
            DialogResult result = FolderDiag.ShowDialog();
            if (result == DialogResult.OK)
            {
                _sExtractTargetPath = FolderDiag.SelectedPath;
                txtTargetExtract.Text = _sExtractTargetPath;
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            string WarningSizeText = txtRenameSize.Text;

            if (IsDigitsOnly(WarningSizeText))
            {
                MinDirSize = Convert.ToInt32(txtRenameSize.Text);
                Properties.Settings.Default.MinRenameSize = MinDirSize;
            }
            else
            {
                AddFeedback("Invalid warning size.");
                return;
            }

            _sRenameTargetPath = txtRenameTargetDir.Text;
            if (Directory.Exists(_sRenameTargetPath))
            {
                Properties.Settings.Default.TargetDirRename = _sRenameTargetPath;
            }
            else
            {
                AddFeedback(string.Format("Rename target directory does not exist - {0}",_sRenameTargetPath));
                return;
            }

            Properties.Settings.Default.Save();

            ClearFeedback();

            AddFeedback(string.Format("Renaming directory files for sizes over : {0}mb", MinDirSize.ToString()));
            AddFeedback("");

            AddFeedback("Fetching directories to Rename");
            AddFeedback("");

            getAllDirectories();

            getDirectoriesToRename();
        }

        #endregion

        #endregion





        #region WINRAR EXTRACT


        #region WINRAR GLOBAL VARIABLES

        string _sExtractTargetPath = "";
        string _sWinrarPath = "";

        #endregion


        #region WINRAR EXTRACT FUNCTIONS

        private void unrarFiles(int step)
        {
            /**
             * https://stackoverflow.com/questions/23578704/unrar-an-archive-in-c-sharp
             **/
            //const string source = "D:\\22.rar";
            try
            {
                string source = DirRAR[step];

                string destinationFolder = source.Remove(source.LastIndexOf('\\'));
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                string winrar = Properties.Settings.Default.WinRARDir;
                p.StartInfo.FileName = winrar;
                p.StartInfo.Arguments = string.Format(@"x -s ""{0}"" *.* ""{1}\""", source, destinationFolder);
                p.Start();
                p.WaitForExit();

                if (p.HasExited)
                {
                    int ExitCode = p.ExitCode;

                    CheckStep++;

                    if (ExitCode == 0)
                    {
                        purgeDirectory(destinationFolder);
                    }
                    else
                    {
                        ErrorList.Add(DirRAR[step]);
                    }
                }
            }
            catch (Exception ex)
            {
                AddFeedback(string.Format("unrarFiles() - ERROR EXCEPTION : {0}", ex.ToString()));
            }
        }

        private void purgeDirectory(string folder)
        {
            try
            {
                var ext = new List<string> { ".mkv", ".mp4", ".avi", ".sub", ".idx" };

                var myFiles = Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories).Where(s => ext.Contains(Path.GetExtension(s)));
                var allFiles = Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories);

                foreach (var file in allFiles)
                {
                    bool found = false;
                    foreach (var testFile in myFiles)
                    {
                        if (file.ToLower() == testFile.ToLower())
                        {
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        File.Delete(file);
                    }
                }
            }
            catch (Exception ex)
            {
                AddFeedback(string.Format("purgeDirectory() - ERROR EXCEPTION : {0}", ex.ToString()));
            }
        }

        private void getDirectoriesToExtract()
        {
            try
            {
                DirRAR = new List<string>();
                FileStepCounter = 0;
                TotalFiles = 0;

                AllDirs = new List<string>(Directory.EnumerateDirectories(_sExtractTargetPath));
                ErrorList = new List<string>();

                foreach (var dir in AllDirs)
                {
                    TotalFiles++;
                    string fullPath = dir.ToString();

                    string[] myFiles = Directory.GetFiles(fullPath, "*.rar", SearchOption.AllDirectories);

                    if (myFiles.Length > 0)
                    {
                        DirRAR.Add(myFiles[0]);
                        AddFeedback(string.Format("Directory : {0}", myFiles[0]));
                        FileStepCounter++;
                    }
                }
                AddFeedback("");
                AddFeedback("------------------");
                AddFeedback(string.Format("Total Directories : {0}", TotalFiles.ToString()));
                AddFeedback(string.Format("RAR Directories : {0}", FileStepCounter.ToString()));
            }
            catch (Exception ex)
            {
                AddFeedback(string.Format("getDirectoriesToExtract() - ERROR EXCEPTION : {0}", ex.ToString()));
            }
        }

        #endregion


        #region WINRAR EXTRACT EVENTS

        private void btnWinRarExtract_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFeedback();

                AddFeedback("Fetching directories to Extract");
                AddFeedback("");

                _sExtractTargetPath = txtTargetExtract.Text;
                if (Directory.Exists(_sExtractTargetPath))
                {
                    Properties.Settings.Default.TargetExtractDir = _sExtractTargetPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    AddFeedback(string.Format("Directory not exist : {0}", _sExtractTargetPath));
                    return;
                }

                _sWinrarPath = txtWinrarSrcDir.Text;
                if (File.Exists(_sWinrarPath))
                {
                    Properties.Settings.Default.WinRARDir = _sWinrarPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    AddFeedback(string.Format("File not exist : {0}", _sWinrarPath));
                    return;
                }


                //getAllDirectories();

                getDirectoriesToExtract();

                CheckStep = 0;

                if (DirRAR.Count > 0)
                {
                    max = DirRAR.Count;
                    MyRenameTaskAsync(CheckStep);
                }
            }
            catch (Exception ex)
            {
                AddFeedback(string.Format("btnRenameUnrar_Click() - ERROR EXCEPTION : {0}", ex.ToString()));
            }
        }

        #endregion

        #endregion

    }
}
