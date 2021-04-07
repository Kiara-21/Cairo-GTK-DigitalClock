using System;
using Gtk;
using System.Threading;

public partial class MainWindow : Gtk.Window
{
    public static string TimerChanger;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        custom1.WidthRequest = 200;
        custom1.HeightRequest = 200;
        custom1.ExposeEvent += TimerFunction;
    }

    protected void TimerFunction(object sender, ExposeEventArgs args)
    {
        Timer timer_1 = new Timer(Numbers, sender, 0, 1000);
        Timer timer_2 = new Timer(Cleaning, sender, 0, 1000);
    }

    public static void Numbers(object sender)
    {
            DrawingArea area = (DrawingArea)sender;
            Cairo.Context cc = Gdk.CairoHelper.Create(area.GdkWindow);

            cc.SetSourceRGB(0, 0, 0);
            cc.LineWidth = 1;
            cc.SetFontSize(15);
            cc.SelectFontFace("Sans", Cairo.FontSlant.Normal, Cairo.FontWeight.Normal);
            cc.MoveTo(20, 100);
            cc.ShowText(DateTime.Now.ToString());
            cc.StrokePreserve();
            cc.Fill();
    }

    public static void Cleaning(object sender)
    {
        DrawingArea area = (DrawingArea)sender;
        Cairo.Context cc = Gdk.CairoHelper.Create(area.GdkWindow);

        cc.SetSourceRGB(1, 1, 1);
        cc.Rectangle(0, 0, 200, 200);
        cc.StrokePreserve();
        cc.Fill();
        cc.SetSourceRGB(0, 0, 0);
        cc.LineWidth = 1;
        cc.SetFontSize(15);
        cc.SelectFontFace("Sans", Cairo.FontSlant.Normal, Cairo.FontWeight.Normal);
        cc.MoveTo(20, 100);
        cc.ShowText(DateTime.Now.ToString());
        cc.StrokePreserve();
        cc.Fill();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

}

