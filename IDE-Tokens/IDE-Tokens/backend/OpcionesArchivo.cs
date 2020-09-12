﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace IDE_Tokens.backend
{
    
    class OpcionesArchivo
    {
        string filtro = "compilador|*.gt";
        public OpcionesArchivo()
        {

        }
        public void abrir(RichTextBox txtEditor)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filtro;
            FlowDocument flowDocument = new FlowDocument();
            //Leemos el documento
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.OpenFile()))
                {
                    txtEditor.Text = reader.ReadToEnd();
                }

            }
        }
        public void guardar(RichTextBox txtEditor)
        {           
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filtro;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter textoSave = File.CreateText(saveFileDialog.FileName);
                textoSave.Write(txtEditor.Text);
                textoSave.Flush();
                textoSave.Close();               
            }

        }

    }
}
