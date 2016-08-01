/*
 * Form1.cs contains the main program flow 
 * 1- methods to access buttons
 * 2- methods to represent different scheduling algorithms
 * Developed By >> Mohamed Tarek Ibn Ziad , spring 2013
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CPU_Scheduling
{
    public partial class CPU_Scheduler : Form
    {
        List<Process> PList = new List<Process>();
        
        public CPU_Scheduler()
        {
            InitializeComponent();
        }

        private void CPU_Scheduler_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            PList = new List<Process>();

            //the code to load the xls file
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(textBox2.Text.TrimEnd(), 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //this code is to find the range of the selected excel sheet
            Excel.Range range;
            range = xlWorkSheet.UsedRange;

            //row and coloumn counters
            int rCnt = 0;
            int cCnt = 0;

            rCnt = range.Rows.Count;
            cCnt = range.Columns.Count;

            Process temp = new Process();
            for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
            {
                temp.PID = Convert.ToInt32(xlWorkSheet.get_Range("A" + rCnt, "A" + rCnt).Value2.ToString());
                temp.ArrivalTime = Convert.ToInt32(xlWorkSheet.get_Range("B" + rCnt, "B" + rCnt).Value2.ToString());
                temp.Burst = Convert.ToInt32(xlWorkSheet.get_Range("C" + rCnt, "C" + rCnt).Value2.ToString());
                temp.Priority = Convert.ToInt32(xlWorkSheet.get_Range("D" + rCnt, "D" + rCnt).Value2.ToString());

                PList.Add(temp);
                temp = new Process();
            }

            //For each process , make the remaining time = (the burst time) initially
            //then initialize IsInQueue
            for (int i = 0; i < PList.Count; i++)
            {
                PList[i].RemainingTime = PList[i].Burst;
                PList[i].IsInQueue = false;
            }

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void FCFS()
        {
            load();
            PList.Sort((x, y) => x.ArrivalTime.CompareTo(y.ArrivalTime));
            PList[0].TurnaroundTime = PList[0].Burst;
            int burstCounter = PList[0].Burst;
            MessageBox.Show("Time is : 0" + "\r\nProcess in is : " + PList[0].pID.ToString() , "FCFS");
            int i;
            for (i = 1; i < PList.Count; i++)
            {
                PList[i].WaitingTime = burstCounter - PList[i].ArrivalTime;
                
                PList[i].TurnaroundTime = PList[i].WaitingTime + PList[i].Burst;
                MessageBox.Show("Process : " + PList[i].pID.ToString() + " begins at Time : " + burstCounter.ToString(), "FCFS");
                burstCounter += PList[i].Burst;
            }
            MessageBox.Show("Final Process : " + PList[--i].pID.ToString() + " ends at Time : " + burstCounter.ToString(), "FCFS");
            //Show Averages
            float average = 0;
            float averageTurnaround = 0;
            for (int j = 0; j < PList.Count; j++)
            {
                average += PList[j].WaitingTime / PList.Count; //you may accumulate in average and then divide by Plist.count later after the loop
                averageTurnaround += PList[j].TurnaroundTime / PList.Count;
            }
            MessageBox.Show("Average waiting time= " + average.ToString() + "\r\nAverage Turnaround time= " + averageTurnaround, "FCFS");
        }
        
        /// <summary>
        /// insert process in the queue if its arrival time comes during other process excution  
        /// </summary>
        /// <param name="CurrentTime">current time of the processes clock</param>
        private void whosThere(int currentTime)
        {
            for (int i = 0; i < PList.Count; i++)
            {
                if (PList[i].ArrivalTime <= currentTime && PList[i].IsDone == false)
                    PList[i].IsInQueue = true;
            }
        }
        
        private void SJF_P()
        {
            load();
            int i, j=0;
            for (i = 0; i < 1000; i++)
            {
                PList.Sort((x, y) => x.RemainingTime.CompareTo(y.RemainingTime));
                whosThere(i);
                
                for (j = 0; j < PList.Count; j++)
                {
                    if (PList[j].RemainingTime == 0 && PList[j].IsDone == false)
                    {
                        PList[j].FinishTime = i;
                        PList[j].IsInQueue = false;
                        PList[j].IsDone = true;
                    }
                    if (PList[j].IsInQueue == true)
                    {
                        MessageBox.Show("At Time is : " + i.ToString() + "\r\nProcess in is : " + PList[j].pID.ToString() , "SJF_Preemptive");
                        PList[j].RemainingTime--;
                        break;
                    }
                }
            }
            //Show Averages
            float averageTurnaround = 0;
            float averageWaiting = 0;
            for (int k = 0; k < PList.Count; k++)
            {
                averageWaiting += ((PList[k].FinishTime - PList[k].ArrivalTime - PList[k].Burst));
                averageTurnaround += ((PList[k].FinishTime - PList[k].ArrivalTime));
            }
            averageTurnaround = averageTurnaround / PList.Count;
            averageWaiting /= PList.Count;
            MessageBox.Show("Average waiting time = " + averageWaiting.ToString() + "\r\nAverage TurnAround time = " + averageTurnaround, "SJF_Preemptive");
        }

        /// <summary>
        /// returns the process at the queue at the current time given 
        /// </summary>
        /// <param name="CurrentTime">current time of the processes clock</param>
        /// <returns>a list of current processess ready at the queue</returns>
        private List<Process> whosHere(int CurrentTime)
        {
            List<Process> CurrentPs = new List<Process>();
            PList.Sort((x, y) => x.ArrivalTime.CompareTo(y.ArrivalTime));
            for (int i = 0; i < PList.Count; i++)
            {
                if (PList[i].ArrivalTime <= CurrentTime && PList[i].IsDone == false)
                    CurrentPs.Add(PList[i]);
            }
            return CurrentPs;
        }
      
        private void SJF_NP()
        {
            load();
            /*First process to come would be excuted normally without interruption and 
             * if another process come during its excution time , nothing would happen as that is non prempative*/
            PList[0].IsDone = true;
            PList[0].TurnaroundTime = PList[0].Burst; //set it from the first time as it wouldn't change
            int currentTime = PList[0].Burst;
            List<Process> currentPs = new List<Process>();
            MessageBox.Show("Process : " + PList[0].pID.ToString() + " begins at Time : 0", "SJF_NP");
            
            //start loop from the 2nd process
            for (int i = 1; i < PList.Count; i++)
            {
                currentPs = whosHere(currentTime); //returns the processes at the queue at the current time given
                currentPs.Sort((x, y) => x.Burst.CompareTo(y.Burst));
                currentPs[0].WaitingTime = currentTime - currentPs[0].ArrivalTime;//using currentPs[0] cuz currentPs is updatted every loop cycle
                currentPs[0].TurnaroundTime = currentPs[0].WaitingTime + currentPs[0].Burst;
                for (int k = 0; k < PList.Count; k++)
                {
                    if (currentPs[0] == PList[k])
                        PList[k].IsDone = true;
                }
                MessageBox.Show("Process : " + currentPs[0].pID.ToString() + " begins at Time : " + currentTime.ToString(), "SJF_NP");
                currentTime += currentPs[0].Burst;
            }
            MessageBox.Show("Final Process : " + currentPs[0].pID.ToString() + " ends at Time : " + currentTime.ToString(), "SJF_NP");
            //Show Averages
            float average = 0;
            float averageTurnaround = 0;
            for (int i = 0; i < PList.Count; i++)
            {
                average += PList[i].WaitingTime / PList.Count; //you may accumulate in average and then divide by Plist.count later after the loop
                averageTurnaround += PList[i].TurnaroundTime / PList.Count;
            }
            MessageBox.Show("Average waiting time = " + average.ToString() + "\r\nAverage TurnAround time = " + averageTurnaround, "SJF_NP");                       
        }

        private void Priority_P()
        {
            load();
            List<Process> currentList = new List<Process>();
            int CurrentTime = 0;
            for (int i = 0; i < 1000; i++)
            {
                currentList = whosHere(CurrentTime);
                currentList.Sort((x, y) => x.Priority.CompareTo(y.Priority));
                if (currentList.Count == 0)
                    break;
                if (currentList[0].RemainingTime == 0)
                {
                    currentList[0].IsDone = true;
                    currentList[0].IsInQueue = false;
                    currentList[0].FinishTime = CurrentTime;
                    continue;
                }
                currentList[0].RemainingTime--;
                MessageBox.Show("AT Time : " + CurrentTime.ToString() + "\r\nProcess in is : " + currentList[0].pID.ToString(), "Priority_P");
                CurrentTime++;
            }

            float averageTurnaround = 0;
            float averageWaiting = 0;
            for (int i = 0; i < PList.Count; i++)
            {
                averageWaiting += ((PList[i].FinishTime - PList[i].ArrivalTime - PList[i].Burst));
                averageTurnaround += ((PList[i].FinishTime - PList[i].ArrivalTime));
            }
            averageTurnaround = averageTurnaround / PList.Count;
            averageWaiting /= PList.Count;
            MessageBox.Show("Average waiting time = " + averageWaiting.ToString() + "\r\nAverage Turnaround time = " + averageTurnaround, "Priority_P");
        }

        private void Priority_NP()
        {
            load();
            List<Process> currentList = new List<Process>();
            int CurrentTime = 0;
            for (int i = 0; i < PList.Count; i++)
            {
                currentList = whosHere(CurrentTime);
                currentList.Sort((x, y) => x.Priority.CompareTo(y.Priority));
                currentList[0].IsDone = true;
                MessageBox.Show("At Time : " + CurrentTime.ToString() + " ,Process : " + currentList[0].pID.ToString() + " begins", "Priority_NP");
                CurrentTime += currentList[0].Burst;
                currentList[0].FinishTime = CurrentTime;
            }
            MessageBox.Show("At Time : " + CurrentTime.ToString() + " ,Process : " + currentList[0].pID.ToString() + " ends", "Priority_NP");
            //PList = currentList;
            float averageTurnaround = 0;
            float averageWaiting = 0;
            for (int i = 0; i < PList.Count; i++)
            {
                averageWaiting += ((PList[i].FinishTime - PList[i].ArrivalTime - PList[i].Burst));
                averageTurnaround += ((PList[i].FinishTime - PList[i].ArrivalTime));
            }
            averageTurnaround = averageTurnaround / PList.Count;
            averageWaiting /= PList.Count;
            MessageBox.Show("Average waiting time = " + averageWaiting.ToString() + "\r\nAverage Turnaround time = " + averageTurnaround, "Priority_NP");

        }

        private void RoundRobin()
        {
            load();
            int Quantum = 0;
            int listCounter = 0;
            int Qin = Convert.ToInt32(textBox1.Text.ToString());
            Process temp = new Process();
            List<Process> CurrentList = new List<Process>();

            for (int i = 0; i < 1000; i++)
            {
                bool isfinish = false;

                CurrentList = whosHere(i);
                CurrentList.Sort((x, y) => x.ArrivalTime.CompareTo(y.ArrivalTime));
                
                if (listCounter >= CurrentList.Count)
                    listCounter = 0;

                if (i == 0)
                    temp = CurrentList[0];
                if (CurrentList.Count == 0)
                    break;

                if (Quantum == Qin || temp.RemainingTime == 0)
                {
                    /*Process should be swapped out when the Q becomes or when it is finished exceution
                    then the temp should be updated */
                    if (temp.RemainingTime == 0)
                    {
                        temp.FinishTime = i;
                        temp.IsDone = true;
                        temp.IsInQueue = false;
                        Quantum = 0;
                    }
                    else if (Quantum == Qin)
                    {
                        Quantum = 0;
                    }
                    
                    for (int j = 0; j < CurrentList.Count; j++)
                    {
                        if (temp.pID == CurrentList[j].pID && CurrentList.Count != j + 1)
                        {
                            temp = CurrentList[j + 1];
                            break;
                        }
                        else if (temp.pID == CurrentList[j].pID && CurrentList.Count == j + 1)
                        {
                            temp = CurrentList[0];
                            break;
                        }
                    }
                }
                if (isfinish == true)
                    break;
                MessageBox.Show("At Time is : " + i.ToString() + "\r\nProcess in is : " + temp.pID.ToString(), "RoundRobin");
                temp.RemainingTime--;
                Quantum++;
            }
            //average summer
            float averageTurnaround = 0;
            float averageWaiting = 0;
            for (int i = 0; i < PList.Count; i++)
            {
                averageWaiting += ((PList[i].FinishTime - PList[i].ArrivalTime - PList[i].Burst));
                averageTurnaround += ((PList[i].FinishTime - PList[i].ArrivalTime));
            }
            averageTurnaround = averageTurnaround / PList.Count;
            averageWaiting /= PList.Count;
            MessageBox.Show("Average waiting time = " + averageWaiting.ToString() + "\r\nAverage Turnaround time = " + averageTurnaround,"RoundRobin");
        }
 
        private void btn_FCFS_Click(object sender, EventArgs e)
        {
            FCFS();
        }

        private void btn_SJF_P_Click(object sender, EventArgs e)
        {
            SJF_P();
        }

        private void btn_SJF_NP_Click(object sender, EventArgs e)
        {
            SJF_NP();
        }

        private void btn_Priority_P_Click(object sender, EventArgs e)
        {
            Priority_P();
        }

        private void btn_Priority_NP_Click(object sender, EventArgs e)
        {
            Priority_NP();
        }

        private void btn_RoundRobin_Click(object sender, EventArgs e)
        {
            RoundRobin();
        }
    }
}
