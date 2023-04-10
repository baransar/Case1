namespace Case1
{
    public class Program
    {
        public static int FIRST_JUDGE_PRICE = 2500;
        public static int SECOND_JUDGE_PRICE = 3300;
        public static int JURY_PRICE = 50;

        public static bool JUDGE_UNDECIDED = true;

        public static int totalJuryCount = default;
        public static int innocentJuryCount = default;
        static void Main()
        {
            Console.WriteLine("Jurilerin sayısını giriniz (0 = çıkış):");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out totalJuryCount))
                {
                    Console.WriteLine("Lütfen bir sayı giriniz.");
                    continue;
                }
                if (totalJuryCount <= 0)
                {
                    System.Environment.Exit(1);
                }
                break;
            }

            Console.WriteLine("Suçsuz bulan jurilerin sayısını giriniz (0 = çıkış): ");
            while (true)
            {          
                if (!int.TryParse(Console.ReadLine(), out innocentJuryCount))
                {
                    Console.WriteLine("Lütfen bir sayı giriniz.");
                    continue;
                }
                if (totalJuryCount < innocentJuryCount)
                {
                    Console.WriteLine("Lütfen total'den küçük bir sayı giriniz:");
                    continue;
                }
                if (innocentJuryCount == 0)
                {
                    System.Environment.Exit(1);
                }
                break;
            }
            ProcessClass processClass = new();

            if (FIRST_JUDGE_PRICE != SECOND_JUDGE_PRICE)
            {
                int value = default;
                if (FIRST_JUDGE_PRICE > SECOND_JUDGE_PRICE)
                {
                    value = FIRST_JUDGE_PRICE;
                }
                else
                    value = SECOND_JUDGE_PRICE;
                processClass.CalculateMinimumValue(value);
            }

        }
        class ProcessClass
        {
            public void CalculateMinimumValue(int judgePrice)
            {
                List<int> valuesList = new();

                int judgeUndecided = judgePrice / 2;

                int allJuriesInnocent = totalJuryCount * 50;
                int juryInnocentJudgeUndecided = innocentJuryCount * 50 + judgeUndecided;


                if (innocentJuryCount == totalJuryCount)
                {
                    valuesList.Add(allJuriesInnocent); // Tüm juriler suçsuz diyor.
                }
                else if (totalJuryCount / innocentJuryCount <= totalJuryCount / 2)
                {
                    valuesList.Add(juryInnocentJudgeUndecided); // Jurilerin en az yarısı suçsuz diyor, hakim ise kararsız.
                }

                valuesList.Add(judgePrice); // Hakim beraat istiyor.

                int result = valuesList.Min();

                if (result == allJuriesInnocent)
                {
                    Console.WriteLine("En ucuz yol: " + result + "TL. Tüm juriler suçsuz diyor.");
                }
                else if (result == juryInnocentJudgeUndecided)
                {
                    Console.WriteLine("En ucuz yol: " + result + "TL. Jurilerin en az yarısı suçsuz diyor, hakim ise kararsız.");
                }
                else if (result == judgePrice)
                {
                    Console.WriteLine("En ucuz yol: " + result + "TL. Hakim beraat istiyor.");
                }

                Console.ReadKey();
            }
        }
    }
}
