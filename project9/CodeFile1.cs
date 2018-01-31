using System;

class ForBoard
{
    public void mtfillbrd(char[,] a )
    {
        for(int i = 0; i < 3; i++ )
        {
            for(int j = 0; j < 3; j++)
            {
                a[i, j] = '_';
            }
        }
    }

    public void cout(char [,] a)
    {
        Console.WriteLine("  1 2 3 ");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + 1 + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(a[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
}


class gameover // взаимодействие функций, вспомогающий класс
{
    public bool over;
    public char player;

}

class CheckBool
{
    private int counter(char[,] a)
    {
        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (a[i, j] == '_')
                    count++;
                
            }
        }
        return count;
    }
    private bool draw(char[,] a1)
    {
        int a;
        a = counter(a1);
        if (a != 0)
        {
            return false;
        }
        else
            return true;
    }
    private gameover chkbl(char[,] array)   // проверка на выигрыш
    {
        gameover build = new gameover();
        if (array[0, 0] != '_' && array[0, 0] == array[0, 1] && array[0, 1] == array[0, 2])
        {
            build.over = true;
            build.player = array[0, 0];
            return build;
        }
        else if (array[1, 0]  != '_' && array[1, 0] == array[1, 1] && array[1, 1] == array[1, 2])
        {
            build.over = true;
            build.player = array[1, 0];
            return build;
        }
        else if (array[2, 0]  != '_' && array[2, 0] == array[2, 1] && array[2, 1] == array[2, 2])
        {
            build.over = true;
            build.player = array[2, 0];
            return build;
        }
        else if (array[0, 0]  != '_' && array[0, 0] == array[1, 0] && array[1, 0] == array[2, 0])
        {
            build.over = true;
            build.player = array[0, 0];
            return build;
        }
        else if (array[0, 1]  != '_' && array[0, 1] == array[1, 1] && array[1, 1] == array[2, 1])
        {
            build.over = true;
            build.player = array[0, 1];
            return build;
        }
        else if (array[0, 2]  != '_' && array[0, 2] == array[1, 2] && array[1, 2] == array[2, 2])
        {
            build.over = true;
            build.player = array[0, 2];
            return build;
        }
        else if (array[0, 0]  != '_' && array[0, 0] == array[1, 1] && array[1, 1] == array[2, 2])
        {
            build.over = true;
            build.player = array[0, 0];
            return build;
        }
        else if (array[2, 0]  != '_' && array[2, 0] == array[1, 2] && array[1, 2] == array[0, 2])
        {
            build.over = true;
            build.player = array[1, 2];
            return build;
        }
        else if (array[2, 0] != '_' && array[2, 0] == array[1, 1] && array[1, 1] == array[0, 2])
        {
            build.over = true;
            build.player = array[2, 0];
            return build;
        }
        else if (draw(array))
        {
            build.over = true;
            build.player = 'D';
            return build;
        }
        else
        {
            build.over = false;
            build.player = 'n';
            return build;
        }
    }


    public bool proverka(char[,] array) // окончательная проверка
    {
        gameover second = new gameover();
        second = chkbl(array);
        if (second.player != 'D')
        {
            if (second.player != 'n')
            {
                if (second.player != 'X')
                    Console.WriteLine("Выиграл игрок 0");
                else
                    Console.WriteLine("Выиграл игрок X");
            }
            return second.over;
        }
        else
        {
            Console.WriteLine("Ничья!");
            return second.over;
        }
    }

} // проверка на линии


class inboard
{

    public bool coutboard(char[,] bord, bool t) // функция много-функция ввод позиции, его проверка
    {
        int a, b;

        if (t == true)
        {
        A:
            Console.WriteLine("Игрок А(X), введите координаты:");
            Console.WriteLine("Горизонталь: ");
            a = (Convert.ToInt32(Console.ReadLine())) - 1;
            if (a >= 0 && a <= 2)
            {
                Console.WriteLine("Вертикаль: ");
                b = (Convert.ToInt32(Console.ReadLine())) - 1;
                if (!(b >= 0 && b <= 2))
                {
                    Console.WriteLine("Координаты не верны!");
                    goto A;
                }
            }
            else
            {
                Console.WriteLine("Координаты не верны!");
                goto A;
            }

            if (bord[a, b] == '_')
            {
                bord[a, b] = 'X';
                return false;
            }
            else
            {
                Console.WriteLine("Координаты не верны!");
                goto A;
            }
        }
        else
        {
        B:
            Console.WriteLine("Игрок B(0), введите координаты:");
            Console.WriteLine("Горизонталь: ");
            a = (Convert.ToInt32(Console.ReadLine())) - 1;
            if (a >= 0 && a <= 2)
            {
                Console.WriteLine("Вертикаль: ");
                b = (Convert.ToInt32(Console.ReadLine())) - 1;
                if (!(b >= 0 && b <= 2))
                {
                    Console.WriteLine("Координаты не верны!");
                    goto B;
                }
            }
            else
            {
                Console.WriteLine("Координаты не верны!");
                goto B;
            }


            if (bord[a, b] == '_' && b >= 0 && b <= 2)
            {
                bord[a, b] = '0';
                return true;
            }
            else
            {
                Console.WriteLine("Координаты не верны!");
                goto B;
            }


        }
    }
} // ввод в таблицу;

class PlusMin
{
    static void Main()
    {
        Console.WriteLine("Добро пожаловать в игру \"Крестики нолики\"");
        char[,] board = new char[3,3];
        ForBoard test = new ForBoard();
        test.mtfillbrd(board);
        Console.WriteLine("Начало игры!");
        CheckBool chk = new CheckBool();
        bool player = true;
        inboard game = new inboard();
        do
        {
            test.cout(board);
            player = game.coutboard(board, player);
            Console.WriteLine();
        } while (!chk.proverka(board));




        Console.ReadKey();
    }
}
