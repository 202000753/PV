// See https://aka.ms/new-console-template for more information


using ButtonClick;

Message msg = new Message();
msg.Text = "Uma mensagem";

Button button = new Button();

button.Click += Hi;
button.Click += msg.Show;
button.Click += Bye;

button.Press();

Console.ReadLine();

void Hi()
{
    Console.WriteLine("Ola");
}

void Bye()
{
    Console.WriteLine("Adeus");
}
