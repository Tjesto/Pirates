﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pirates
{
    public partial class LogCat : Form
    {
        public LogCat()
        {
            InitializeComponent();
        }

        private long lastWriteTime = 0;

        internal void append(LogMode logMode, DateTime dateTime, string pName, string tag, string message)
        {
            StringBuilder sb = new StringBuilder();
            switch(logMode) 
            {
                case LogMode.DEBUG:
                    sb.Append("D");
                    break;
                case LogMode.ERROR:
                    sb.Append("E");
                    break;
                case LogMode.INFO:
                    sb.Append("I");
                    break;
                case LogMode.VERBOSE:
                    sb.Append("V");
                    break;
                case LogMode.WARNING:
                    sb.Append("W");
                    break;
                case LogMode.WTF:
                    sb.Append("WTF");
                    break;
            }
            sb.Append("\t").Append(dateTime.Year).Append("-").Append(dateTime.Month).Append("-").Append(dateTime.Day);
            sb.Append(" ").Append(dateTime.Hour).Append(":").Append(dateTime.Minute).Append(":").Append(dateTime.Second)
                .Append(".").Append(dateTime.Millisecond);
            sb.Append("\t").Append(pName).Append(tag).Append("\t|").Append(message).Append("\n");
            if ((DateTime.Now.Ticks - lastWriteTime) > 500)
            {
                try
                {
                    LogBox.AppendText(sb.ToString());
                    lastWriteTime = DateTime.Now.Ticks;
                }
                catch (Exception e)
                {
                    //do nothing
                }
            }
        }
    }
}
