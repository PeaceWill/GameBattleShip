﻿
namespace BattleShip
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.updateStones = new System.Windows.Forms.Timer(this.components);
            this.updateRocket = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // updateStones
            // 
            this.updateStones.Tick += new System.EventHandler(this.update_Tick);
            // 
            // updateRocket
            // 
            this.updateRocket.Tick += new System.EventHandler(this.updareRocket_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "Main";
            this.Text = "Main";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Main_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer updateStones;
        private System.Windows.Forms.Timer updateRocket;
    }
}

