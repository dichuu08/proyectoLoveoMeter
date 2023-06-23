﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Autores:
 * Diego Mora
 * Carlos Talavera
 * Tutor:
 * José Durán
 * 
 */

namespace MedidorAmor
{
    public partial class Form1 : Form
    {
        bool active = false;
        string texto = "0.0";
        double temperature = 0.0;
        double baselineTemp = 26;
        string _puerto="COM3";

        private void Start()
        {
            try
            {
                if (!active)
                {
                    serialPort1.Open();
                    active = true;
                    timer1.Enabled = true;
                    timer1.Interval = 50;
                    timer1.Start();
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                }
                else
                {
                    serialPort1.Close();
                    active = false;
                    timer1.Enabled = false;
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = _puerto;
                //LblPuerto.Text = _puerto;
            }catch(Exception ex)
            {
                MessageBox.Show("Advertencia: " + ex.Message, "Love-o-meter", MessageBoxButtons.OK);
            }
        }

        private void getTemp()
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                string[] datos = serialPort1.ReadLine().Split('-');
                texto = datos[0];
            }
            catch (Exception ex) { }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblTemp.Text = texto;
                temperature = double.Parse(lblTemp.Text);
                Evaluate();
            }
            catch (Exception ex) { }
        }

        private void Evaluate()
        {
            try
            {
                if (temperature < baselineTemp + 2)
                {
                    
                    this.pictureBox1.Image = global::MedidorAmor.Properties.Resources.CorazonUCA;
                }
                else if (temperature >= baselineTemp + 2 && temperature < baselineTemp + 4)
                {
                    
                    this.pictureBox1.Image = global::MedidorAmor.Properties.Resources.gato1;
                }
                else if (temperature >= baselineTemp + 4 && temperature < baselineTemp + 6)
                {
                   
                    this.pictureBox1.Image = global::MedidorAmor.Properties.Resources.gato2;
                }
                else if (temperature >= baselineTemp + 6)
                {
                    
                    this.pictureBox1.Image = global::MedidorAmor.Properties.Resources.gato3;
                }
            }
            catch (Exception ex) { }
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Start();
                
            }
            catch (Exception ex) { }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void btnPuerto_Click(object sender, EventArgs e)
        {
          //  _puerto = TxtPuerto.Text;
            //LblPuerto.Text = _puerto;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
